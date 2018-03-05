using System.Web.Mvc;

namespace MeuClass.Areas.Partial
{
    public class PartialAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Partial";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Partial_default",
                "Partial/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}