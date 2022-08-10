using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public long Id { get; set; }
        public string? AccountType1 { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
