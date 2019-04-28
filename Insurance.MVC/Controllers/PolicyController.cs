using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Infrastructure;
using Insurance.MVC.Validators;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Insurance.MVC.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyRepository _context;
        private readonly PolicyValidator _validator;

        public PolicyController(IPolicyRepository context)
        {
            this._context = context;
            this._validator = new PolicyValidator();
        }

        // GET: Policy
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: Policy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = _context.Get(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: Policy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Policy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyId,Name,Description,CoveringType,Coverage,TermBeginning,CoverageOnMonths,Price,RiskType")] Policy policy)
        {
            if (ModelState.IsValid & _validator.Validate(policy).IsValid)
            {
                _context.Add(policy);
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // GET: Policy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = _context.Get(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyId,Name,Description,CoveringType,Coverage,TermBeginning,CoverageOnMonths,Price,RiskType")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _context.Update(policy);
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        // GET: Policy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = _context.Get(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy = _context.Get(id);
            _context.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
