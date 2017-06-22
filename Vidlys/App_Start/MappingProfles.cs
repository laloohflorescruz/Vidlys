using AutoMapper;
using Vidlys.DTO;
using Vidlys.Models;

namespace Vidlys.App_Start
{
    public class MappingProfles : Profile
    {
        public MappingProfles()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershiptypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
        }
    }
}