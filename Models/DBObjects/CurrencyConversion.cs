using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class CurrencyConversion
    {
        public CurrencyConversion()
        {
            TransferMappings = new HashSet<TransferMapping>();
        }

        public long Id { get; set; }
        public long? SourceCurrencyId { get; set; }
        public long? DestinationCurrencyId { get; set; }

        public virtual Currency? DestinationCurrency { get; set; }
        public virtual Currency? SourceCurrency { get; set; }
        public virtual ICollection<TransferMapping> TransferMappings { get; set; }
    }
}
