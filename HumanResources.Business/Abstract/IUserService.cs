using HumanResources.Data.Dtos;
using HumanResources.Data.Internal.Response;

namespace HumanResources.Business.Abstract
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserPreviewDto>>> GetAll();
        Task<Result<UserDto>> Get(long id);
        Task<Result<bool>> Add(UserDto userDto);
        Task<Result<bool>> Update(UserDto userDto);
        Task<Result<bool>> Delete(long id);
    }
}