using System;
using System.Linq;
using System.Threading.Tasks;
using Adapters.Driving.Api.Dtos;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adapters.Driving.Api.Controllers
{
    [ApiController]
    [Route("api/v1/squads")]
    public class SquadController : ControllerBase
    {
        private readonly ISquadService _squadService;
        private readonly SquadDto _squadDto;

        public SquadController(ISquadService squadService)
        {
            _squadService = squadService;
            _squadDto = new SquadDto();
        }

        [HttpGet]
        public IActionResult GetAllSquads()
        {
            try
            {
                var squads = _squadService.GetAllSquads();
                if (squads.Count() <= 0)
                    return NotFound("data not found");

                var squadsResponse = squads.Select(squad => _squadDto.ParseSquadResponse(squad));

                return Ok(squadsResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"{(ex ?? ex.InnerException).Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSquadById(int id)
        {
            try
            {
                var squad = _squadService.GetSquadById(id);
                var squadResponse = _squadDto.ParseSquadResponse(squad);

                return Ok(squadResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"{(ex ?? ex.InnerException).Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSquad(SquadRequest squadRequest)
        {
            try
            {
                var squad = _squadDto.ParseSquadRequest(squadRequest);

                await _squadService.CreateSquad(squad);
                return Ok(new { squad = squadRequest, message = "squad created successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"{(ex ?? ex.InnerException).Message}");
            }
        }
    }
}