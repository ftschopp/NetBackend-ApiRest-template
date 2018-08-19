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
    internal class StateRepository : Repository<State>, IStateRepository
    {
        internal StateRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public State FindByName(string name)
        {
            return Set.FirstOrDefault(x => x.Name == name);
        }

        public Task<State> FindByNameAsync(string name)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<State> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string name)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }       
    }
}
