using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models.Domain.AppUser;
using Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize(Policy = "User"), Route("api/[controller]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _service;

        public AppUserController(IAppUserService service)
        {
            this._service = service;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Disable(id);

            return new NoContentResult();
        }

        [Authorize(Policy = "Admin"), HttpGet]
        public async Task<ActionResult> Get(AppUserFilter filter)
        {
            var users = await _service.Collection(filter);

            return new OkObjectResult(users);
		}

        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var user = await _service.Single(id);

			return new OkObjectResult(user);
		}

        [AllowAnonymous, HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody]AppUserLogin model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _service.Login(model);

            return new OkObjectResult(token);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]AppUserUpdate model)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await _service.Update(model);

			return new OkObjectResult(user);
        }

		[AllowAnonymous, HttpPost]
		public async Task<IActionResult> Post([FromBody]AppUserRegistration model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await _service.Create(model);

			return new OkObjectResult(user);
		}
    }
}
