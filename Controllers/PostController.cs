using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using netmvc.Models;

namespace netmvc.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Post
        public ActionResult Index([FromUri]int take = 3, int skip = 0)
        {
            var data = db.Database.SqlQuery<Post>($"EXEC dbo.GetAllPost @Skip = {skip} , @Take = {take} ").ToList();
            var total = db.Posts.Count();
            ViewBag.total = total;
            return View(data);
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View(new Post());
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Author,Created")] Post post)
        {

            if (ModelState.IsValid)
            {
                SqlParameter[] sqlParameters = 
                {
                    new SqlParameter("@Name", post.Name),
                    new SqlParameter("@Description", post.Description),
                    new SqlParameter("@Author", post.Author),
                    new SqlParameter("@Created", DateTime.Now),
                };
            try
            {
                    var row=  db.Database.ExecuteSqlCommand("exec dbo.Post_Insert @Name, @Description, @Author, @Created",
                    sqlParameters);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View();
            } 
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Author,Created")] Post post)
        {   
            if (ModelState.IsValid)
            {               
                SqlParameter[] sqlParameters = 
                {   
                    new SqlParameter("@Id", post.Id),
                    new SqlParameter("@Name", post.Name),
                    new SqlParameter("@Description", post.Description),
                    new SqlParameter("@Author", post.Author),
                    new SqlParameter("@Created", DateTime.Now),
                };
            try
            {
                    var row=  db.Database.ExecuteSqlCommand("exec dbo.Post_Update @Id, @Name, @Description, @Author, @Created",
                    sqlParameters);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View();
            } 
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
                
            SqlParameter[] sqlParameters = 
            {   
                new SqlParameter("@Id", id),
            };
            try
            {
                db.Database.ExecuteSqlCommand("exec dbo.Post_Delete @Id ", sqlParameters);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View();
            }  
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
