using Authentication.Model;

namespace AuthenticationService.Model.Mappers
{
    internal static class DtoMappers
    {
        public static ApplicationUserDto Map(this ApplicationUser model)
        {
            return new()
            {
                Id = model.Id,
                Username = model.Username,
                PrivateKey = model.PrivateKey,
                PublicKey = model.PublicKey,
            };
        }
    }
}
