using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Services.Interfaces
{
    internal interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTasksWithTagAsync(Guid taskID);
        Task<IEnumerable<Task>> GetTaskAsync(Guid id);
    }
}
