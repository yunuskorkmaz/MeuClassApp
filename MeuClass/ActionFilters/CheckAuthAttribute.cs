using MeuClass.Business.Repository;
using System.Web.Mvc;
using System.Web.Routing;

namespace MeuClass.ActionFilters
{
    internal class CheckAuthAttribute : ActionFilterAttribute
    {
        private UserRole userRole;

        public CheckAuthAttribute(UserRole role = UserRole.AllUser)
        {
            userRole = role;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["user_id"] == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Login");
                redirectTargetDictionary.Add("controller", "Home");
               

                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            else
            {
                switch (userRole)
                {
                    //case UserRole.OnlyAdmin:
                    //        var id = (int)filterContext.HttpContext.Session.Contents["user_id"];
                    //        var usertype = UserRepository.Instance.GetUserTypeByID(id);
                    //        if(usertype.UserTypeName)

                    //    break;
                    //case UserRole.OnlyStudent:

                    //    break;
                    //case UserRole.OnlyTeacher:

                    //    break;
                    //default:
                    //    break;
                   

                        

                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}