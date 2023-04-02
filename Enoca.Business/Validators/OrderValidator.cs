using Enoca.Entity.Modals;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.OrderDesi)
                .NotEmpty()
                .WithMessage("Lütfen Sipariş Desi boş geçmeyin.");

            RuleFor(order => order.OrderCarrierCost)
                .NotEmpty()
                .WithMessage("Sipariş Carrier Const kısmı boş geçilmez.");

            RuleFor(order => order.OrderDate)
                .NotEmpty()
                .WithMessage("Sipariş Tarihi boş olamaz.");
        }
    }
}
