using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Json
{
	public static class ModuleJson
	{
		public static void DoNotCacheJsonResponse(this NancyModule module)
		{
			module.After.AddItemToEndOfPipeline(ctx =>
			{
				if (Json.IsJsonContentType(ctx.Response.ContentType))
				{
					//response is json, so set caching...
					ctx.Response.Headers["Cache-Control"] = "no-cache, must-revalidate";
					ctx.Response.Headers["Expires"] = "Mon, 26 Jul 1997 05:00:00 GMT";
					ctx.Response.Headers["Pragma"] = "no-cache";
				}
			});
		}
	}
}
