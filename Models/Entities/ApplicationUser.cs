using Microsoft.AspNetCore.Identity;

namespace KampusStudioProto.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName {get; set;}
    }
}