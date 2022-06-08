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
        Task<IEnumerable<BoardTask>> GetAllTasksWithTagAsync(Guid taskID);
        Task<IEnumerable<BoardTask>> GetTaskAsync(Guid id);
    }
}
