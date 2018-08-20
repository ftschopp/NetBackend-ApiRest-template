using System.Collections.Generic;

namespace Backend.BusinessLogic.DTO.Request
{
    public class CountryRequestDTO
    {
        public string Name { get; set; }

        public List<StateRequestDTO> States {get;set;}
    }
}