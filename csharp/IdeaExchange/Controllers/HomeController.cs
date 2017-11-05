using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaExchange.Data;
using IdeaExchange.Models;
using IdeaExchange.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdeaExchange.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        [Route("bright_ideas")]
        public IActionResult Index()
        {
            var current_user = _context.ApplicationUsers.SingleOrDefault(user => user.UserName == User.Identity.Name);
            ViewBag.current_user = current_user;
            ViewBag.all_users = _context.ApplicationUsers.ToList();
            ViewBag.all_likes = _context.Likes.ToList();
            ViewBag.all_posts = _context.Posts.OrderByDescending(posts => posts.Likes.Count()).ToList();
            ViewBag.top_post = _context.Posts.OrderByDescending(posts => posts.Likes.Count()).ToList().FirstOrDefault();
            if (current_user != null)
            {
                ViewBag.user_likes = _context.Likes.Where(user => user.UserId == current_user.UserId).Select(post => post.PostId).ToList();
            }
            return View("Index");
        }

        [HttpGet]
        [Route("users/{UserId}")]
        public IActionResult UserProfile(int UserId)
        {
            var this_user = _context.ApplicationUsers.Where(user => user.UserId == UserId).FirstOrDefault();
            if (this_user != null)
            {
                ViewBag.this_user = this_user;
                ViewBag.user_post_count = _context.Posts.Where(user => user.UserId == UserId).Count();
                ViewBag.user_like_count = _context.Likes.Where(user => user.UserId == UserId).Count();
                return View("UserProfile");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("post/{PostId}")]
        [Route("bright_ideas/{PostId}")]
        public IActionResult PostDetails(int PostId)
        {
            var current_post = _context.Posts.Where(post => post.PostId == PostId).FirstOrDefault();
            if (current_post != null)
            {
                ViewBag.current_post = current_post;
                ViewBag.current_post_likes = _context.likes_users.Where(post => post.PostId == PostId).ToList();
                ViewBag.all_users = _context.ApplicationUsers.ToList();
                ViewBag.all_posts = _context.Posts.ToList();
                return View("PostDetail");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("post/addpost")]
        public IActionResult PostForm()
        {
            return View();
        }

        [HttpPost]
        [Route("post/addpost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(PostViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    Posts NewPost = new Posts
                    {
                    UserId = current_user.UserId,
                    PostContent = incoming.PostContent,
                    Alias = current_user.Alias
                    };
                    await _context.Posts.AddAsync(NewPost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View("PostForm", incoming);
        }

        [HttpPost]
        [Route("post/delete")]
        public IActionResult DeletePost(LikesViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    var current_post = _context.Posts.Where(poster => poster.UserId == current_user.UserId).Where(post => post.PostId == incoming.PostId).FirstOrDefault();
                    _context.Posts.Remove(current_post);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Index", incoming);
            }
            return View("Index");
        }

        [HttpPost]
        [Route("like/add")]
        public async Task<IActionResult> AddLike(LikesViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    Likes NewLike = new Likes
                    {
                    UserId = current_user.UserId,
                    PostId = incoming.PostId
                    };
                    await _context.Likes.AddAsync(NewLike);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Index", incoming);
            }
            return View("Index");
        }

        [HttpPost]
        [Route("like/delete")]
        public IActionResult DeleteLike(LikesViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                var current_user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (current_user != null)
                {
                    var current_like = _context.Likes.Where(user => user.UserId == current_user.UserId).Where(post => post.PostId == incoming.PostId).FirstOrDefault();
                    _context.Likes.Remove(current_like);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Index", incoming);
            }
            return View("Index");
        }
    }
}