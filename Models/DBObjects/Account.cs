using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class Account
    {
        public Account()
        {
            InvestmentTransactions = new HashSet<InvestmentTransaction>();
            Transactions = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? AccountName { get; set; }
        public long? AccountType { get; set; }
        public long? AcountNo { get; set; }
        public long? CurrentBalance { get; set; }
        public long? CurrencyId { get; set; }

        public virtual AccountType? AccountTypeNavigation { get; set; }
        public virtual Currency? Currency { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<InvestmentTransaction> InvestmentTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

