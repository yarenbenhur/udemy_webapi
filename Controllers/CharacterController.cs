using Microsoft.AspNetCore.Mvc;
using uwebapi.Models;
using uwebapi.Services.CharacterService;

namespace uwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterservice;

        public CharacterController(ICharacterService characterservice)
        {
            _characterservice = characterservice;

        }

        [HttpGet]
        [Route("GetAll")]
        //[HttpGet("GetAll")]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterservice.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id)
        {

            return Ok(await _characterservice.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            return Ok(await _characterservice.AddCharacter(newCharacter));


        }
    }
}