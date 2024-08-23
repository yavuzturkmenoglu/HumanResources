using HumanResources.Data.Enums;

namespace HumanResources.Data.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<InventoryDto> Inventories { get; set; } = Enumerable.Empty<InventoryDto>();
        public IEnumerable<EducationDto> Educations { get; set; } = Enumerable.Empty<EducationDto>();
    }
}
