using HumanResources.Data.Enums;

namespace HumanResources.Data.Entities
{
    public class Education : Entity
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
