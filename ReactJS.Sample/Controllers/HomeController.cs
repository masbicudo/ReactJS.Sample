using System.Web.Mvc;

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
            return this.View();
        }
    }
}
