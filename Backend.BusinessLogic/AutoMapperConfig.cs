using AutoMapper;
using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic.DTO.Response;
using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BusinessLogic
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<UserRequestDTO, User>().ReverseMap();
                config.CreateMap<UserResponseDTO, User>().ReverseMap();
                config.CreateMap<RoleResponseDTO, Role>().ReverseMap();

                config.CreateMap<CreateUserRequestDTO, User>().ReverseMap();
            });
        }
    }
}
