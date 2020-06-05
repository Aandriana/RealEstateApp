using Microsoft.AspNet.Identity.EntityFramework;

namespace RealEstate.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
