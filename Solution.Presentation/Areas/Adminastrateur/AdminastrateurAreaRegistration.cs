using System.Web.Mvc;

namespace Solution.Presentation.Areas.Adminastrateur
{
    public class AdminastrateurAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adminastrateur";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Adminastrateur_default",
                "Adminastrateur/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}