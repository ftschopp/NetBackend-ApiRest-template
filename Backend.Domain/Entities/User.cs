using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class User : EntityBase
    {
        #region Fields
        private ICollection<Role> _roles;
        #endregion

        #region Scalar Properties

        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string SecurityStamp { get; set; }

        public virtual string RefreshToken { get; set; }
        #endregion

        #region Navigation Properties     

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }
        #endregion

        public List<Guid> IdRoles { get; set; }
    }
}
