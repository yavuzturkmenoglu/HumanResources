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
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(userDto => userDto.Name)
                .MinimumLength(Constraint.Database.User.NameMinLenght)
                .MaximumLength(Constraint.Database.User.NameMaxLenght)
                .NotEmpty()
                .NotNull();

            RuleFor(userDto => userDto.LastName)
               .MinimumLength(Constraint.Database.User.LastNameMinLenght)
               .MaximumLength(Constraint.Database.User.LastNameMaxLenght)
               .NotEmpty()
               .NotNull();

            RuleFor(userDto => userDto.Gender)
                .IsInEnum();

            RuleForEach(userDto => userDto.Educations).SetValidator(new EducationDtoValidator());
            RuleForEach(userDto => userDto.Inventories).SetValidator(new InventoryDtoValidator());
        }
    }
}
