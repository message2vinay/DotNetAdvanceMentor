using ShoppingCart.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface ICartRepository
    {
        Cart GetCart();
        IEnumerable<CartItem> GetCartItems();
        void CreateCartItem(CartItem CartItem);
        int DeleteCartItem(int id);         
    }
}
