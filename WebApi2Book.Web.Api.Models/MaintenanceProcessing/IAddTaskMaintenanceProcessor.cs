
namespace WebApi2Book.Web.Api.Models.MaintenanceProcessing
{
   public interface IAddTaskMaintenanceProcessor
    {
        Task AddTask(NewTask newTask);
    }
}
