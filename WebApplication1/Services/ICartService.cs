﻿using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICartService
    {
        bool CheckIfExists(Cart cart);
        public int AddToCart(Cart cart);
        public IEnumerable<ProductCart> GetCartItems(int userid);

        public int RemoveFromCart(int id);

        public ProductCart ConfirmOrder(int id);

        public int PlaceOrder(Orders order);

        public int RemoveFromCartAfterOrder(int userid, int productid);

        public int GetCartCount(int userid);

        int UpdateQuantity(int cartId, int quantity);

    }
}
