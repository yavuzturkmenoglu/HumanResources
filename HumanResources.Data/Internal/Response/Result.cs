using HumanResources.Data.Internal.Response.Enums;

namespace HumanResources.Data.Internal.Response
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public ErrorCode ErrorCode { get; set; }

        #region SuccessResults
        public static Result<T> CreateSuccessResult(T data = default)
        {
            return new Result<T>
            {
                Data = data,
                Success = true,
                ErrorCode = ErrorCode.Success
            };
        }
        #endregion

        #region ErrorResults
        public static Result<T> CreateErrorResult(ErrorCode errorCode = ErrorCode.GenericError)
        {
            return new Result<T>
            {
                Data = default,
                Success = false,
                ErrorCode = errorCode
            };
        }
        #endregion
    }
}
