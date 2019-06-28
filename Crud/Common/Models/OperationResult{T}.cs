namespace Common.Models
{
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }
    }
}
