using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Insurance.Domain.SeedWork;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.AggregatesModel.ClientAggregate
{
    public class Client : IAggregateRoot
    {
        [Key]
        public int ClientId { get; set; }

        [Display(Name = "Identification Number")]
        public int Identification { get; set; }

        [Display(Name = "Client Name")]
        public string CompleteName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<PolicyDetail> PolicyDetails { get; set; }

        public Client()
        {
        }
    }
}
