using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.SeedWork;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.AggregatesModel.UserAggregate
{
    public class User : IAggregateRoot
    {
        [Key]
        public int Identification { get; set; }

        public string CompleteName { get; set; }

        public string Address { get; set; }

        public UserTypeEnum UserType { get; set; }

        public List<Policy> AggregatedPolicies { get; set; }

        public List<Policy> AssociatedPolicies { get; set; }

        public User()
        {
        }

        public User(int identification, string completeName, string address, UserTypeEnum userType, List<Policy> aggregatedPolicies, List<Policy> associatedPolicies)
        {
            Identification = identification;
            CompleteName = completeName;
            Address = address;
            UserType = userType;
            AggregatedPolicies = aggregatedPolicies;
            AssociatedPolicies = associatedPolicies;
        }
    }
}
