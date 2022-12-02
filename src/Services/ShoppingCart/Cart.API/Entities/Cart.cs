using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using System;

namespace ShoppingCart.API.Entities
{
    
    public class Cart
    {
        public Guid CartId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public Cart()
        {
        }   

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
