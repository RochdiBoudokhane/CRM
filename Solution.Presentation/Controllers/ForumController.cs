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
    public class ForumController : Controller
    {
        IForumService Service = null;
        

        public ForumController()
        {
            Service = new ForumService();
        }
        // GET: Forum
        public ActionResult Index()
        {
            //return View(Service.GetMany());
           var forums = new List<ForumCRM>();
            foreach (Forum forumA in Service.GetMany())
            {
                forums.Add(new ForumCRM()
                {
                    ForumId=forumA.ForumId,
                    ImageUrl=forumA.ImageUrl,
                    Title=forumA.Title,
                    Descripition=forumA.Descripition,
                    Created=forumA.Created
                });

            }
            return View(forums);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
           /* var ImageUrl = "images/users/default.jpg";

            if (forumCRM.ImageUpload != null)
            {
                var blockBlob = UploadForumImage(forumCRM.ImageUpload);
                ImageUrl = blockBlob.Uri.AbsoluteUri;
            }*/
            Forum ForumAdd = new Forum()
            {
                ImageUrl = forumCRM.ImageUrl,
                Title = forumCRM.Title,
                Descripition = forumCRM.Descripition,
                Created = forumCRM.Created,           
            };
            Service.Add(ForumAdd);
            Service.Commit();
            Service.Dispose();
            return View();
        }
       /* private CloudBlockBlob UploadForumImage(IFormFile file)
        {
            var connectionString = _configuration.GetConnectionString("AzureStorageAccount");
            var container = _uploadService.GetBlobContainer(connectionString, "forum-images");
            var contentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var filename = contentDisposition.FileName.Trim('"');
            var blockBlob = container.GetBlockBlobReference(filename);
            blockBlob.UploadFromStreamAsync(file.OpenReadStream()).Wait();

            return blockBlob;
        }*/

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Forum/Edit/5
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

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            //var forum = Forum.GetById(id);
            return View();
        }

        // POST: Forum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var forum = Service.GetById(id);
            var f = Service.D
            Service.Delete(id);

            return RedirectToAction("Index"); 
        }
          public ActionResult Topic(int ForumId)
            {
            var forum = Service.GetById(ForumId);
            var posts = forum.Posts;

            var postListings = posts.Select(post => new Post
            {
                PostId = post.PostId,
                //AuthorId = post.User.Id,
               // AuthorRating = post.User.Rating,
               // AuthorName = post.User.UserName,
                Title = post.Title,
                Created = post.Created,
               // RepliesCount = post.Replies.Count(),
                //Forum = BuildForumListing(post)
            });

           /* var model = new Post
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)
            };*/

            return View(posts);
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
