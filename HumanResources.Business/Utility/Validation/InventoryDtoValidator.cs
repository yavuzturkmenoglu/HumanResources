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
    public class InventoryDtoValidator : AbstractValidator<InventoryDto>
    {
        public InventoryDtoValidator()
        {
            RuleFor(inventoryDto => inventoryDto.Equipment)
                .IsInEnum();
        }
    }
}
