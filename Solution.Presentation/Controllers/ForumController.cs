using Service.Pattern;
using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class ForumController : Controller
    {
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
            //return View(Service.GetMany());
            /* var forums = new List<ForumCRM>();
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
              return View(forums);*/
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
            return View();
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ForumCRM forumCRM)
        {
            Forum ForumAdd = new Forum();
      
            //Service.Delete(id);
            Service.Commit();
            Service.Dispose();
           // return View();
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
