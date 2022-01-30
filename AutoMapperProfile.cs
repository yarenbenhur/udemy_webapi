using AutoMapper;
using uwebapi.Dtos.Character;
using uwebapi.Models;

namespace uwebapi
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDTo,Character>();
        }
    }
}