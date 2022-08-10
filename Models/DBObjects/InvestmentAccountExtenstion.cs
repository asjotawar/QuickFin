using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class InvestmentAccountExtenstion
    {
        public long? AccountId { get; set; }
        public double? RealisedPnl { get; set; }
        public double? UnrealisedPnl { get; set; }

        public virtual Account? Account { get; set; }
    }
}
