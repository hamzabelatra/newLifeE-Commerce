using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLife.DataAccess.Repositry.IRepositry;
using newLife.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace newLife.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitofwork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitofwork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitofwork.Product.GetAll(includeProperties: "Category,CoverTyper");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cartObj = new()
            {
                count = 1,
                ProdcutId = productId,
                Product = _unitofwork.Product.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category,CoverTyper"),
            };
            return View(cartObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;
            _unitofwork.ShoppingCart.Add(shoppingCart);
            _unitofwork.Save();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}