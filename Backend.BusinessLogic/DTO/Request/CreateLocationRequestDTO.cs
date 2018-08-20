using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BusinessLogic.DTO.Request
{
    public class CreateLocationRequestDTO
    {
        public List<CountryRequestDTO> Countries { get; set; }
    }
}
