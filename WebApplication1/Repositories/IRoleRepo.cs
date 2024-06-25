using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IRoleRepo
    {
        IEnumerable<Role> GetRoles();
    }
}
