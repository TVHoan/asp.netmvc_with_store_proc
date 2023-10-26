using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using netmvc.Controllers;
using netmvc.Dto.Base;
using netmvc.Dto.Post;
using netmvc.Models;
using netmvc.Repository;
using Unity.Mvc4;

namespace netmvc
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
      container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
      container.RegisterType<IUserStore<ApplicationUser>,UserStore<ApplicationUser>>(); 
      container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
      container.RegisterType<AccountController>(new InjectionConstructor());
      container.RegisterType<DbConnection, SqlConnection>(
        new InjectionFactory(c => new SqlConnection(ConfigurationManager.
          ConnectionStrings["DefaultConnection"].ConnectionString)));      
      container.RegisterType(typeof(IProcRepository), typeof(ProcRepository));
      container.RegisterType(typeof(IPostRepository), typeof(PostRepository));
      /*
      container.RegisterType<PostController>(new InjectionConstructor());
      */
      
    }
  }
}