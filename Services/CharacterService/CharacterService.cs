using AutoMapper;
using Microsoft.EntityFrameworkCore;
using uwebapi.Data;
using uwebapi.Dtos.Character;
using uwebapi.Models;

namespace uwebapi.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
       
        private readonly IMapper _mapper;
        private readonly DataContext _context; 
        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context ;
            _mapper = mapper;

        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data =await _context.Characters.Select(i=> _mapper.Map<GetCharacterDto>(i)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
           var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
           try{
           Character character =await _context.Characters.FirstOrDefaultAsync(c=> c.Id == id);
           _context.Characters.Remove(character);
           await _context.SaveChangesAsync();
           serviceResponse.Data = await _context.Characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToListAsync();
             }
            catch(Exception ex){
                 serviceResponse.Success = false;
                 serviceResponse.Message = ex.Message;
             }
           return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(i=> _mapper.Map<GetCharacterDto>(i)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c=> c.Id == id);

            serviceResponse.Data =_mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
           var serviceResponse = new ServiceResponse<GetCharacterDto>();
           try{

        
           Character character =await _context.Characters.FirstOrDefaultAsync(c=> c.Id == updatedCharacter.Id);
           character.Name = updatedCharacter.Name;
           character.Hitpoints = updatedCharacter.Hitpoints;
           character.Strength = updatedCharacter.Strength;
           character.Defense = updatedCharacter.Defense;
           character.Intelligence = updatedCharacter.Intelligence;
           character.Class = updatedCharacter.Class;
           await _context.SaveChangesAsync();

           serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
             }
             catch(Exception ex){
                 serviceResponse.Success = false;
                 serviceResponse.Message = ex.Message;
             }
           return serviceResponse;

        }
    }
}