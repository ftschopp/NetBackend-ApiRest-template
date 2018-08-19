using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Domain.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
        State FindByName(string name);
        Task<State> FindByNameAsync(string name);
        Task<State> FindByNameAsync(CancellationToken cancellationToken, string name);
    }
}
