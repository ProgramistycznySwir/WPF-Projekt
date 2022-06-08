using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.Services.Interfaces
{
    internal interface ITaskService
    {
        Task<BoardTask> AddTaskAsync(BoardTask newTask);

        Task<IEnumerable<BoardTask>> GetAllTasksWithTagAsync(Guid taskID);
        Task<IEnumerable<BoardTask>> GetAllTasksOfColumnAsync(Guid columnID);
        Task<IEnumerable<BoardTask>> GetTaskAsync(Guid id);

        Task<BoardTask> UpdateTaskAsync(BoardTask task);

        Task<BoardTask> DeleteTaskAsync(Guid id);
    }
}
