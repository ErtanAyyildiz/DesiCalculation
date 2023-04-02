using Enoca.Entity.Modals;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Validators
{
    public class CarrierConfigurationValidator : AbstractValidator<CarrierConfiguration>
    {
        public CarrierConfigurationValidator()
        {
            RuleFor(cConfig => cConfig.CarrierMaxDesi)
                .NotEmpty()
                .WithMessage("Kargonun Maksimum desi alanı boş olamaz.!");
            
            RuleFor(cConfig => cConfig.CarrierMinDesi)
                .NotEmpty()
                .WithMessage("Kargonun Minumum desi alanı boş olamaz.!");

            RuleFor(cConfig => cConfig.CarrierCost)
                .NotEmpty()
                .WithMessage("Kargonun maliyeti boş olamaz.!");

        }
    }
}
