using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class State
    {
        #region Fields
        private ICollection<City> _cities;
        private Country _country;
        #endregion

        #region Scalar Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Country_Id { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Country Country
        {
            get { return _country; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _country = value;
                Country_Id = value.Id;
            }
        }
        public virtual ICollection<City> Cities
        {
            get { return _cities ?? (_cities = new List<City>()); }
            set { _cities = value; }
        }
        #endregion
    }
}
