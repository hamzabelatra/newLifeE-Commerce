using newLife.DataAccess.Repositry.IRepositry;
using newLife.DataAcess.Data;
using newLife.Models;

namespace newLife.DataAccess.Repositry
{
    public class CoverTypeRepositry : Repositry<CoverTyper>, ICoverTypeRepositry
    {
        private ApplicationDbContext _db;
        public CoverTypeRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CoverTyper obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
