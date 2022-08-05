using Microsoft.AspNetCore.Identity;

namespace ArchitecturePractice.Models
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(IdentityUser userManager, string token)
        {
            Id = userManager.Id;
            Username = userManager.UserName;
            Token = token;
        }
    }
}
