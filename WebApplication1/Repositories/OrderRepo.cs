﻿using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext db;

        public OrderRepo(ApplicationDbContext db)
        {
            this.db = db;
        }



        public IEnumerable<Orders> GetOrders(int userId)
        {
            //return db.Orders.Where(o => o.UserId == userId).ToList();

            var orders = from order in db.Orders
                         where order.UserId == userId
                         //join orderitem in db.OrderItems on order.OrderId equals orderitem.OrderId
                         //join orderstatus in db.OrderStatus on orderitem.OrderStatusId equals orderstatus.OrderStatusId
                         select new Orders
                         {
                             OrderId = order.OrderId,
                             UserId = order.UserId,
                             OrderDate = order.OrderDate,
                             TotalAmount = order.TotalAmount,
                             OrderItems = (from item in db.OrderItems
                                           where item.OrderId == order.OrderId
                                           join status in db.OrderStatus on item.OrderStatusId equals status.OrderStatusId
                                           join p in db.Products on item.ProductId equals p.ProductId
                                           select new OrderItems
                                           {
                                               OrderItemId = item.OrderItemId,
                                               OrderId = item.OrderId,
                                               ProductId = item.ProductId,
                                               OrderStatusId = item.OrderStatusId,
                                               Quantity = item.Quantity,
                                               Price = item.Price,
                                               ProductName = p.ProductName,
                                               ProductImage = p.Image,
                                               OrderStatus = new OrderStatus
                                               {
                                                   OrderStatusId = status.OrderStatusId,
                                                   Status = status.Status
                                               }
                                           }).ToList()
                         };

            return orders.ToList();
        }
        public IEnumerable<Orders> GetAllOrders()
        {
            var orders = from order in db.Orders
                         select new Orders
                         {
                             OrderId = order.OrderId,
                             UserId = order.UserId,
                             OrderDate = order.OrderDate,
                             TotalAmount = order.TotalAmount,
                             OrderItems = (from item in db.OrderItems
                                           where item.OrderId == order.OrderId
                                           join status in db.OrderStatus on item.OrderStatusId equals status.OrderStatusId
                                           join p in db.Products on item.ProductId equals p.ProductId
                                           select new OrderItems
                                           {
                                               OrderItemId = item.OrderItemId,
                                               OrderId = item.OrderId,
                                               ProductId = item.ProductId,
                                               OrderStatusId = item.OrderStatusId,
                                               Quantity = item.Quantity,
                                               Price = item.Price,
                                               ProductName = p.ProductName,
                                               ProductImage = p.Image,
                                               OrderStatus = new OrderStatus
                                               {
                                                   OrderStatusId = status.OrderStatusId,
                                                   Status = status.Status
                                               }
                                           }).ToList()
                         };

            return orders.ToList();

        }

        public int UpdateOrderStatus(int orderItemId, int orderStatusId)
        {
            var orderItem = db.OrderItems.FirstOrDefault(item => item.OrderItemId == orderItemId);
            if (orderItem != null)
            {
                orderItem.OrderStatusId = orderStatusId;
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
