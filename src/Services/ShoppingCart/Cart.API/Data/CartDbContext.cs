using ShoppingCart.API.Data;
using LiteDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.API.Entities;

namespace ShoppingCart.API.Data
{
    
    public class CartDbContext : ICartDbContext
    {
        public LiteDatabase Database { get; }
        public ILiteCollection<Cart> Cart;
        public CartDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
            Cart = Database.GetCollection<Cart>("Cart");
            CartContextSeed.SeedData(Cart);
        }
    }
}
