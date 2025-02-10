using ES_Backend.Models;
using FluentValidation;
namespace ES_Backend.Validation
{
    public class BillValidation : AbstractValidator<BillModel>
    {
        public BillValidation()
        {
            RuleFor(m => m.Amount).NotEmpty();
            RuleFor(m => m.Discount).NotEmpty();
            RuleFor(m => m.TotalAmount).NotEmpty();
            RuleFor(m => m.OrderId).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
        }
    }
}
