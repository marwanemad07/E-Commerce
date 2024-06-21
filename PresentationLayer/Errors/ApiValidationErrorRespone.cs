namespace E_Commerce.Errors
{
    public class ApiValidationErrorRespone : ApiResponse
    {
        public ApiValidationErrorRespone() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
