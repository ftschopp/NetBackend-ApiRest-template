using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class City : EntityBase
    {
        #region Fields
        private State _state;
        #endregion

        #region Scalar Properties
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public Guid State_Id { get; set; }
        #endregion

        #region Navigation Properties
        public virtual State State
        {
            get { return _state; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _state = value;
                State_Id = value.Id;
            }
        }      
        #endregion
    }
}
