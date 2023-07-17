using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        #region constractor
        private readonly IBasketRepository _basket;
        public BasketController(IBasketRepository basket)
        {
            _basket = basket;

        }
        #endregion

        #region get basket
        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(type: typeof(ShoppingCart), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _basket.GetUserBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }
        #endregion

        #region update basket
        [HttpPost]
        [ProducesResponseType(type: typeof(ShoppingCart), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            var result = await _basket.UpdateBasket(basket);
            return Ok(result);
        }
        #endregion

        #region delete basket
        [HttpDelete("{userName}", Name = "DeleteBascket")]
        [ProducesResponseType(type: typeof( void), statusCode:(int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basket.DeleteBasket(userName);
            return Ok();
        }
        #endregion
    }

}
