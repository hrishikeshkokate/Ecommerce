using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IOrderService
    {

        IEnumerable<Orders> GetOrders(int userId);
        IEnumerable<Orders> GetAllOrders();
        int UpdateOrderStatus(int orderItemId, int orderStatusId);
    }
}
