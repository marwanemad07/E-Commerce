namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDto>>> GetBrands()
        {
            return await _brandService.GetBrandsAsync();
        }
    }
}
