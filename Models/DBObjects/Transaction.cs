using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransferMappingDestinationTransactions = new HashSet<TransferMapping>();
            TransferMappingSourceTransactions = new HashSet<TransferMapping>();
        }

        public long Id { get; set; }
        public byte[]? TransactionTime { get; set; }
        public long? AccountId { get; set; }
        public long? TransactionTypeId { get; set; }
        public double? Amount { get; set; }
        public long? CategoryId { get; set; }
        public string? Description { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Category? Category { get; set; }
        public virtual TransactionType? TransactionType { get; set; }
        public virtual ICollection<TransferMapping> TransferMappingDestinationTransactions { get; set; }
        public virtual ICollection<TransferMapping> TransferMappingSourceTransactions { get; set; }
    }
}
