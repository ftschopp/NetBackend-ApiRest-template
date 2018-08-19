using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Domain.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        City FindByName(string name);
        Task<City> FindByNameAsync(string name);
        Task<City> FindByNameAsync(CancellationToken cancellationToken, string name);

        City FindBy(Guid stateId, string name);
    }
}
