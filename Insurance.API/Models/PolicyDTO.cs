using Insurance.Domain.AggregatesModel.PolicyAggregate;
using System;

namespace Insurance.API.Models
{
    public class PolicyDTO
    {
        public int PolicyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CoveringTypedEnum CoveringType { get; set; }

        public decimal Coverage { get; set; }

        public DateTime TermBeginning { get; set; }

        public int CoverageOnMonths { get; set; }

        public decimal Price { get; set; }

        public RiskTypeEnum RiskType { get; set; }
    }
}