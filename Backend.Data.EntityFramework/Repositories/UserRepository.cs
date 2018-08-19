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
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public User FindByEmail(string email)
        {
            return Set.FirstOrDefault(x => x.Email == email);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> FindByEmailAsync(System.Threading.CancellationToken cancellationToken, string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
