namespace E_Commerce.BLL.Settings
{
    public class ProductSettings
    {
        private const int MaxPageSize = 30;
        private int _pageSize = 10; // just a packing field
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = Math.Min(value, MaxPageSize);
        }
        public int PageNumber { get; set; } = 1;
        public string? Sort { get; set; }
        private string? _search;
        public string? Search 
        { 
            get => _search; 
            set => _search = value?.ToLower();
        }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
