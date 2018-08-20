using Backend.BusinessLogic.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BusinessLogic.Interfaces
{
    public interface ILocationService
    {
        void Create(CreateLocationRequestDTO dto);        
    }
}
