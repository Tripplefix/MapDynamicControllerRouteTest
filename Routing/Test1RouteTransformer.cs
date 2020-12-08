using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace MapDynamicControllerRouteTest.Routing
{
    public class Test1RouteTransformer : DynamicRouteValueTransformer
    {
        public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            if (values == null)
                return new ValueTask<RouteValueDictionary>(values);

            if (!values.TryGetValue("SeName", out var slugValue) || string.IsNullOrEmpty(slugValue as string))
                return new ValueTask<RouteValueDictionary>(values);

            var slug = slugValue as string;

            if (slug.Equals("test-foo"))
            {
                values["controller"] = "Test";
                values["action"] = "Foo";
                values["sename"] = slug;

                return new ValueTask<RouteValueDictionary>(values);
            }
            else
            {
                return new ValueTask<RouteValueDictionary>(values);
            }
        }
    }
}