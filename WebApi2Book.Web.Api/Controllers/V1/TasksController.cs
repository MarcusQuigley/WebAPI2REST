﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2Book.Web.Api.Models;
using WebApi2Book.Web.Common;
using WebApi2Book.Web.Common.Routing;

namespace WebApi2Book.Web.Api.Controllers.V1
{
    [ApiVersionRoutePrefixAttribute("tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        [Route("", Name = "AddTaskRouteV1")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage message, NewTask newTask)
        {
            return new Task()
            {
                Subject = "In v1, newTask.Subject = " + newTask.Subject
            };
        }
    }
}
