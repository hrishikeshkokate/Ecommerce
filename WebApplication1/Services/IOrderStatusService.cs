using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IOrderStatusService
    {
        IEnumerable<OrderStatus> GetAllOrderStatus();
        OrderStatus GetOrderStatusById(int id);
        int AddOrderStatus(OrderStatus orderStatus);
        int EditOrderStatus(OrderStatus orderStatus);
        int DeleteOrderStatus(int id);
    }
}
