using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.AggregatesModel.PolicyDetailAggregate
{
    public class PolicyDetail: IAggregateRoot
    {
        [Key]
        public int PolicyDetailId { get; set; }

        [Display(Name = "Policy")]
        public int PolicyId { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name = "Assigned | Cancelled")]
        public bool Status { get; set; }

        public virtual Policy Policy { get; set; }

        public virtual Client Client { get; set; }

        public PolicyDetail()
        {
        }
    }
}
