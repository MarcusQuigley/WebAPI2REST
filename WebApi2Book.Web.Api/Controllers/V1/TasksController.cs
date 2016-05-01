using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2Book.Web.Api.Models;
using WebApi2Book.Web.Api.Models.MaintenanceProcessing;
using WebApi2Book.Web.Common;
using WebApi2Book.Web.Common.Routing;

namespace WebApi2Book.Web.Api.Controllers.V1
{
    [ApiVersionRoutePrefixAttribute("tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        private readonly IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor;
        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor)
        {
            this.addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
        }

        [Route("", Name = "AddTaskRouteV1")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage message, NewTask newTask)
        {
            var task = addTaskMaintenanceProcessor.AddTask(newTask);
            
            return task;
        }
    }
}
