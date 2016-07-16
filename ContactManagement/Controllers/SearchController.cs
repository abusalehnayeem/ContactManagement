using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagement.Core.Entity;
using ContactManagement.Data;
using PagedList;

namespace ContactManagement.Controllers
{
    public class SearchController : Controller
    {
        private readonly IGenericRepository<Contact> _repository;

        public SearchController()
        {
            _repository = new GenericRepository<Contact>();
        }

        // GET: Search
        public ActionResult Index()
        {
            string searchString = Request.Form["Search"];
            var queryableData = !String.IsNullOrEmpty(searchString) ? _repository.Table.Where(c => c.Name.Contains(searchString) || c.Phone.Contains(searchString)) : _repository.Table;
            return View(queryableData.OrderBy(c => c.Id).ToList());
        }
    }
}
