namespace MvcApplication1.Controllers
{
    using System.Web.Mvc;

    public class ChatController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
