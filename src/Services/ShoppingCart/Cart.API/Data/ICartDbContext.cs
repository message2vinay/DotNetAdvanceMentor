using LiteDB;

namespace ShoppingCart.API.Data
{
    public interface ICartDbContext
    {
        LiteDatabase Database { get; }
    }
}
