using AutoStore.Domain.Entities;
using System.Web.Mvc;

namespace AutoStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string SESSION_KEY = "Cart";
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            //get object Cart from session
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[SESSION_KEY];
            }
            //create object Cart if he is not in session
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SESSION_KEY] = cart;
                }
            }

            return cart;
        }
    }
}