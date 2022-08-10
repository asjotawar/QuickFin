using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class TransferMapping
    {
        public long Id { get; set; }
        public long? SourceTransactionId { get; set; }
        public long? DestinationTransactionId { get; set; }
        public long? CurrencyConversionId { get; set; }

        public virtual CurrencyConversion? CurrencyConversion { get; set; }
        public virtual Transaction? DestinationTransaction { get; set; }
        public virtual Transaction? SourceTransaction { get; set; }
    }
}
