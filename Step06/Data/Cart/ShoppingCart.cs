using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Cart
{
    //57
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            // Bu tür işlemlerde bellekte kullanımiçin Session dediğimiz bir yapı kullanılır. Onu tanımlayalım/yerleştirelim.
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); // CardId isimli Sessiondan ben herhangi bir bilgi alamıyorsam bunu yeni oluştur.

            session.SetString("CartId", cartId); // Session a CartId yi yerleştir.

            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        // 57
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // ShoppingCart tablosundaki kayıtlar
            // ?? -- isnull
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Movie)
                .ToList()
                );
        }

        public double GetShoppingCartTotal()
        {
            // ShoppingCart tablosundaki Toplam ücreti verecek.
            var total = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Movie.Price * c.Amount)
                .Sum();

            return total;
        }

        public void AddItemToCart(Movie movie)
        {
            // ShoppingCart a bir item ekleme

            // Öncelikle ilgili Movie daha önceden ShoppingCart a eklenmiş mi??

            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                // Yani film daha önceden sepete atılmamışsa
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++; // daha önceden varsa bir arttır.
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem !=null)
            {
                // Vardır...
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    // eğer 1 tane varda VT den kaldır.
                    _context.ShoppingCartItems.Remove(shoppingCartItem) ;
                }
            }
            _context.SaveChanges();

        }

        // ??
    }
}
