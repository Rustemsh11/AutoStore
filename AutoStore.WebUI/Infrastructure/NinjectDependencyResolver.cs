using AutoStore.Domain.Abstract;
using AutoStore.Domain.Concrete;
using AutoStore.WebUI.Infrastructure.Abstract;
using AutoStore.WebUI.Infrastructure.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace AutoStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public void AddBindings() 
        {

            kernel.Bind<IAutoRepository>().To<DbAutoRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}