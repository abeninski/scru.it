using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Data;
using Data.Repository;
using Data.Repository.Base;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Scru.it.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterTypes()
        {
            var builder = new ContainerBuilder();

            // Register the Web API controllers.
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assembly);
            builder.RegisterControllers(assembly);

            builder.Register<IDataContext>(c => new DataContext()).InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();

            builder.RegisterType<PostService>().As<IPostService>().InstancePerApiRequest();
            builder.RegisterType<UserScrewService>().As<IUserScrewService>().InstancePerApiRequest();

            var container = builder.Build();
            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}