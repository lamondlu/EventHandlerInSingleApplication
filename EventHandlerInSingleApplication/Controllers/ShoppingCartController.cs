using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventHandlerInSingleApplication.BLL;
using EventHandlerInSingleApplication.Models.DTOs;
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

        [HttpPost]
        [Route("{shoppingCartId}/Items")]
        public IActionResult AddItemToShoppingCart([FromBody]AddItemToShoppingCartDTO dto)
        {
            try
            {
                _shoppingCartManager.AddItemToShoppingCart(dto.ShoppingCartId, dto.ItemId);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.ToString() });
            }
        }

        [HttpPut]
        [Route("{shoppingCartId}")]
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
