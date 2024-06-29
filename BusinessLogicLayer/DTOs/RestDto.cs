namespace E_Commerce.BLL.DTOs
{
    public class RestDto <T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; } = default!;
    }
}
