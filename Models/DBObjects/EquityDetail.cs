using System;
using System.Collections.Generic;

namespace QuickFin.Models
{
    public partial class EquityDetail
    {
        public long? SecurityCode { get; set; }
        public string? IssuerName { get; set; }
        public string? SecurityId { get; set; }
        public string? SecurityName { get; set; }
        public string? Status { get; set; }
        public string? Group { get; set; }
        public long? FaceValue { get; set; }
        public string? Isinno { get; set; }
        public string? Industry { get; set; }
        public string? Instrument { get; set; }
        public string? SectorName { get; set; }
        public string? IndustryNewName { get; set; }
        public string? IgroupName { get; set; }
        public string? IsubgroupName { get; set; }
    }
}
