using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Entities;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartRepository _cartRepository;

        public CartController(ILogger<CartController> logger, ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<Cart> GetCart()
        //{
        //    return _cartRepository.GetCart();
        //}

        [HttpGet(Name = "GetCartItem")]
        public ActionResult<IEnumerable<CartItem>> GetCartItem()
        {
            var result = _cartRepository.GetCartItems();
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<CartItem> Insert(CartItem cartItem)
        {
            _cartRepository.CreateCartItem(cartItem);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<CartItem> Delete(int id)
        {
            var result = _cartRepository.DeleteCartItem(id);
            if (result > 0)
                return Ok("Item Removed");
            else
                return NotFound();
        }
    }
}