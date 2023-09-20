
using AutoMapper;
using System;
using WebApplication1.dto;
using WebApplication1.Models;

namespace WebApplication1.helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //  CreateMap<Client,dtoClient>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //   .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            // CreateMap<Employee, dtoCommands>();
            CreateMap<CreateDepartmentrequestDTO, Department>();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<Department, UpdateDepartmentrequestDTO>();
            CreateMap<Employee2dto, Employee>();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeerequestDTO>();
         



        }
    }
}



