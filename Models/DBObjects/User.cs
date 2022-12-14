using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuickFin.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public long Id { get; set; }
        public long? FamilyId { get; set; }
        public string? FullName { get; set; }
        public string? EmailId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Password { get; set; }

        public virtual Family? Family { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}