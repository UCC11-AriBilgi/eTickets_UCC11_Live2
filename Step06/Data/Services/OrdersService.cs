using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    //59
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            // UserId ve Role durumuna göre siparişleri getirecek.

            var orders = await _context.Orders
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Movie)
                .Where(n => n.UserId == userId)
                .ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            // Yapılan siparişin VT tarafına store edilmesi
            // Master-detail yapısı

            //Master
            var order = new Order()
            {
                UserId =userId,
                Email=userEmailAddress
            };

            await _context.Orders.AddAsync(order); // VT tarafına master kayıt eklendi

            await _context.SaveChangesAsync();

            // Detail
            foreach (var item in items) 
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId= order.Id,
                    Price = item.Movie.Price
                };

                await _context.OrderItems.AddAsync(orderItem);
            }


            await _context.SaveChangesAsync(); // VT tarafına detail kayıt eklendi
        }
    }
}
