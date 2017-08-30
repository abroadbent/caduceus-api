using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Api.Models.System;
using Api.Models.Domain.AppUser;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AppUserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public AppUserController(IMapper mapper, ApplicationDbContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<AppUser>(model);
            _db.AppUsers.Add(user);
            await _db.SaveChangesAsync();

            return new OkResult();
        }
    }
}
