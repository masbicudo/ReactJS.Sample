using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace ReactJS.Sample.Code
{
    public class RouteDataHttpControllerSelector : DefaultHttpControllerSelector
    {
        class Pattern
        {
            private readonly string[] replacements;
            private readonly string[] items;

            private Pattern(string pattern)
            {
                this.items = Regex.Split(pattern, @"\{([^\{\}]*)\}");
                this.replacements = this.items.Where((c, i) => i % 2 == 1).Distinct().OrderBy(x => x).ToArray();
            }

            public static Pattern Create(string pattern)
            {
                return new Pattern(pattern);
            }

            public bool CanProcess(IHttpRouteData routeData)
            {
                return this.replacements.All(routeData.Values.ContainsKey);
            }

            public string Process(IHttpRouteData routeData)
            {
                return string.Join("", this.items.Select((c, i) => i % 2 == 0 ? c : routeData.Values[c]));
            }
        }

        private readonly Pattern[] patterns;

        public RouteDataHttpControllerSelector(HttpConfiguration configuration, params string[] patterns)
            : base(configuration)
        {
            if (patterns == null)
                throw new ArgumentNullException("patterns");

            if (patterns.Length == 0)
                throw new ArgumentException("The 'patterns' argument must have elements.", "patterns");

            this.patterns = patterns.Select(Pattern.Create).ToArray();
        }

        public override string GetControllerName(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();

            foreach (var eachPattern in this.patterns)
                if (eachPattern.CanProcess(routeData))
                    return eachPattern.Process(routeData);

            return null;
        }
    }
}