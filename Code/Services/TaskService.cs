using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Services.Interfaces;

namespace WPF_Project.Services
{
    internal class TaskService : ITaskService
    {
        public Task<IEnumerable<Task>> GetAllTasksWithTagAsync(Guid taskID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task>> GetTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
