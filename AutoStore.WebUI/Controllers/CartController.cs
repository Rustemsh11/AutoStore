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
    public class CartController : Controller
    {
        private IAutoRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IAutoRepository repo, IOrderProcessor order)
        {
            repository = repo;
            orderProcessor = order;
        }
        public ViewResult Checkout()
        {
            return View(new ShopingDetails());

        }  
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShopingDetails shopingDetails)
        {
            if (cart.cartLines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }
            if (ModelState.IsValid)
            {
                //orderProcessor.ProcessOrder(cart, shopingDetails);
                cart.ClearList();
                return View("Completed");
            }
            else
            {
                return View(shopingDetails);
            }
        }

        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult AddToCart(Cart cart, int autoId, string returnUrl)
        {
            Auto auto = repository.Autos.FirstOrDefault(a => a.AutoId == autoId);

            if (auto != null)
            {
                cart.AddItem(auto, 1);
            }
            return RedirectToAction("Index",  new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int autoId, string returnUrl)
        {
            Auto auto = repository.Autos.FirstOrDefault(a => a.AutoId == autoId);
            if (auto != null)
            {
                cart.RemoveLine(auto);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult CartInfo(Cart cart)
        {
            return PartialView(cart);
        }
    }
}