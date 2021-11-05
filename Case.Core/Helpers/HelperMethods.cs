using Case.Domain.DTO.Shared;

namespace Case.Core.Helpers
{
    public static class HelperMethods
    {
        public static Result<T> GetNotFoundErrorModel<T>(string message)
        {
            return new Result<T>
            {
                IsSuccessful = false,
                Message = message
            };
        }

        public static Result<T> GetOkModel<T>(T data)
        {
            return new Result<T>
            {
                IsSuccessful = true,
                Message = "Ok",
                Data = data
            };
        }
    }
}
