using HumanResources.Data.Entities;

namespace HumanResources.Business.Utility.MapperWrapper
{
    public interface IMapper
    {
        /// <summary>
        /// Used for creating entities from dtos for add operations
        /// </summary>
        TEntity Map<TEntity>(object dto) where TEntity : Entity;

        /// <summary>
        /// Used for mapping dtos on to entities for update operations
        /// </summary>
        void Map<TDto, TEntity>(TDto source, TEntity destination) where TEntity : Entity;

        /// <summary>
        /// Used for creating dtos from database calls
        /// </summary>
        IQueryable<TDto> ProjectTo<TDto>(IQueryable query);
    }
}
