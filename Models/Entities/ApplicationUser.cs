using Microsoft.AspNetCore.Identity;

namespace KampusStudioProto.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Cognome {get; set;}
        public string Nome {get; set;}
    }
}