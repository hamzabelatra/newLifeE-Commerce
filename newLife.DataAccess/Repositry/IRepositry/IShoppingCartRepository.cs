using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface IShoppingCartRepository : IRepositry<ShoppingCart>
    {

        int IncrementCount(ShoppingCart cart, int count);
        int DecrementCount(ShoppingCart cart, int count);

    }
}
