using System.Web.Mvc;
using ReactJS.Sample.ApiControllers;

namespace ReactJS.Sample.Controllers
{
    /// <summary>
    /// Controller for the home pages.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Home of the BPMN diagram sample.
        /// </summary>
        /// <remarks> GET: /Home/ </remarks>
        /// <returns>ActionResult that renders the main page.</returns>
        public ActionResult Index()
        {
            var commentsApi = new CommentsApiController();
            return this.View(commentsApi.Get());
        }
    }
}
