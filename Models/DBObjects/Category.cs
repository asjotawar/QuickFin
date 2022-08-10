using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class Category
    {
        public Category()
        {
            Transactions = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
