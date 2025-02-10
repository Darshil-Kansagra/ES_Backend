using ES_Backend.Models;
using FluentValidation;

namespace ES_Backend.Validation
{
    public class OrderValidation : AbstractValidator<OrderModel>
    {
        public OrderValidation()
        {
            RuleFor(m=>m.Price).NotEmpty();
            RuleFor(m => m.ShippingAddress).NotEmpty();
            RuleFor(m => m.PaymentMode).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
        }
    }
}
