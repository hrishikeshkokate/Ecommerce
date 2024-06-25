using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IOrderRepo
    {
        IEnumerable<Orders> GetOrders(int userId);
        IEnumerable<Orders> GetAllOrders();
        int UpdateOrderStatus(int orderItemId, int orderStatusId);
    }
}
