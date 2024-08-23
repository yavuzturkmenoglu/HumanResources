using FluentValidation;
using HumanResources.Core.Constants;
using HumanResources.Data.Dtos;
using HumanResources.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Utility.Validation
{
    public class EducationDtoValidator : AbstractValidator<EducationDto>
    {
        public EducationDtoValidator()
        {
            RuleFor(educationDto => educationDto.Name)
                .MinimumLength(Constraint.Database.Education.NameMinLenght)
                .MaximumLength(Constraint.Database.Education.NameMaxLenght)
                .NotEmpty()
                .NotNull();
        }
    }
}
