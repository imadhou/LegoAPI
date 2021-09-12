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
            CreateMap<Developpeur, DeveloperAdd>();
            CreateMap<DeveloperAdd, Developpeur>();

            CreateMap<Developpeur, DeveloppeurRead>();
            CreateMap<DeveloppeurRead, Developpeur>();

            CreateMap<Developpeur, DeveloperUpdate>();
            CreateMap<DeveloperUpdate, Developpeur>();

            CreateMap<Conge, CongeDTO>();
            CreateMap<CongeDTO, Conge>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceDto, Service>();


            CreateMap<EmployeCongeAddDTO, EmployeConge>()
                .ForMember(e => e.CongeID, c => c.MapFrom(e => e.CongeID));
            CreateMap<EmployeConge, EmployeCongeAddDTO>()
                .ForMember(e => e.CongeID, c => c.MapFrom(e => e.Conge.ID));
               

            CreateMap<EmployeConge, CongeEmplDTO>()
                .ForMember(e => e.CongeDTO, o => o.MapFrom(e => e.Conge));
            CreateMap<CongeEmplDTO, EmployeConge>()
                .ForMember(e => e.Conge, o=> o.MapFrom(e => e.CongeDTO));


            CreateMap<Developpeur, DeveloppeurRead>()
                .ForMember(b => b.Conges, o => o.MapFrom(c => c.EmployeConges));

            

        }
    }
}
