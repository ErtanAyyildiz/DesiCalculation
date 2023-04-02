using Enoca.Entity.Modals;
using FluentValidation;

namespace Enoca.Business.Validators
{
    public class CarriersValidator : AbstractValidator<Carrier>
    {
        public CarriersValidator()
        {
            RuleFor(carrier => carrier.CarrierName)
                .NotEmpty()
                .WithMessage("Kargo İsmi Boş Olamaz");

            RuleFor(carrier => carrier.CarrierIsActive)
                .NotEmpty()
                .WithMessage("Kargo Aktifliği boş olamaz");

            RuleFor(carrier => carrier.CarrierPlusDesiCost)
                .NotEmpty()
                .WithMessage("Kargo + Desi maliyeti bos olamaz");

        }
    }
}
