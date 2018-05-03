﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Logger;

namespace mvc.Filters
{
    public class EmployeeExceptionFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            FileLogger logger = new FileLogger();
            logger.LogException(filterContext.Exception);
            base.OnException(filterContext);
        }

    }
}