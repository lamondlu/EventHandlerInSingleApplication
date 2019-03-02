using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventHandlerInSingleApplication.BLL;
using EventHandlerInSingleApplication.Models.DTOs;
using EventHandlerInSingleApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventHandlerInSingleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartManager _shoppingCartManager = null;

        public ShoppingCartController(IShoppingCartManager shoppingCartManager)
        {
            _shoppingCartManager = shoppingCartManager;
        }

        [HttpGet]
        [Route("~/api/items")]
        public List<ItemViewModel> GetItems()
        {
            return _shoppingCartManager.GetAllItems();
        }

        [HttpPost]
        [Route("~/api/ShoppingCarts/{shoppingCartId}/Items")]
        public IActionResult AddItemToShoppingCart(string shoppingCartId, [FromBody]AddItemToShoppingCartDTO dto)
        {
            try
            {
                _shoppingCartManager.AddItemToShoppingCart(shoppingCartId, dto.ItemId);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.ToString() });
            }
        }

        [HttpPost]
        [Route("~/api/shoppingCarts")]
        public IActionResult CreateNewShoppingCart()
        {
            try
            {
                var shoppingCartId = _shoppingCartManager.CreateShoppingCart();
                return StatusCode(201, new { id = shoppingCartId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.ToString() });
            }
        }

        [HttpPut]
        [Route("~/api/shoppingCarts/{shoppingCartId}")]
        public IActionResult SubmitShoppingCart(string shoppingCartId)
        {
            try
            {
                _shoppingCartManager.SubmitShoppingCart(shoppingCartId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.ToString() });
            }
        }
    }
}
