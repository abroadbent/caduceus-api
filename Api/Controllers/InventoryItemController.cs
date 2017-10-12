using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models.Domain.Inventory;
using Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize(Policy = "User"), Route("api/[controller]")]
    public class InventoryItemController : Controller
    {
        private readonly IInventoryItemService _service;

        public InventoryItemController(IInventoryItemService service)
        {
            this._service = service;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Disable(id);

            return new NoContentResult();
        }

        [HttpGet]
        public async Task<ActionResult> Get(InventoryItemFilter filter)
        {
            var items = await _service.Collection(filter);

            return new OkObjectResult(items);
		}

        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var item = await _service.Single(id);

			return new OkObjectResult(item);
		}

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]InventoryItem model)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var item = await _service.Update(model);

			return new OkObjectResult(item);
        }

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]InventoryItem model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var item = await _service.Create(model);

			return new OkObjectResult(item);
		}
    }
}
