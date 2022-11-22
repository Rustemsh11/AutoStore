using AutoStore.Domain.Abstract;
using AutoStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IAutoRepository repository;
        public AdminController(IAutoRepository repo)
        {
            repository = repo;
        }

        public ViewResult Create()
        {
            return View("Edit", new Auto());
        }

        [HttpPost]
        public ActionResult Delete(int autoId)
        {
            Auto deleteAuto = repository.DeleteAuto(autoId);
            if (deleteAuto != null)
            {
                TempData["message"] = string.Format("Auto \"{0}\" was deleted", deleteAuto.Name);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int autoId)
        {
            Auto auto = repository.Autos.FirstOrDefault(a => a.AutoId == autoId);
            return View(auto);
        }
        [HttpPost]
        public ActionResult Edit(Auto auto, HttpPostedFileBase image=null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    auto.ImageMimeType = image.ContentType;
                    auto.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(auto.ImageData, 0, image.ContentLength);
                }
                repository.SaveAuto(auto);
                TempData["message"] = string.Format("Changes in auto \"{0}\" was saved", auto.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(auto);
            }
        }
        public ViewResult Index()
        {
            return View(repository.Autos);
        }
    }
}