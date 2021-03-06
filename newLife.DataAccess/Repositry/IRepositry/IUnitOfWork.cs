namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepositry CoverType { get; }
        IProductRepositry Product { get; }

        ICompanyRepositry Company { get; }

        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepositry ApplicationUser { get; }
        IOrderDetailRepositry OrderDetail { get; }
        IOrderHeaderRepositry OrderHeader { get; }
        void Save();
    }
}
