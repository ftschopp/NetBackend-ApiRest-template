using Backend.BusinessLogic.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BusinessLogic.DTO.Response
{
    public class UserResponseDTO : UserDTO
    {        
        public List<RoleResponseDTO> Roles { get; set; }
    }
}
