using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Insurance.MVC.Controllers
{
    [Authorize]
    public class PolicyDetailController : Controller
    {
        private readonly IPolicyDetailRepository _context;

        public PolicyDetailController(IPolicyDetailRepository context)
        {
            this._context = context;
        }
        // GET: PolicyDetail
        public ActionResult Index()
        {
            var policyDetails = _context.Include();
            return View(policyDetails.ToList());
        }

        // GET: PolicyDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyDetail policyDetail = _context.Get(id);
            if (policyDetail == null)
            {
                return HttpNotFound();
            }
            return View(policyDetail);
        }

        // GET: PolicyDetail/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_context.GetClients(), "ClientId", "CompleteName");
            ViewBag.PolicyId = new SelectList(_context.GetPolicies(), "PolicyId", "Name");
            return View();
        }

        // POST: PolicyDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyDetailId,PolicyId,ClientId,Status")] PolicyDetail policyDetail)
        {
            if (ModelState.IsValid & (policyDetail.ClientId != 0 & policyDetail.PolicyId != 0))
            {
                var existentPolicyDetail = _context.GetAll().FirstOrDefault(pd => pd.ClientId == policyDetail.ClientId & 
                                                                                    pd.PolicyId == policyDetail.PolicyId);

                if(existentPolicyDetail == null)
                {
                    _context.Add(policyDetail);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ClientId", "This user already has this policy");
                }
            }

            ViewBag.ClientId = new SelectList(_context.GetClients(), "ClientId", "CompleteName", policyDetail.ClientId);
            ViewBag.PolicyId = new SelectList(_context.GetPolicies(), "PolicyId", "Name", policyDetail.PolicyId);
            return View(policyDetail);
        }

        // GET: PolicyDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyDetail policyDetail = _context.Get(id);
            if (policyDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(_context.GetClients(), "ClientId", "CompleteName", policyDetail.ClientId);
            ViewBag.PolicyId = new SelectList(_context.GetPolicies(), "PolicyId", "Name", policyDetail.PolicyId);
            return View(policyDetail);
        }

        // POST: PolicyDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyDetailId,PolicyId,ClientId,Status")] PolicyDetail policyDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Update(policyDetail);
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(_context.GetClients(), "ClientId", "CompleteName", policyDetail.ClientId);
            ViewBag.PolicyId = new SelectList(_context.GetPolicies(), "PolicyId", "Name", policyDetail.PolicyId);
            return View(policyDetail);
        }

        // GET: PolicyDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyDetail policyDetail = _context.Get(id);
            if (policyDetail == null)
            {
                return HttpNotFound();
            }
            return View(policyDetail);
        }

        // POST: PolicyDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _context.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
