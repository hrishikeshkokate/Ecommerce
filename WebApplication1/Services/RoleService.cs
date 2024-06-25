using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo repo;

        public RoleService(IRoleRepo repo)
        {
            this.repo = repo;
        }
        public IEnumerable<Role> GetRoles()
        {
            return repo.GetRoles();
        }
    }
}
