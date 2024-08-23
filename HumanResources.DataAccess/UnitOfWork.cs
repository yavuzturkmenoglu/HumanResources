using HumanResources.DataAccess.EntityFramework;
using HumanResources.DataAccess.Repositories.Abstract;

namespace HumanResources.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public IUserRepository Users { get; private set; }
        public IInventoryRepository Inventories { get; private set; }
        public IEducationRepository Educations { get; private set; }

        public UnitOfWork(Context context, IUserRepository users,
            IInventoryRepository inventories, IEducationRepository educations)
        {
            _context = context;
            Users = users;
            Inventories = inventories;
            Educations = educations;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task ManualTransactionAsync(Func<Task> codeToExecute)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            await codeToExecute();

            await _context.Database.CommitTransactionAsync();
            //await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
