using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArkController : ControllerBase
    {
        private readonly ILogger<ArkController> _logger;
        private readonly IArkRepository _arkRepository;

        public ArkController(ILogger<ArkController> logger, IArkRepository repository)
        {
            _logger = logger;
            _arkRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Arks>> GetArks()
        {
            return Ok(_arkRepository.GetAllArks());
        }

        [HttpGet]
        [Route("{arkId:int}")]
        public ActionResult<Arks> GetArkById(int arkId)
        {
            var ark = _arkRepository.GetArkById(arkId);
            if (ark == null)
            {
                return NotFound();
            }
            return Ok(ark);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public ActionResult<User> GetUserById(int userId)
        {
            var user = _arkRepository.GetUserById(userId);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Arks> CreateArk(Arks ark)
        {
            if (!ModelState.IsValid || ark == null)
            {
                return BadRequest();
            }
            var newArk = _arkRepository.CreateArk(ark);
            return Created(nameof(GetArkById), newArk);
        }

        [HttpPut]
        [Route("{arkId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Arks> UpdateArk(Arks ark)
        {
            if (!ModelState.IsValid || ark == null)
            {
                return BadRequest();
            }
            return Ok(_arkRepository.UpdateArk(ark));
        }

        [HttpDelete]
        [Route("{arkId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteArk(int arkId)
        {
            _arkRepository.DeleteArkById(arkId);
            return NoContent();
        }
    }
}
