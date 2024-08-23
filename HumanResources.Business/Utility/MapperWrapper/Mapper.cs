using HumanResources.Data.Entities;

namespace HumanResources.Business.Utility.MapperWrapper
{
    internal class Mapper : IMapper
    {
        private readonly AutoMapper.IMapper _mapper;

        public Mapper(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
        }

        public TEntity Map<TEntity>(object dto) where TEntity : Entity
        {
            return _mapper.Map<TEntity>(dto);
        }

        public void Map<TDto, TEntity>(TDto source, TEntity destination) where TEntity : Entity
        {
            _mapper.Map(source, destination);
        }

        public IQueryable<TDto> ProjectTo<TDto>(IQueryable query)
        {
            return _mapper.ProjectTo<TDto>(query);
        }
    }
}
