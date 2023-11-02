using FormulaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAPI.Controllers
{
    [ApiController]
    [Route(template:"[controller]")]
    public class DriversController : ControllerBase
    {
        private static List<Driver> _drivers = new List<Driver>()
        {
            new Driver()
            {
            Id = 1,
            Name = "Test",
            Team = "Team1",
            DriverNumber=213
            },
            new Driver()
            {
                Id= 2,
                Name = "Test1231233",
                Team ="asfasfeaa",
                DriverNumber=1239123
            },
            new Driver()
            {
                Id= 2123,
                Name = "asfas",
                Team ="team3",
                DriverNumber=21
            }


        };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_drivers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_drivers.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [Route(template:"Add Driver")]
        public IActionResult AddDriver(Driver driver)
        {
            _drivers.Add(driver);
            return Ok();
        }
        [HttpDelete]
        [Route(template:"Delete Driver")]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(x=> x.Id == id);

            if(driver == null)
            {
                return NotFound();

            }
            _drivers.Remove(driver);
            return NoContent();
        }
        [HttpPatch]
        [Route(template:"Update Driver")]
        public IActionResult UpdateDriver(Driver driver)
        {
            var existDriver = _drivers.FirstOrDefault(x => x.Id == driver.Id);

            if(existDriver == null)
            {
                return NotFound();
            }
            existDriver.Name=driver.Name;
            existDriver.DriverNumber=driver.DriverNumber;
            existDriver.Team=driver.Team;
            return NoContent();
        }
    }
}
