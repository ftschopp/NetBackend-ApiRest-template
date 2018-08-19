using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Domain.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country FindByName(string name);
        Task<Country> FindByNameAsync(string name);
        Task<Country> FindByNameAsync(CancellationToken cancellationToken, string name);
    }
}
