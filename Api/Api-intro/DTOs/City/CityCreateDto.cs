﻿using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Api_intro.DTOs.City
{
    public class CityCreateDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CityCreateDtoValidator : AbstractValidator<CityCreateDto>
    {
        public CityCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Name).Length(5, 15).WithMessage("Name length must be between 5 - 15");
        }
    }
}
