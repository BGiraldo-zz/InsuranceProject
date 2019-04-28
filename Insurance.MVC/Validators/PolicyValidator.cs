using FluentValidation;
using Insurance.Domain.AggregatesModel.PolicyAggregate;

namespace Insurance.MVC.Validators
{
    public class PolicyValidator : AbstractValidator<Policy>
    {
        public PolicyValidator()
        {
            When(Policy => Policy.RiskType.Equals(RiskTypeEnum.Alto), () => {
                RuleFor(policy => policy.Coverage).LessThan(50);
            });
        }
    }
}