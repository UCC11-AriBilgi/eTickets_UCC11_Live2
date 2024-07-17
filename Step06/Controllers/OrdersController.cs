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
            string userId = "";
            string userRole = "";

            var orders= await _ordersService.GetOrderByUserIdAndRoleAsync(userId,userRole);//



            return View(orders);
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

        // 63
        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction("ShoppingCart");
        }

        //65
        public async Task<IActionResult> CompleteOrder()
        {
            // ShoppingCart daki itemların neler olduğunu öğreneyim.
            var items = _shoppingCart.GetShoppingCartItems();

            string userId = "";
            string userEmailAddress = "";

            // Bunları sipariş servisine gönderelim
            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

            // Şu anki ShoppingCart içeriğini temizle yapalım ki yeni siparişler için boş olsun.
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
