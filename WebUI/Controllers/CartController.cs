using Application.CartItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartItemsService _cartServices;

        private readonly ILogger<CartController> _logger;

        public CartController(ICartItemsService cartServices, ILogger<CartController> logger)
        {
            _cartServices = cartServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            try
            {
                var data = _cartServices.GetCartItems(Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something Went Wrong" + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(CartItemDetails cartItem)
        {
            try
            {
                var data = _cartServices.AddCartLineItems(new Domain.Entities.LineItem { Id = cartItem.ProductID, price = cartItem.Price, quantity = 1, title = cartItem.ProductName }, cartItem.CartID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something Went Wrong");

            }

        }

        [HttpDelete]
        public IActionResult Delete(CartItemDetails cartItem)
        {
            try
            {
                var data = _cartServices.RemoveCartLineItems(cartItem.CartID, cartItem.ProductID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something Went Wrong");

            }

        }

        [HttpPost]
        public IActionResult Post(CartItemDetails cartItem)
        {
            try
            {
                var data = _cartServices.CheckOut(cartItem.CartID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something Went Wrong");
            }
        }

    }
}
