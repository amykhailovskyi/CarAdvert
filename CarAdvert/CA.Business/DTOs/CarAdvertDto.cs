using System;
using FluentValidation;

namespace CA.Business.DTOs
{
    public class CarAdvertDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Title of the advertisement.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Type id of fuel.
        /// </summary>
        public int FuelTypeId { get; set; }

        /// <summary>
        /// The price of car.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Indicates if car is new or used.
        /// </summary>
        public bool New { get; set; }

        /// <summary>
        /// Number of mileages. For used car.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// Date of the first registration. For used car.
        /// </summary>
        public DateTime? FirstRegistration { get; set; }


        public string Fuel { get; set; }
    }

    public class CarAdvertDtoValidator : AbstractValidator<CarAdvertDto>
    {
        public CarAdvertDtoValidator()
        {
            RuleFor(r => r.Title).NotEmpty().MaximumLength(64);
            RuleFor(r => r.FuelTypeId).NotEmpty();
            RuleFor(r => r.Price).GreaterThan(0);
            RuleFor(r => r.Mileage).GreaterThan(0).When(r => r.New);
            When(r => r.New, () =>
                RuleFor(x => x.FirstRegistration).NotNull()
                    .GreaterThan(new DateTime(1950, 1, 1))
                    .LessThanOrEqualTo(DateTime.Now)
            );
        }
    }
}
