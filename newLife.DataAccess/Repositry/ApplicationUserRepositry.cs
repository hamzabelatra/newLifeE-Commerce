

using newLife.DataAccess.Repositry.IRepositry;
using newLife.DataAcess.Data;
using newLife.Models;

namespace newLife.DataAccess.Repositry
{
    public class ApplicationUserRepositry : Repositry<ApplicationUser>, IApplicationUserRepositry
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepositry(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



    }
}
