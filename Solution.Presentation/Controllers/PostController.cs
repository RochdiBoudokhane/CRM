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
        public ActionResult Index(int id)
        {
            /* var post = postService.GetById(id);
             var replies = BuildPostReplies(post.PostReplies);

             var model = new PostCRM
             {
                 PostId = post.PostId,
                 Content = post.Content,
                 Created = post.Created,

             };*/
            var posts = postService.GetMany().Select(post => new PostCRM
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content
            });
            var model = new PostIndexModel
            {
                PostList = posts
            };
            return View(model);
        }

        private IEnumerable<PostReplyCRM> BuildPostReplies(ICollection<PostReply> postReplies)
        {
            return postReplies.Select(PostReply => new PostReplyCRM
            {
                PostId = PostReply.PostId,
                Content = PostReply.Content,
                Created = PostReply.Created
            });
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
          /*  Forum forum = new Forum();
            forum = Service.GetById(id);
            var model = new NewPostModel
            {
                ForumTitle = forum.Title,
                ForumId = forum.ForumId,
                ForumImageUrl = forum.ImageUrl,
                
            };*/
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(NewPostModel model)
        {

            // var post = BuildPost(model);
            //return new Post
            //{
            //    Title = model.Title,
            //    Content = model.Content,
            //    Created = DateTime.Now
            //}
            /* Post PostAdd = new Post()
             {
                 Title = model.Title,
                 Content = model.Content,
                 Created = DateTime.Now,
             };
             Service.Add(PostCRM);
             Service.Commit();
             return View(model);*/
            Post PostAdd = new Post()
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now
                
                
                
            };
            postService.Add(PostAdd);
            postService.Commit();
            return RedirectToAction("Topic");
        }

        /*private Post BuildPost(NewPostModel model)
        {
            var forum = Service.GetById(model.ForumId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                Forum = forum
            };
        }*/

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Topic(int PostId)
        {
            var post = postService.GetById(PostId);
            var postReplies = post.PostReplies;

            var postListings = postReplies.Select( postReply=> new PostReplyCRM
            {
                Id = postReply.Id,    
                Content = postReply.Content,
                Created = postReply.Created,
                Post = BuildPostListing(postReply),
                
            });
            var model = new PostTopicModel
            {
                PostReplies = postListings,
                Post = BuildPostListing(postReply)

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
