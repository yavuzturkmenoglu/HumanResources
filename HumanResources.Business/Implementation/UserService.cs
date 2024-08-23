using FluentValidation;
using HumanResources.Business.Abstract;
using HumanResources.Business.Utility.MapperWrapper;
using HumanResources.Data.Dtos;
using HumanResources.Data.Entities;
using HumanResources.Data.Enums;
using HumanResources.Data.Internal.Response;
using HumanResources.Data.Internal.Response.Enums;
using HumanResources.DataAccess;
using HumanResources.DataAccess.Utility.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDto> _userDtoValidator;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDto> userDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
        }

        public async Task<Result<IEnumerable<UserPreviewDto>>> GetAll()
        {
            var entity = _unitOfWork.Users.GetAll();
            var dtos = await _mapper.ProjectTo<UserPreviewDto>(entity).FetchListAsync();

            return Result<IEnumerable<UserPreviewDto>>.CreateSuccessResult(dtos);
        }

        public async Task<Result<UserDto>> Get(long id)
        {
            var entity = _unitOfWork.Users.Get(id);
            if (entity == null)
                return Result<UserDto>.CreateErrorResult(ErrorCode.ObjectNotFound);

            var dto = await _mapper.ProjectTo<UserDto>(entity).FetchAsync();

            return Result<UserDto>.CreateSuccessResult(dto);
        }

        public async Task<Result<bool>> Add(UserDto userDto)
        {
            await _userDtoValidator.ValidateAndThrowAsync(userDto);

            var user = _mapper.Map<User>(userDto);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult();
        }

        public async Task<Result<bool>> Update(UserDto userDto)
        {
            await _userDtoValidator.ValidateAndThrowAsync(userDto);

            var entity = await _unitOfWork.Users.GetAsTracking(userDto.Id).Include(x=>x.Inventories).Include(x => x.Educations).FetchAsync();
            if (entity == null)
                return Result<bool>.CreateErrorResult(ErrorCode.ObjectNotFound);

            entity.Educations.Where(x => !userDto.Educations.Select(u => u.Id).Contains(x.Id)).Select(x => { return x.IsDeleted = true; });
            entity.Inventories.Where(x => !userDto.Inventories.Select(u => u.Id).Contains(x.Id)).Select(x => { return x.IsDeleted = true; });

            _mapper.Map(userDto, entity);
            await _unitOfWork.Commit();
  
            return Result<bool>.CreateSuccessResult();
        }

        public async Task<Result<bool>> Delete(long id)
        {
            await _unitOfWork.Users.UpdateAsync(x => x.Id == id, x => x.SetProperty(x => x.IsDeleted, true));

            return Result<bool>.CreateSuccessResult();
        }
    }
}
