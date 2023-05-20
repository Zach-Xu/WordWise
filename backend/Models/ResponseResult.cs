namespace backend.Models
{
    public record ResponseResult<T>
    {
        public int Status { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }

        public ResponseResult(int status, T data, string message)
        {
            Status = status;
            Data = data;
            Message = message;
        }

        public ResponseResult(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
