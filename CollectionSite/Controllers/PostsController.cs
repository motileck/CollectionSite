using System.Security.Claims;
using CollectionSite.Data;
using CollectionSite.Data.Entities;
using CollectionSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionSite.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {

        private readonly ApplicationDbContext dbcontext;

        public PostsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet ("createpost")]
        public IActionResult CreatePosts()
        {
            return View();
        }

        [HttpPost("createpost")]

        public IActionResult Create([FromForm]CreatePostsViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = dbcontext.Users.First(u => u.Id.ToString() == userId);
            Post post = new Post
             {
                 User = user,
                 PostContent = model.Content,
                 Title = model.Title,
                 Created = DateTime.UtcNow,
             };
             dbcontext.Posts1.Add(post);
             dbcontext.SaveChanges();
             return RedirectToAction("DisplayPosts");
        }
        [HttpGet ("displaypost")]
        public IActionResult DisplayPosts()
        {
            return View();
        }

       
    }
}
