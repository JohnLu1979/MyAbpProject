using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyABPProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyABPProjectControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}