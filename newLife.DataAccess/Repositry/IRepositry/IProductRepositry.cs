using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface IProductRepositry : IRepositry<Product>
    {
        void Update(Product product);
    }
}
