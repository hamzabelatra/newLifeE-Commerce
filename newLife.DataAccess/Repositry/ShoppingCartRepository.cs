

using newLife.DataAccess.Repositry.IRepositry;
using newLife.DataAcess.Data;
using newLife.Models;

namespace newLife.DataAccess.Repositry
{
    public class ShoppingCartRepositry : Repositry<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



    }
}
