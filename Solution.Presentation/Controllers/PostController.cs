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

        public PostController()
        {
            postService = new PostService();
        }
        // GET: Post
        public ActionResult Index(int id)
        {
            var post = postService.GetById(id);
            var replies = BuildPostReplies(post.PostReplies);

            var model = new PostCRM
            {
                PostId = post.PostId,
                Content = post.Content,
                Created = post.Created,
                
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
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
    }
}
