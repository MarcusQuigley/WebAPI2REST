using System;
using System.Net.Http;
using WebApi2Book.Common;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.QueryProcessors;
using WebApi2Book.Web.Api.Models;
using WebApi2Book.Web.Api.Models.MaintenanceProcessing;

namespace WebApi2Book.Web.Api.MaintenanceProcessing
{
    public class AddTaskMaintenanceProcessor : IAddTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddTaskQueryProcessor _queryProcessor;
        public AddTaskMaintenanceProcessor(IAddTaskQueryProcessor queryProcessor,
        IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }

        public Task AddTask(NewTask newTask)
        {
            var taskEntity = _autoMapper.Map<Data.DataEntities.Task>(newTask);
            _queryProcessor.AddTask(taskEntity);

            var task = _autoMapper.Map<Task>(taskEntity);

            // TODO: Implement link service
            task.AddLink(new Link
            {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:59049/api/v1/tasks/" + task.TaskId,
                Rel = Constants.CommonLinkRelValues.Self
            });

            return task;
        }
    }
}
