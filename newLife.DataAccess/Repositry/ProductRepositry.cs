using newLife.DataAccess.Repositry.IRepositry;
using newLife.DataAcess.Data;
using newLife.Models;

namespace newLife.DataAccess.Repositry
{
    public class ProductRepositry : Repositry<Product>, IProductRepositry
    {
        private ApplicationDbContext _db;
        public ProductRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.CoverTyperId = obj.CoverTyperId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;

                }



            }
        }
    }
}
