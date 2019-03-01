using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventHandlerInSingleApplication.BLL;
using Microsoft.AspNetCore.Mvc;

namespace EventHandlerInSingleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IShoppingCartManager _shoppingCartManager = null;

        public ValuesController(IShoppingCartManager shoppingCartManager)
        {
            _shoppingCartManager = shoppingCartManager;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _shoppingCartManager.SubmitShoppingCart();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
