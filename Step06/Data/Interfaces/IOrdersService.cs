using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmailAddress);

        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);

    }
}
