using ES_Backend.Models;
using FluentValidation;

namespace ES_Backend.Validation
{
    public class CustomerValidation : AbstractValidator<CustomerModel>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.MobileNo).NotEmpty().Length(10,10).WithMessage("Mobile Number Must Contain 10 Characters");
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
