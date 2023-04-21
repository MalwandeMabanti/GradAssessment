namespace WebAPI.Validators
{
    using FluentValidation;
    

    public class WeatherValidator : AbstractValidator<WeatherModel>
    {
        public WeatherValidator()
        {
            this.RuleSet("Get", () =>
            {
                this.GeneralRules();


            });
        }

        private void GeneralRules() 
        {
            this.RuleFor(_ => _.location.name)
                .NotEmpty()
                .NotNull();

            this.RuleFor(_ => _.location.localtime)
                .NotEmpty();

            this.RuleFor(_ => _.current.last_updated)
                .NotEmpty();

            this.RuleFor(_ => _.current.temp_c)
                .NotEmpty();

            this.RuleFor(_ => _.current.is_day)
                .NotEmpty();

            this.RuleFor(_ => _.current.wind_kph)
                .NotEmpty();

            this.RuleFor(_ => _.current.wind_degree)
                .NotEmpty();

            this.RuleFor(_ => _.current.wind_dir)
                .NotEmpty();

            this.RuleFor(_ => _.current.humidity)
                .NotEmpty();
        }
    }
}