using Backend.Data.EntityFramework.Repositories;
using Backend.Domain;
using Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
       
        private ICountryRepository _countryRepository;
        private IStateRepository _stateRepository;
        private ICityRepository _cityRepository;
       
        #endregion

        #region Constructors
        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new ApplicationDbContext(nameOrConnectionString);
            _context.Database.Log = sql => Debug.Write(sql);
        }
        #endregion

        #region IUnitOfWork Members
        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public ICountryRepository CountryRepository
        {
            get { return _countryRepository ?? (_countryRepository = new CountryRepository(_context)); }
        }

        public IStateRepository StateRepository
        {
            get { return _stateRepository ?? (_stateRepository = new StateRepository(_context)); }
        }

        public ICityRepository CityRepository
        {
            get { return _cityRepository ?? (_cityRepository = new CityRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _roleRepository = null;
            _userRepository = null;
            _countryRepository = null;
            _stateRepository = null;
            _cityRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
