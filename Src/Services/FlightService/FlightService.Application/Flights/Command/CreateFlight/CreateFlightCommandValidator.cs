using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FlightService.Application.Flights.Command.CreateFlight
{
    public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
    {
        public CreateFlightCommandValidator()
        {
            RuleFor(model => model.SeatAvailable).
                NotNull().NotEmpty().WithMessage("{seatAvailable} is require")
                .GreaterThanOrEqualTo(0).WithMessage("{SeatAvailable} must not be less than 0");

            RuleFor(model => model.FromDate).NotNull().NotEmpty().WithMessage("{FromDate} is require");

            RuleFor(model => model.ToDate).
                NotNull().NotEmpty().WithMessage("{ToDate} is require")
                .GreaterThanOrEqualTo(model => model.FromDate).WithMessage("{ToDate} should be greater than or equal to {FromDate}");


            RuleForEach(model => model.Sections).ChildRules(section =>
            {
                section.RuleFor(s => s.FlightNumber).NotNull().NotEmpty().WithMessage("{FlightNumber} is require");
                section.RuleFor(s => s.OriginCityCode).NotNull().NotEmpty().WithMessage("{OriginCityCode} is require");
                section.RuleFor(s => s.DestinationCityCode).NotNull().NotEmpty().WithMessage("{DestinationCityCode} is require");
                section.RuleFor(s => s.Price).NotNull().NotEmpty().WithMessage("{Price} is require").GreaterThan(0)
                    .WithMessage("{Price} must be greater than 0");
            });
        }

    }
}
