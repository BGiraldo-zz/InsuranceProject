using Insurance.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.AggregatesModel.PolicyAggregate
{
    public class Policy : IAggregateRoot
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public CoveringTypedEnum CoveringType { get; set; }

        public double Coverage { get; set; }

        public DateTime TermBeginning { get; set; }

        public int CoverageOnMonths { get; set; }

        public double Price { get; set; }

        public RiskTypeEnum RiskType { get; set; }

        public Policy()
        {
        }

        public Policy(int id, string name, string description, CoveringTypedEnum coveringType, double coverage, DateTime termBeginning, int coverageOnMonths, double price, RiskTypeEnum riskType)
        {
            Id = id;
            Name = name;
            Description = description;
            CoveringType = coveringType;
            Coverage = coverage;
            TermBeginning = termBeginning;
            CoverageOnMonths = coverageOnMonths;
            Price = price;
            RiskType = riskType;
        }
    }
}
