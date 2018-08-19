using Backend.Data.EntityFramework;
using System;
using System.Threading;

namespace Backend.BusinessLogic
{
    public class BaseService
    {
        private UnitOfWork unitOfWork;
        public BaseService()
        {
            
        }

        protected UnitOfWork UnitOfWork
        {
            get
            {
                return LazyInitializer.EnsureInitialized<UnitOfWork>(ref this.unitOfWork, () => new UnitOfWork("BackendDB"));
            }
        }
        
    }
}