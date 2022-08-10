using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class InvestmentTransaction
    {
        public long Id { get; set; }
        public byte[]? TransactionTime { get; set; }
        public long? AccountId { get; set; }
        public string? EquityName { get; set; }
        public long? TransactionType { get; set; }
        public double? Price { get; set; }
        public long? Quantity { get; set; }
        public string? Description { get; set; }

        public virtual Account? Account { get; set; }
        public virtual TransactionType? TransactionTypeNavigation { get; set; }
    }
}
