using AutoStore.Domain.Abstract;
using AutoStore.Domain.Entities;
using AutoStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoStore.WebUI.Controllers
{
    public class AutoController : Controller
    {
        IAutoRepository repository;
        public int pageSize = 4;
        public AutoController(IAutoRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category,int page=1)
        {
            AutoPagingListView model = new AutoPagingListView
            {
                Autos = repository.Autos
                    .Where(c => category == null || c.Category == category)
                    .OrderBy(m => m.AutoId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    ItemPerPage = pageSize,
                    ThisPage = page,
                    TotalItems = category==null?repository.Autos.Count():repository.Autos.Where(a=>a.Category==category).Count()
                },
                CurrentCategory = category
                
            };
            return View(model);

           
        }
        public FileContentResult GetImage(int autoId)
        {
            Auto auto = repository.Autos.FirstOrDefault(a => a.AutoId == autoId);
            if (auto != null)
            {
                return File(auto.ImageData, auto.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}