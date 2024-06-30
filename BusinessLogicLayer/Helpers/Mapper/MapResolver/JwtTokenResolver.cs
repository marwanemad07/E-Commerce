namespace E_Commerce.BLL.Helpers.Mapper.MapResolver
{
    public class JwtTokenResolver : IValueResolver<AppUser, UserDto, string>
    {
        private readonly IJwtHelper _jwtHelper;

        public JwtTokenResolver(IJwtHelper jwtHelper) 
        {
            _jwtHelper = jwtHelper;
        }
        public string Resolve(AppUser source, UserDto destination, string destMember, ResolutionContext context)
        {
            if(source != null)
            {
                return _jwtHelper.GenerateJwtToken(source);
            }
            return string.Empty;
        }
    }
}
