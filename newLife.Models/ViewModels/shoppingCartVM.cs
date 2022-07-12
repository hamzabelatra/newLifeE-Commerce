namespace newLife.Models.ViewModels
{
    public class shoppingCartVM
    {
        public IEnumerable<ShoppingCart> listCart { get; set; }
        public OrderHeader orderHeader { get; set; }
    }
}
