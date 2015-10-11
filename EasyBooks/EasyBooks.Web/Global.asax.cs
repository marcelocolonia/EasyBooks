using EasyBooks.Business;
using EasyBooks.DAL;
using EasyBooks.Domain;
using System.Web.Mvc;
using System.Web.Routing;

namespace EasyBooks.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IoC.Bind<IGenericRepository<Book>, GenericRepository<Book>>();
            IoC.Bind<IBookService, BookService>();
        }
    }
}
