using eTickets.Data.Cart;
using eTickets.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        //private readonly IOrdersService _ordersService;





        public async Task<IActionResult> Index()
        {
            //string userId = "";
            //string userRole = "";

            //var orders= await _ordersService.GetAll();//



            return View();
        }
    }
}
