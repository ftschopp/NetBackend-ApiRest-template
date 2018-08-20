using System.Collections.Generic;

namespace Backend.BusinessLogic.DTO.Request
{
    public class StateRequestDTO
    {
        public string Name { get; set; }
        public List<CityRequestDTO> Cities { get; set; }
    }
}