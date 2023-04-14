namespace WebAPI.Validators
{
    using FluentValidation;
    

    public class WeatherValidator : AbstractValidator<WeatherModel>
    {
        public WeatherValidator()
        {
            this.RuleFor(_ => _.location.name)
                .NotEmpty();

            this.RuleFor(_ => _.location.lat)
                .LessThanOrEqualTo(87);

        }
    }
}