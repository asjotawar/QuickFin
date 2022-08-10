using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            InvestmentTransactions = new HashSet<InvestmentTransaction>();
            Transactions = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string? TransactionName { get; set; }

        public virtual ICollection<InvestmentTransaction> InvestmentTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
