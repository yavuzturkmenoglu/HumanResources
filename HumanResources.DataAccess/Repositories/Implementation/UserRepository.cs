using HumanResources.Data.Entities;
using HumanResources.DataAccess.EntityFramework;
using HumanResources.DataAccess.Repositories.Abstract;

namespace HumanResources.DataAccess.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

    }
}
