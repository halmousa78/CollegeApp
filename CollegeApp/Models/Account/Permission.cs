using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeApp.Models
{
    public sealed class MyAllowAnonymous : Attribute { }

    public class Permission:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // bool disabled = filterContext.ActionDescriptor.IsDefined(typeof(MyAllowAnonymous), true) ||
            //            filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(MyAllowAnonymous), true);
            //    if (disabled)
            //    {
            //    filterContext.Result = new RedirectToRouteResult(
            //      new System.Web.Routing.RouteValueDictionary
            //      {
            //            {"Controller","Users" },
            //            {"Action","ForgotPassword" }
            //      }
            //      );
            //}
            //else 
            if (HttpContext.Current.Session["UserId"]==null || HttpContext.Current.Session["UserId"].ToString()=="")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"Controller","Account" },
                        {"Action","Login" }
                    }
                    );
            }
        }
    }

    public class ViewPermissionFilter : ActionFilterAttribute
    {
        public int ViewId { get; set; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //bool disabled = filterContext.ActionDescriptor.IsDefined(typeof(MyAllowAnonymous), true) ||
            //          filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(MyAllowAnonymous), true);
            //if (disabled)
            //{
            //    filterContext.Result = new RedirectToRouteResult(
            //     new System.Web.Routing.RouteValueDictionary
            //     {
            //            {"Controller","Users" },
            //            {"Action","ForgotPassword" }
            //     }
            //     );
            //}
            //else
            //{
                try
                {
                    var viewModel = (ViewModel)HttpContext.Current.Session["ViewPermission"];
                    if (viewModel != null)
                    {
                        if (!viewModel.ViewIds.Contains(ViewId))
                        {
                            filterContext.Result = new RedirectToRouteResult(
                                 new System.Web.Routing.RouteValueDictionary
                            {
                        {"Controller","Account" },
                        {"Action","Login" }
                            }
                                );
                        }
                    }

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;

                    filterContext.Result = new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary
                       {
                        {"Controller","Account" },
                        {"Action","Login" }
                       }
                           );

                }

            //}


        }
    }
}