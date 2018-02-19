using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MeuClass.Filters
{
    public class CheckAuthAttribute : FilterAttribute,IActionFilter
    {

        private UserRole userRole;
        private ActionExecutingContext filterContext;

        public CheckAuthAttribute(UserRole role = UserRole.AllUser)
        {
            userRole = role;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.filterContext = filterContext;
            if (filterContext.HttpContext.Session.Contents["user_id"] == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Login");
                redirectTargetDictionary.Add("controller", "Home");

                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            else
            {

                var id = Convert.ToInt32(filterContext.HttpContext.Session.Contents["user_id"]);
                var result = UserRepository.Instance.GetUserType(id);

                if(result.Success == true)
                {
                    switch (userRole)
                    {
                        case UserRole.OnlyAdmin:
                            Redirect(1, result.Data);
                            break;
                        case UserRole.OnlyStudent:
                            Redirect(3, result.Data);
                            break;
                        case UserRole.OnlyTeacher:
                            Redirect(2, result.Data);
                            break;
                        default:
                            break;
                    }
                }
              
              
            }
        }

        public void Redirect(int userroletypeid,int usertypeid)
        {
            if(usertypeid != userroletypeid)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Error");
                redirectTargetDictionary.Add("area", "Admin");

                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
        }

        
    }
}