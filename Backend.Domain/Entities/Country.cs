using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class Country : EntityBase
    {
        #region Fields
        private ICollection<State> _states;
        #endregion

        #region Scalar Properties
        public string Name { get; set; }

        #endregion

        #region Navigation Properties
        public virtual ICollection<State> States
        {
            get { return _states ?? (_states = new List<State>()); }
            set { _states = value; }
        }

        #endregion
    }
}
