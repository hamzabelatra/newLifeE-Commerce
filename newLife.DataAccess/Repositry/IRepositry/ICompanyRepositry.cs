using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface ICompanyRepositry : IRepositry<Company>
    {
        void Update(Company obj);
    }
}
