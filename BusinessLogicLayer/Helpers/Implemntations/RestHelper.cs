namespace E_Commerce.BLL.Helpers.Implemntations
{
    static class RestHelper
    {
        static public RestDto<T?> CreateResponse<T>(T? Data, int StatusCode)
        {
            return new RestDto<T?>
            {
                Data = Data,
                StatusCode = StatusCode
            };
        }
    }
}
