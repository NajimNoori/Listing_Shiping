using Listing_Shiping.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Listing_Shiping.Controllers
{
    public class UsersController : Controller
    {
        private UsersDBContext db = new UsersDBContext();

        // Collection part
        public async Task<ActionResult> Index()
        {
            return View(await db.User.ToListAsync());
        }
        public async Task<ActionResult> Details(int? Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.User.FindAsync(Id);
            if(user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // Create part
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include ="FirstName, LastName, EmailAddress, PhoneNumber")]Users user)
        {
            if(ModelState.IsValid)
            {
                db.User.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Edit part
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.User.FindAsync(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "ID, FirstName, LastName, EmailAddress, PhoneNumber")]Users user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Delete part
        public async Task<ActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.User.FindAsync(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.User.FindAsync(Id);
            db.User.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}