using HumanResources.Data.Enums;

namespace HumanResources.Data.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public List<Inventory> Inventories { get; set; } = Enumerable.Empty<Inventory>().ToList();
        public List<Education> Educations { get; set; } = Enumerable.Empty<Education>().ToList();
    }
}
