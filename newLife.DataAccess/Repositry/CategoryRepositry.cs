

using newLife.DataAccess.Repositry.IRepositry;
using newLife.DataAcess.Data;
using newLife.Models;

namespace newLife.DataAccess.Repositry
{
    public class CategoryRepositry : Repositry<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}
