﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NederlandsWebsiteVDS.BL
{
    public class MyAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else if (!Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Error/Unauthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}