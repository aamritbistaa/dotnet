using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHero()
        {
            var result = _superHeroService.GetAllSuperHero();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetByID(int id)
        {
            try
            {

            var result = _superHeroService.GetByID(id);
            if (result == null)
            {
                return NotFound("Item doesnot exist");
            }
            else
            {
                return Ok(result);
            }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero obj)
        {
            try
            {
                _superHeroService.AddSuperHero(obj);
                return Ok(obj);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero request)
        {
            try
            {
                var result = _superHeroService.UpdateSuperHero(id,request);
                if (result == null)
                    return NotFound("Item does not exist");
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            try
            {
                var result = _superHeroService.DeleteSuperHero(id);
                if (result == null)
                    return NotFound("Item does not exist");
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
