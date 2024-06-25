using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RoleRepo : IRoleRepo
    {
        private readonly ApplicationDbContext db;
        public RoleRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Role> GetRoles()
        {
            var model = (from role in db.Roles
                         select role).ToList();
            return model;
        }
    }
}
