using HumanResources.Data.Entities;
using HumanResources.DataAccess.EntityFramework;
using HumanResources.DataAccess.Repositories.Abstract;

namespace HumanResources.DataAccess.Repositories.Implementation
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(Context context) : base(context)
        {
        }

    }
}
