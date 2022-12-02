
using LiteDB;

using ShoppingCart.API;
using ShoppingCart.API.Data;
using ShoppingCart.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly LiteDatabase cartDB;
        ILiteCollection<Cart> Cart;
        Cart currentCart;

        public CartRepository(ICartDbContext context)
        {
            cartDB = context.Database ?? throw new ArgumentNullException(nameof(context));
            Cart = cartDB.GetCollection<Cart>("Cart");
            currentCart = Cart.FindAll().ToList().FirstOrDefault();
        }

        public Cart GetCart()
        {
            return currentCart;
        }
        public IEnumerable<CartItem> GetCartItems()
        {
            return currentCart.Items;
        }
        public void CreateCartItem(CartItem cartItem)
        {
            var existingItems = currentCart.Items;
            existingItems.Add(cartItem);
            currentCart.Items = existingItems;
            Cart.Update(currentCart);
        }
        public int DeleteCartItem(int id)
        {
            var result = currentCart.Items.RemoveAll(x => x.Id==id);
            Cart.Update(currentCart);
            return result;
        }

    }
}
