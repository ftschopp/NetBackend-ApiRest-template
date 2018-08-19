using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.EntityFramework.Repositories
{
    internal class CityRepository : Repository<City>, ICityRepository
    {
        internal CityRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public City FindByName(string name)
        {
            return Set.FirstOrDefault(x => x.Name == name);
        }

        public Task<City> FindByNameAsync(string name)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<City> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string name)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }

        public City FindBy(Guid stateId, string name)
        {
            return Set.Where(x => x.State_Id == stateId && x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
    }
}
