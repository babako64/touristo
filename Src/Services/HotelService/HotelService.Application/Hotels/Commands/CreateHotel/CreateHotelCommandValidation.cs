using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HotelService.Application.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandValidation : AbstractValidator<CreateHotelCommand>
    {

        public CreateHotelCommandValidation()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty().WithMessage("{Name} is require");
            RuleFor(model => model.CityCode).NotEmpty().WithMessage("{CityCode} is require").
                MaximumLength(3).WithMessage("{CityCode} must not be greater than 3");
            RuleFor(model => model.Rate).NotEmpty().WithMessage("{Name} is require");
        }

    }
}
