using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface ICoverTypeRepositry : IRepositry<CoverTyper>
    {
        void Update(CoverTyper obj);
    }
}
