using Service.Pattern;
using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IForumService Service = null;
        IPostService postService = null;
  
        public ForumController()
        {
            Service = new ForumService();
            postService = new PostService();
        }
        // GET: Forum
        public ActionResult Index()
        {
            var forums = Service.GetMany().Select(forum => new ForumCRM
            {
                ForumId = forum.ForumId,
                Title = forum.Title,
                Descripition = forum.Descripition,
                Created = forum.Created,
                ImageUrl = forum.ImageUrl
            });
            var model = new ForumIndexModel
            {
                ForumList = forums
            };
            return View(model);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = Service.GetById((int)id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(ForumCRM forumCRM)
        {
            Forum ForumAdd = new Forum()
            {
                ImageUrl = forumCRM.ImageUrl,
                Title = forumCRM.Title,
                Descripition = forumCRM.Descripition,
                Created = forumCRM.Created,           
            };
            Service.Add(ForumAdd);
            Service.Commit();
            return RedirectToAction("Index");
        }
        // GET: Forum/Edit/5
        public ActionResult Edit(int id=0)
        {
            Forum forum = new Forum();
            ForumCRM f = new ForumCRM();
            forum = Service.GetById(id);
            f.Title = forum.Title;
            f.Descripition = forum.Descripition;
            f.Created = forum.Created;
            f.ForumId = forum.ForumId;
            f.ImageUrl = forum.ImageUrl;
            return View(f);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ForumCRM forums)
        {
            Forum forum = new Forum();
            ForumCRM f = new ForumCRM();
            forum = Service.GetById(id);
            f.Title = forum.Title;
            f.Descripition = forum.Descripition;
            f.Created = forum.Created;
            f.ForumId = forum.ForumId;
            f.ImageUrl = forum.ImageUrl;
            Service.Update(forum);
            Service.Commit();
            return RedirectToAction("index");
        }

        // GET: Forum/Delete/5
 
        public ActionResult Delete(int id)
        {
            Forum forum = new Forum();
            ForumCRM f = new ForumCRM();
            forum = Service.GetById(id);
            f.Title = forum.Title;
            f.Descripition = forum.Descripition;
            f.Created = forum.Created;
            f.ForumId = forum.ForumId;
            f.ImageUrl = forum.ImageUrl;
            return View(f);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ForumCRM forums)
        {
            Forum forum = Service.GetById((int)id);
            Service.Delete(forum);
            Service.Commit();
            return RedirectToAction("Index");
        }
          public ActionResult Topic(int ForumId)
            {
            var forum = Service.GetById(ForumId);
            var posts = forum.Posts;

            var postListings = posts.Select(post => new PostCRM
            {
               PostId = post.PostId,
               Content = post.Content,
               Created = post.Created,
               Forum = BuildForumListing(post),
               ImageUrl = post.ImageUrl,
               RepliesCount = post.PostReplies.Count(),
               Title = post.Title
            });
            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)

            };
            return View(model);
        }
        private ForumCRM BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }
        private ForumCRM BuildForumListing(Forum forum)
        {
            return new ForumCRM
            {
                ForumId = forum.ForumId,
                Title = forum.Title,
                Descripition = forum.Descripition,
                ImageUrl = forum.ImageUrl,
                Created = forum.Created
            };
        }
    }
}
