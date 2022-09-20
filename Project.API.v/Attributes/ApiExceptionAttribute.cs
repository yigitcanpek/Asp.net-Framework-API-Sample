﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Project.API.v.Attributes
{
    public class ApiExceptionAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            errorMessage.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = errorMessage;
            
            base.OnException(actionExecutedContext);
        }
    }
}