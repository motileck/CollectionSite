
using CollectionSite.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CollectionSite.Models;


namespace CollectionSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
            

        }
        public DbSet<Post> Posts1 { get; set; }
        public DbSet<PostReply> Replies { get; set; }

    }

}
