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
            ISession session= services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId= session.GetString("CartId") ?? Guid.NewGuid().ToString(); // CardId isimli Sessiondan ben herhangi bir bilgi alamıyorsam bunu yeni oluştur.

            session.SetString("CartId", cartId); // Session a CartId yi yerleştir.

            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

    }
}
