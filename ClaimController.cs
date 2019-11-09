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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using PagedList;
using System.Web.Mvc;





namespace Solution.Presentation.Controllers
{
    public class ClaimController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IClaimService Service = null;
        IPostService postService = null;

        public ClaimController()
        {
            Service = new ClaimService();
            postService = new PostService();
        }









        // GET: Claim
        public ActionResult Index(int? i)
        {
            
            var Claim = new List<ClaimCRM>();
            //IEnumerable<Claim> Claim = ClaimService.GetMany();
            IEnumerable<Claim> productDomain = Service.GetMany();
            ViewBag.data = Claim;
            foreach (Claim ClaimA in Service.GetMany())
            {
                Claim.Add(new ClaimCRM()
                {
                    ClaimId = ClaimA.ClaimId,
                    Message = ClaimA.Message,
                    NumTel = ClaimA.NumTel,
                    Email = ClaimA.Email,
                    Name = ClaimA.Name,
                    ImageUrl = ClaimA.ImageUrl,

                    Type = ClaimA.Type,
                    State = ClaimA.State,
                    CreatedDate = ClaimA.CreatedDate
                });
            }
            return View(Claim.ToPagedList(i ?? 1, 3));
        }








        //// GET: Claim
        //public ActionResult Index(String searchString)
        //{
        //    // return View();
        //    var Claim = new List<ClaimCRM>();
        //    foreach (Claim ClaimA in Service.GetMany())
        //    {
        //        Claim.Add(new ClaimCRM()
        //{
        //    ClaimId = ClaimA.ClaimId,
        //            Message = ClaimA.Message,
        //            NumTel = ClaimA.NumTel,
        //            Email = ClaimA.Email,
        //            Name = ClaimA.Name,
        //            ImageUrl = ClaimA.ImageUrl,

        //            Type = ClaimA.Type,
        //            State = ClaimA.State,
        //            CreatedDate = ClaimA.CreatedDate
        //        });

        //    }
        //    return View(Claim);
        //}



        // GET: Claim/State
        public ActionResult Suivi(String searchString)
        {
            // return View();
            var Claim = new List<ClaimCRM>();
            foreach (Claim ClaimA in Service.GetMany())
            {
                Claim.Add(new ClaimCRM()
                {
                   
                 
                    State = ClaimA.State,
                    CreatedDate = ClaimA.CreatedDate

                });

            }
            return View(Claim);
        }

        // GET: Claim/State
        public ActionResult Stat(String searchString)
        {
            // return View();
            var Claim = new List<ClaimCRM>();
            ClaimCRM b = new ClaimCRM();
            b.somme = allTimenbrReclamation();


            Claim.Add(b);

            
            return View(Claim);
        }

        
            
        
        public int allTimenbrReclamation()
        {
            int x = 0;

            foreach (Claim ClaimA in Service.GetMany())
            {
                x = x + 1;
            }
            return x;
        }
        public int allTimnbrReclamationNontraité()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if (ClaimA.State == 0)
                {
                    x = x + 1;
                }
            }
            return x;
        }
        public int allTimnbrReclamationEncours()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if (ClaimA.State == 1)
                {
                    x = x + 1;
                }
            }
            return x;
        }

        public int allTimnbrReclamationtraité()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if (ClaimA.State == 2)
                {
                    x = x + 1;
                }
            }
            return x;
        }
        public float allTimpourcentageTraité()
        {
            return allTimenbrReclamation() / allTimnbrReclamationtraité();
        }
        public float allTimpourcentageNonTraité()
        {
            return allTimenbrReclamation() / allTimnbrReclamationNontraité();
        }
        public float allTimpourcentageEnCours()
        {
            return allTimenbrReclamation() / allTimnbrReclamationEncours();
        }

        public int ceMoisnbrReclamation()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if ((ClaimA.CreatedDate.Year == (DateTime.Now.Year)) && (ClaimA.CreatedDate.Month == (DateTime.Now.Month))){
                    x = x + 1;
                }
            }
            return x;
        }
       
        public int ceMoisnbrReclamationNontraité()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if ((ClaimA.CreatedDate.Year == (DateTime.Now.Year)) && (ClaimA.CreatedDate.Month == (DateTime.Now.Month) && (ClaimA.State == 0)))
                {
                    x = x + 1;
                }
            }
            return x;
        }
        public int ceMoisnbrReclamationEncours()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if ((ClaimA.CreatedDate.Year == (DateTime.Now.Year)) && (ClaimA.CreatedDate.Month == (DateTime.Now.Month) && (ClaimA.State == 1)))
                {
                    x = x + 1;
                }
            }
            return x;
        }
        public int ceMoisnbrReclamationtraité()
        {
            int x = 0;
            foreach (Claim ClaimA in Service.GetMany())
            {
                if ((ClaimA.CreatedDate.Year == (DateTime.Now.Year)) && (ClaimA.CreatedDate.Month == (DateTime.Now.Month) && (ClaimA.State == 2)))
                {
                    x = x + 1;
                }
            }
            return x;
        }
        public float ceMoispourcentageTraité()
        {
            return ceMoisnbrReclamation() / ceMoisnbrReclamationtraité();
        }
        public float ceMoisTimpourcentageNonTraité()
        {
            return ceMoisnbrReclamation() / ceMoisnbrReclamationNontraité();
        }
        public float ceMoisTimpourcentageEnCours()
        {
            return ceMoisnbrReclamation() / ceMoisnbrReclamationEncours();
        }







        // GET: Claim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim Claim = Service.GetById((int)id);
            if (Claim == null)
            {
                return HttpNotFound();
            }
            return View(Claim);
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(ClaimCRM ClaimCRM, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            Claim ClaimAdd = new Claim()
            {

                Name = ClaimCRM.Name,
                Type = ClaimCRM.Type,
                NumTel = ClaimCRM.NumTel,
                Email = ClaimCRM.Email,
                ImageUrl = Path.GetFileName(file.FileName),
                Message = ClaimCRM.Message,
                CreatedDate = DateTime.Now,
                State = ClaimCRM.State,



            };
            try
            {
                MailMessage message = new MailMessage("khaled.benrjeb@esprit.tn", ClaimAdd.Email, subject: "Thank You For Your Claim", body: " Mr/Ms "+ ClaimAdd.Name + " you have saccefly send your Claim  with this numberYour warranty claim has been submitted successfully. Expediting your claim is important to us. Everything has been sent over to the manufacturer as part of the claim process Please remember that claims can take up to 30 days to get a decision back from the manufacturer.You will be notified with the results of your claim by email using the email address you provided " +ClaimAdd.Email+" If for any reason you have question in the meantime please feel free to contact the store location you purchased from. Find Your Claim number here : "+ClaimAdd.NumTel);
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("khaled.benrjeb@esprit.tn", "khaleDD@463331195888");
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }



            //try
            //{
            //    const string accountSid = "AC255e61580d73904b2a5e5a5e39c715f0";
            //    const string authToken = "AUTH_TOKEN";
            //    const string url = "https://api.twilio.com/2010-04-01/Accounts/" + accountSid + "/Messages.json";


            //    TwilioRestClient client = new TwilioRestClient(accountSid, authToken);

            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //    var authInfo = accountSid + ":" + authToken;
            //    authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            //    request.Method = "POST";
            //    var postData = "{\"To\":" + "\"" + sms.ToNumber + "\"" + ", \"From\":" + "\"" + fromNumTel + "\"" + ", \"Body\":" + "\"" + sms.Body + "\"}";

            //    var data = Encoding.UTF8.GetBytes(postData);
            //    request.ContentType = "application/x-www-form-urlencoded";
            //    request.ContentLength = data.Length;
            //    Stream writer = null;
            //    writer = request.GetRequestStream();
            //    writer.Write(data, 0, data.Length);
            //    writer.Close();
            //    request.Headers["Authorization"] = "Basic " + authInfo;
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    string content = reader.ReadToEnd();
            //    msg = client.SendMessage("+12012317746 ", sms.ToNumber, sms.Body);
            //}
            //catch (WebException ex)
            //{
            //    using (var stream = ex.Response.GetResponseStream())
            //    using (var reader = new StreamReader(stream))
            //    {
            //        string err = reader.ReadToEnd();
            //    }
            //}





            Service.Add(ClaimAdd);
            Service.Commit();
            // Service.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.
                    Combine(Server.MapPath("~/Content/Upload/"),
                    fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Claim Claim = new Claim();
            ClaimCRM c = new ClaimCRM();
            Claim = Service.GetById(id);
            c.Name = Claim.Name;
            c.Type = Claim.Type;
            c.Email = Claim.Email;
            c.ImageUrl = Claim.ImageUrl;
            c.Message = Claim.Message;
            c.State = Claim.State;
            //c.CreatedDate = Claim.CreatedDate;
            c.ClaimId = Claim.ClaimId;

            return View(c);
        }

        // POST: Claim/Edit/5
        [HttpPost]
       
        public ActionResult Edit(int id, ClaimCRM c, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            Claim Claim = new Claim();
            
            Claim = Service.GetById(id);
            Claim.Name = c.Name;
            Claim.Email = c.Email;
            Claim.Message = c.Message;
            Claim.State = c.State;
           
            Claim.NumTel = c.NumTel;
            Claim.Type = c.Type;
            //Claim.CreatedDate = c.CreatedDate;
            

            Service.Update(Claim);
            Service.Commit();
            return RedirectToAction("index");
        }

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            Claim Claim = new Claim();
            ClaimCRM c = new ClaimCRM();
            Claim = Service.GetById(id);
            c.Name = Claim.Name;
            c.Type = Claim.Type;
            c.CreatedDate = Claim.CreatedDate;
            c.ClaimId = Claim.ClaimId;

            return View(c);
        }

        // POST: Claim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClaimCRM Claim)
        {
            Claim claim = Service.GetById((int)id);
            Service.Delete(claim);
            Service.Commit();
            return RedirectToAction("Index");
        }
    }
}
