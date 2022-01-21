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
        public ActionResult<Character> Get()
        {
            return Ok(_characterservice.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {

            return Ok(_characterservice.GetCharacterById(id));
        }
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            return Ok(_characterservice.AddCharacter(newCharacter));


        }
    }
}