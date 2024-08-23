using HumanResources.Data.Enums;

namespace HumanResources.Data.Entities
{
    public class Inventory : Entity
    {
        public Equipment Equipment { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
