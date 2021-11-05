namespace Case.Domain.DTO.Shared
{
    public class Result<T>
    {
        public Result()
        {
            IsSuccessful = true;
        }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
