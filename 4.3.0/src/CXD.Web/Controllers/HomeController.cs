using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CXD.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CXDControllerBase
    {
        public ActionResult Index()
        {
            return Redirect("./swagger");
            //return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}