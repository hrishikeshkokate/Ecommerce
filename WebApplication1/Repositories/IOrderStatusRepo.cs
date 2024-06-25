﻿using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IOrderStatusRepo
    {
        IEnumerable<OrderStatus> GetAllOrderStatus();
        OrderStatus GetOrderStatusById(int id);
        int AddOrderStatus(OrderStatus orderStatus);
        int EditOrderStatus(OrderStatus orderStatus);
        int DeleteOrderStatus(int id);
    }
}
