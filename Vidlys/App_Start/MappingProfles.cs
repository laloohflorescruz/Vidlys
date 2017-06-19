using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidlys.DTO;
using Vidlys.Models;

namespace Vidlys.App_Start
{
    public class MappingProfles : Profile
    {
        public MappingProfles()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}