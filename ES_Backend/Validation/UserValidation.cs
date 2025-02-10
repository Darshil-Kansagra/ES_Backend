using ES_Backend.Models;
using FluentValidation;

namespace ES_Backend.Validation
{
    public class UserValidation : AbstractValidator<UserModel>
    {
        public UserValidation()
        {
            RuleFor(m => m.UserName).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
            RuleFor(m => m.Role).NotEmpty();
            RuleFor(m => m.IsActive).NotEmpty();
        }
    }
}
