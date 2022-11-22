using AutoStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IAutoRepository repository;
        public NavController(IAutoRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Autos
                    .Select(m => m.Category)
                    .Distinct()
                    .OrderBy(x => x);
            return PartialView(categories);
        }
        
    }
}