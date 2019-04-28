using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Insurance.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.AggregatesModel.PolicyAggregate
{
    public class Policy : IAggregateRoot
    {
        [Key]
        public int PolicyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Covering Type")]
        public CoveringTypedEnum CoveringType { get; set; }

        public decimal Coverage { get; set; }

        [Display(Name = "Term of the policy")]
        public DateTime TermBeginning { get; set; }

        [Display(Name = "Coverage on Months")]
        public int CoverageOnMonths { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Risk Type")]
        public RiskTypeEnum RiskType { get; set; }

        public virtual ICollection<PolicyDetail> PolicyDetails { get; set; }

        public Policy()
        {
        }
    }
}
