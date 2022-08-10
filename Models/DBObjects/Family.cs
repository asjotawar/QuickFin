using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class Family
    {
        public Family()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string? FamilyName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
