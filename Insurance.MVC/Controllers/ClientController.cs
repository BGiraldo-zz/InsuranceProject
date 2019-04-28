using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.MVC.Validators;
using System.Net;
using System.Web.Mvc;

namespace Insurance.MVC.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientRepository _context;
        private readonly ClientValidator _validator;

        public ClientController(IClientRepository context)
        {
            this._context = context;
            this._validator = new ClientValidator(_context);
        }

        // GET: Client
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _context.Get(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Identification,CompleteName,Address,Phone,Email")] Client client)
        {
            if (ModelState.IsValid & _validator.Validate(client).IsValid)
            {
                _context.Add(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _context.Get(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Identification,CompleteName,Address,Phone,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Update(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _context.Get(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _context.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
