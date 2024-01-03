using AutoMapper;
using Driver.DataService.Repositories;
using Driver.DataService.Repositories.Interfaces;
using Driver.Entities.DbSet;
using Driver.Entities.Dtos.Requests;
using Driver.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DriverAPI.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

            //check if driver exits
            if(driverAchievements == null) 
                return NotFound("Achievements not found");

            var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);
            return Ok(result);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
