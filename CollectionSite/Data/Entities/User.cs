using CollectionSite.Models;
using Microsoft.AspNetCore.Identity;

namespace CollectionSite.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public bool IsActive { get; set; }
        public ICollection<Post> Posts { get; set; }

    }

}
