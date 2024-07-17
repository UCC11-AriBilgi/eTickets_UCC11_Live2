using eTickets.Data.Cart;
using eTickets.Data.Interfaces;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            //string userId = "";
            //string userRole = "";

            //var orders= await _ordersService.GetAll();//



            return View();
        }

        public IActionResult ShoppingCart()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            // viewmodel hazırlama

            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response); // ShoppingCart Summary.




        }
    }
}
