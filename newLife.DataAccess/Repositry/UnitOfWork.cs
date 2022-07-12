using newLife.DataAccess.Repositry.IRepositry;
using newLife.DataAcess.Data;

namespace newLife.DataAccess.Repositry
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepositry(_db);
            CoverType = new CoverTypeRepositry(_db);
            Product = new ProductRepositry(_db);
            Company = new CompanyRepositry(_db);
            ApplicationUser = new ApplicationUserRepositry(_db);
            ShoppingCart = new ShoppingCartRepositry(_db);
            OrderHeader = new OrderHeaderRepositry(_db);
            OrderDetail = new OrderDetailRepositry(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepositry CoverType { get; private set; }
        public IProductRepositry Product { get; private set; }
        public ICompanyRepositry Company { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepositry ApplicationUser { get; private set; }
        public IOrderDetailRepositry OrderDetail { get; private set; }
        public IOrderHeaderRepositry OrderHeader { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
