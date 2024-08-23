using HumanResources.Data.Entities;
using HumanResources.DataAccess.EntityFramework;
using HumanResources.DataAccess.Repositories.Abstract;

namespace HumanResources.DataAccess.Repositories.Implementation
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        public EducationRepository(Context context) : base(context)
        {
        }

    }
}
