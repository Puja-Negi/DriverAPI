using AutoMapper;
using Driver.DataService.Repositories.Interfaces;
using Driver.Entities.DbSet;
using Driver.Entities.Dtos.Requests;
using Driver.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DriverAPI.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver == null)
                return NotFound();

            var result = _mapper.Map<GetDriverResponse>(driver);
            return Ok(result);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver.Entities.DbSet.Driver>(driver);

            await _unitOfWork.Drivers.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver.Entities.DbSet.Driver>(driver);

            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

            [HttpGet]
            public async Task<IActionResult> GetAllDriver()
            {
                var driver = await _unitOfWork.Drivers.All();

                return Ok(_mapper.Map<IEnumerable<GetDriverResponse>>(driver));
            }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
           var driver = await _unitOfWork.Drivers.GetById(driverId);

            if(driver == null)
                return NotFound();
            await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
