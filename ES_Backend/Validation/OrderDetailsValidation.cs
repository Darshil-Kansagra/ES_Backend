using ES_Backend.Models;
using FluentValidation;

namespace ES_Backend.Validation
{
    public class OrderDetailsValidation : AbstractValidator<OrderDetailsModel>
    {
        public OrderDetailsValidation()
        {
            RuleFor(m=>m.ProductId).NotEmpty();
            RuleFor(m => m.OrderId).NotEmpty();
            RuleFor(m => m.Quantity).NotEmpty();
            RuleFor(m => m.Amount).NotEmpty();
            RuleFor(m => m.TotalAmount).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
        }
    }
}
