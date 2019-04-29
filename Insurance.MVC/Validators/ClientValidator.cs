using FluentValidation;
using Insurance.Domain.AggregatesModel.ClientAggregate;
using System.Linq;

namespace Insurance.MVC.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {

        private readonly IClientRepository _context;

        public ClientValidator(IClientRepository context)
        {
            this._context = context;
            RuleFor(x => x.Identification).Must(BeUniqueId);
        }

        private bool BeUniqueId(int id)
        {
            return _context.GetAll().FirstOrDefault(x => x.Identification == id) == null;
        }
    }
}