using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic.DTO.Response;
using Backend.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using Backend.BusinessLogic.Interfaces;

namespace Backend.BusinessLogic
{
    public class LocationService : BaseService,  ILocationService
    {        
        public LocationService()
            : base()
        {               
        }

        public void Create(CreateLocationRequestDTO dto)
        {
            List<Country> countiesAuxiliares = AutoMapper.Mapper.Map<List<Country>>(dto.Countries);

            //actualizar ref

            foreach(Country c in countiesAuxiliares)
            {
                foreach(State s in c.States)
                {
                    foreach(City city in s.Cities)
                    {
                        city.State = s;                        
                    }

                    s.Country = c;
                }

                this.UnitOfWork.CountryRepository.Add(c);
            }

            this.UnitOfWork.SaveChanges();
        }
    }
}
