using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace AnimalWars
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TelemetryErrorFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class TelemetryErrorFilter : IExceptionFilter
    {
        private readonly TelemetryClient _telemetryClient;

        public TelemetryErrorFilter()
        {
            _telemetryClient = new TelemetryClient();
        }

        public void OnException(ExceptionContext filterContext)
        {
            var gnuid = Guid.NewGuid().ToString("N").Substring(26, 6);
            //filterContext.Controller.ViewBag.ErrorGnuid = gnuid;
            filterContext.HttpContext.Items["UniqueErrorId"] = gnuid;
            var properties = new Dictionary<string, string> {{"UniqueErrorId", gnuid}};
            _telemetryClient.TrackException(filterContext.Exception, properties);
        }
    }
}
