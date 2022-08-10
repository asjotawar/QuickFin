using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Accounts = new HashSet<Account>();
            CurrencyConversionDestinationCurrencies = new HashSet<CurrencyConversion>();
            CurrencyConversionSourceCurrencies = new HashSet<CurrencyConversion>();
        }

        public long Id { get; set; }
        public string? CurrencyName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<CurrencyConversion> CurrencyConversionDestinationCurrencies { get; set; }
        public virtual ICollection<CurrencyConversion> CurrencyConversionSourceCurrencies { get; set; }
    }
}
