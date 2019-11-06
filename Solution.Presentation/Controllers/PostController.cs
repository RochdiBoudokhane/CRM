using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IPostService postService = null;
        IForumService Service = null;

        public PostController()
        {
            postService = new PostService();
            Service = new ForumService();
        }
        // GET: Post
        public ActionResult Index(int ForumId)
        {
             var post = postService.GetById(ForumId);
             var replies = BuildPostReplies(post.Replies);

             var model = new PostCRM
             {
                 PostId = post.PostId,
                 Title = post.Title,  
                 Content = post.Content,
                 Created = post.Created,
                 Replies = replies

             };
            return View(model);
        }
        public ActionResult data(int ForumId)
        {
            var post = postService.GetById(ForumId);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostCRM
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                Created = post.Created,
                Replies = replies

            };
           // List<PostCRM> list = replies.ToList();
            return Json(new { data = replies }, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<PostReplyCRM> BuildPostReplies(ICollection<PostReply> replies)
        {
            return replies.Select(PostReply => new PostReplyCRM
            {
                PostId = PostReply.PostId,
                Content = PostReply.Content,
                Created = DateTime.Now
            });
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create(int ForumId)
        {
            var forum = Service.GetById(ForumId);
            var model = new NewPostModel
            {
                ForumId = forum.ForumId,
                ForumTitle = forum.Title,
                ForumImageUrl = forum.ImageUrl,
            };
            return View(model);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(NewPostModel model)
        {
           // var forum = Service.GetById(FormId);
            var post = BuildPost(model);

            postService.Add(post);
            postService.Commit();
            //return RedirectToAction("Index", "Post", new {id= post.PostId });
            return RedirectToAction("Topic", "Forum" , new { ForumId = model.ForumId });
        }

        private Post BuildPost(NewPostModel model)
        {
            var forum = Service.GetById(model.ForumId);
            return new Post
            {
                ForumId = model.ForumId,
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now             
            };
        }
        // GET: Post/Edit/5
        public ActionResult Edit(int PostId)
        {
            Post post = new Post();
            PostCRM p = new PostCRM();
            post = postService.GetById(PostId);
            p.Title = post.Title;
            p.Content = post.Content;
            return View(p);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int PostId, PostCRM p )
        {
            Post post = new Post();
            post = postService.GetById(PostId);
            post.Title = p.Title;
            post.Content = p.Content;
            postService.Update(post);
            postService.Commit();
            return RedirectToAction("Topic", "Forum", new { ForumId = p.ForumId });
            //return View();
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int PostId)
        {
            Post post = new Post();
            PostCRM p = new PostCRM();
            post = postService.GetById(PostId);
            p.Title = post.Title;
            p.Content = post.Content;
            p.Created = post.Created;
            p.PostId = post.PostId;
            p.ImageUrl = post.ImageUrl;
            return View(p);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PostId, PostCRM postCRM)
        {
            Post post = postService.GetById((int)PostId);
            postService.Delete(post);
            postService.Commit();
            //return RedirectToAction("Index");
            //return View();
            return RedirectToAction("Topic", "Forum", new { ForumId = post.ForumId });
        }
        public ActionResult Topic(int PostId)
        {
            var post = postService.GetById(PostId);
            var postReplies = post.Replies;

            var postListings = postReplies.Select( postReply=> new PostReplyCRM
            {
                Id = postReply.Id,    
                Content = postReply.Content,
                Created = postReply.Created,
               // Post = BuildPostListing(postReply)
                
            });
            var model = new PostTopicModel
            {
                PostReplies = postListings,
                //Post = BuildPostListing(postReply)

            };
            return View(model);
        }
        private PostReplyCRM BuildPostListing(PostReply postReply)
        {
            var post = postReply.Post;
            return BuildPostListing(post);
        }
        private PostReplyCRM BuildPostListing(Post post)
        {
            return new PostReplyCRM
            {
                Id = post.PostId,
                Content = post.Content,
                Created = post.Created
            };
        }
    }
}
