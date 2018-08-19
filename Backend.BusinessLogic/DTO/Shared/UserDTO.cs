﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BusinessLogic.DTO.Shared
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
