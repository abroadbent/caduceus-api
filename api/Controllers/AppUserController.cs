using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Api.Models.System;
using Api.Models.Domain.AppUser;
using System.Text;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _service;

        public AppUserController(IAppUserService service)
        {
            this._service = service;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.Disable(id);

            return new NoContentResult();
        }

        [HttpGet]
        public async Task<ActionResult> Get(AppUserFilter filter)
        {
            var users = await _service.Collection(filter);

            return new OkObjectResult(users);
		}

        [HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{
			var user = await _service.Single(id);

			return new OkObjectResult(user);
		}

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _service.Login(model);

            return new OkObjectResult(token);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]EditableAppUserViewModel model)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await _service.Update(model);

			return new OkObjectResult(user);
        }

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
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
