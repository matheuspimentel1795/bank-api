using ApiUserBank.Models;
using AutoMapper;

namespace ApiUserBank.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserBank, UserBankDTO>().ReverseMap();
            
        }
    }
}
