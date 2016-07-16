using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagement.Core.Entity;
using ContactManagement.Data;

using PagedList;

namespace ContactManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Contact> _repository;

        public HomeController()
        {
            _repository = new GenericRepository<Contact>();
        }

        public ActionResult Index(int? page, string searchString)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            IQueryable<Contact> queryableData = !String.IsNullOrEmpty(searchString) ? _repository.Table.Where(c => c.Name.Contains(searchString) || c.Phone.Contains(searchString)) : _repository.Table;
            return View(queryableData.OrderBy(c=>c.Id).ToPagedList(pageNumber,pageSize));
        }

        public ActionResult SearchTest()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ViewResult Details(int? id)
        {
            if (id <= 0)
            {
                throw new Exception("Id can't be blank???");
            }
            return View(_repository.GetById(id));
        }

        public ActionResult Edit(int id)
        {
            Contact contact = _repository.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(contact);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, " +
                                             "and if the problem persists see your system administrator.");
            }
            return View(contact);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (id <= 0)
            {
                throw new Exception("Id can't be blank???");
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, " +
                                       "and if the problem persists see your system administrator.";
            }
            var contact = _repository.GetById(id);
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //try
            //{
                Contact contact = _repository.GetById(id);
                _repository.Delete(contact);
            //}
            //catch (DataException)
            //{
            //    return RedirectToAction("Delete",
            //        new System.Web.Routing.RouteValueDictionary
            //        {
            //            {"id", id},
            //            {"saveChangesError", true}
            //        });
            //}
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Insert(contact);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists see your system administrator.");
            }
            return View(contact);
        }
    }
}