using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface ICategoryRepository : IRepositry<Category>
    {
        void Update(Category obj);


    }
}
