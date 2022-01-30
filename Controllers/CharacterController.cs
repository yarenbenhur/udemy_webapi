using Microsoft.AspNetCore.Mvc;
using uwebapi.Dtos.Character;
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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterservice.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {

            return Ok(await _characterservice.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDTo newCharacter)
        {
            return Ok(await _characterservice.AddCharacter(newCharacter));


        }
    }
}