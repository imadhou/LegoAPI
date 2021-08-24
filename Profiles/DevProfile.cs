using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoApi.Models;
using LegoApi.DTO;

namespace LegoApi.Profiles
{
    public class DevProfile: Profile
    {
        public DevProfile()
        {
            CreateMap<Developpeur, DevCr>();
            CreateMap<DevCr, Developpeur>();


            CreateMap<Conge, CongeDTO>();
            CreateMap<CongeDTO, Conge>();

            CreateMap<EmployeConge, CongeEmplDTO>()
                .ForMember(e => e.CongeDTO, o => o.MapFrom(e => e.Conge));
            CreateMap<CongeEmplDTO, EmployeConge>();


            CreateMap<Developpeur, DeveloppeurRead>()
                .ForMember(b => b.Conges, o => o.MapFrom(c => c.EmployeConges));

        }
    }
}
