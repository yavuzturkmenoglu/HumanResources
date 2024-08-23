using HumanResources.Data.Enums;

namespace HumanResources.Data.Dtos
{
    public class InventoryDto
    {
        public long Id { get; set; }
        public Equipment Equipment { get; set; }
        public long UserId { get; set; }
    }
}
