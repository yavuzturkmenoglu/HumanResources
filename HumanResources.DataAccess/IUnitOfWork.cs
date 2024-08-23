using HumanResources.DataAccess.Repositories.Abstract;

namespace HumanResources.DataAccess
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IInventoryRepository Inventories { get; }
        public IEducationRepository Educations { get; }

        public Task<int> Commit();

        /// <summary>
        /// This should be used when multiple commits must be made in one function
        /// </summary>
        /// <returns></returns>
        public Task ManualTransactionAsync(Func<Task> codeToExecute);
    }
}
