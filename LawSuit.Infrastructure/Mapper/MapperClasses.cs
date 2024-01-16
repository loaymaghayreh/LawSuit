using AutoMapper;
using LawSuit.Domain.Dto;
using LawSuit.Domain.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Infrastructure.Mapper
{
    public class MapperClasses : Profile
    {
        public MapperClasses() 
        {
            //Complaint
            CreateMap<ComplaintDto, Complaint>().ReverseMap();

            //Attachment
            CreateMap<AttachmentDto, Attachment>().ReverseMap();

            //User
            CreateMap<UserDto, User>().ReverseMap();

            //Administrator
            CreateMap<AdministratorDto, Administrator>().ReverseMap();

            //Demand
            CreateMap<DemandsDto, Demand>().ReverseMap();
        }

    }
}
