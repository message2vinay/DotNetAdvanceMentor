using LiteDB;
using ShoppingCart.API.Entities;

namespace ShoppingCart.API.Data
{
    public class CartContextSeed
    {
        public static void SeedData(ILiteCollection<Cart> cartCollection)
        {
            bool existProduct = cartCollection.Find(p => true).Any();
            if (!existProduct)
            {
                cartCollection.Insert(GetPreconfiguredCart());
            }
        }

        private static Cart GetPreconfiguredCart()
        {
            return new Cart
            {
                CartId = Guid.NewGuid(),
                Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Id = 1,
                        Name = "IPhone X",
                        Quantity = 1,
                        Image = new Image { URL = "product-1.png" },
                        Price = 950.00M
                    },
                    new CartItem()
                    {
                        Id = 2,
                        Name = "Samsung 10",
                        Quantity = 1,
                        Image = new Image { URL = "product-2.png" },
                        Price = 840.00M
                    },
                    new CartItem()
                    {
                        Id = 3,
                        Name = "Huawei Plus",
                        Image = new Image { URL = "product-3.png" },
                        Price = 650.00M,
                    },
                    new CartItem()
                    {
                        Id = 4,
                        Name = "Xiaomi Mi 9",
                        Quantity = 2,
                        Image = new Image { URL = "product-4.png" },
                        Price = 470.00M,
                    },
                    new CartItem()
                    {
                        Id = 5,
                        Name = "HTC U11+ Plus",
                        Quantity = 3,
                        Image = new Image { URL = "product-5.png" },
                        Price = 380.00M,
                    }

                }
            };
        }

    }
}

