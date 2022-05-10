using System.Data.Entity;
using CollectionSite.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }

}
