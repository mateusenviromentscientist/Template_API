using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template_API.Dto;
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

        [HttpGet("{id}", Name = "PlayerById")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            try
            {
                var player = await _services.GetPlayerById(id);
                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(PlayerForCreationDto player)
        {
            try
            {
                var createPlayer = await _services.CreatePlayer(player);
                return Ok(createPlayer);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(PlayerUpdateDto player, int id)
        {
            try
            {
                var updatePlayer = await _services.UpdatePlayer(id, player);
                return Ok(updatePlayer);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                var deletePlayer = await _services.DeletePlayer(id);
                return Ok(deletePlayer);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}