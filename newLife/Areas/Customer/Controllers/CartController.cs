using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLife.DataAccess.Repositry.IRepositry;
using newLife.Models;
using newLife.Models.ViewModels;
using newLife.Utility;
using System.Security.Claims;

namespace newLife.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public shoppingCartVM CartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCartVM cartVM = new shoppingCartVM()
            {
                listCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Product"),
                orderHeader = new()

            };


            foreach (var cart in cartVM.listCart)
            {
                cart.Price = getPriceBasedOnQuantity(cart.count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
                cartVM.orderHeader.OrderTotal += (cart.Price * cart.count);
            }
            return View(cartVM);
        }

        public double getPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            if (quantity <= 50)
            {
                return price;
            }
            else
            {
                if (quantity <= 100)
                { return price50; }
            }
            return price100;

        }

        public IActionResult plus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult remove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult minus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            if (cart.count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cart);

            }
            else
            {
                _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCartVM cartVM = new shoppingCartVM()
            {
                listCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Product"),
                orderHeader = new()


            };
            cartVM.orderHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == claim.Value);

            cartVM.orderHeader.Name = cartVM.orderHeader.ApplicationUser.Name;
            cartVM.orderHeader.PhoneNumber = cartVM.orderHeader.ApplicationUser.PhoneNumber;
            cartVM.orderHeader.StreetAdress = cartVM.orderHeader.ApplicationUser.StreetAdress;
            cartVM.orderHeader.City = cartVM.orderHeader.ApplicationUser.City;
            cartVM.orderHeader.State = cartVM.orderHeader.ApplicationUser.State;
            cartVM.orderHeader.PostalCode = cartVM.orderHeader.ApplicationUser.PostalCode;




            foreach (var cart in cartVM.listCart)
            {
                cart.Price = getPriceBasedOnQuantity(cart.count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
                cartVM.orderHeader.OrderTotal += (cart.Price * cart.count);
            }
            return View(cartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CartVM.listCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                 includeProperties: "Product");



            CartVM.orderHeader.PaymentStatus = SD.PaymentStatusPending;
            CartVM.orderHeader.OrderStatus = SD.StatusPending;
            CartVM.orderHeader.OrderDate = DateTime.Now;
            CartVM.orderHeader.ApplicationUserId = claim.Value;


            foreach (var cart in CartVM.listCart)
            {
                cart.Price = getPriceBasedOnQuantity(cart.count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
                CartVM.orderHeader.OrderTotal += (cart.Price * cart.count);
            }
            _unitOfWork.OrderHeader.Add(CartVM.orderHeader);
            _unitOfWork.Save();

            foreach (var cart in CartVM.listCart)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProdcutId,
                    OrderId = CartVM.orderHeader.id,
                    Price = cart.Price,
                    count = cart.count,

                };
                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();

            }
            _unitOfWork.ShoppingCart.RemoveRange(CartVM.listCart);
            _unitOfWork.Save();

            return RedirectToAction("Index", "Home");
        }


    }
}
