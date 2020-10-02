using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Queries.Songs.Validation
{
    public abstract class SongQueryValidation<T> : AbstractValidator<T> where T : SongCommandQuery
    {
        protected void ValidateCity()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Please ensure you have entered the city name")
                .Length(2, 150).WithMessage("The city name must have between 2 and 150 characters");
        }
    }
}
