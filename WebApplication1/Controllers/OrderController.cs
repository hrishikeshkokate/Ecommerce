using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;


        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;

        }
        public IActionResult OrderSuccess()
        {
            return View();
        }


    }
}
