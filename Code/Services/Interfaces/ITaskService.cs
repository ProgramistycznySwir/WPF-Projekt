using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;
using WPF_Project.Models;

namespace WPF_Project.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<Result<BoardTask>> AddTaskAsync(BoardTask newTask);

        Task<Result<IEnumerable<BoardTask>>> GetAllTasksWithTagAsync(Guid tagID);
        Task<Result<IEnumerable<BoardTask>>> GetAllTasksOfColumnAsync(int columnID);
        Task<Result<IEnumerable<BoardTask>>> GetAllTasksAsync();
        Task<Result<BoardTask>> GetTaskAsync(Guid id);

        Task<Result<BoardTask>> UpdateTaskAsync(BoardTask task);
        Task<Result<BoardTask>> MoveTask(Guid taskID, int toColumn);

        Task<Result<BoardTask>> DeleteTaskAsync(Guid id);
    }
}
