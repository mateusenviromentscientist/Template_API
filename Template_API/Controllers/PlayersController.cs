using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template_API.Services;

namespace Template_API.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IPlayerServices _services;

        public CompaniesController(IPlayerServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult> GetPlayers()
        {
            try
            {
                var companies = await _services.GetPlayers();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}