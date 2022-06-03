using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Services.Interfaces
{
    internal interface IColumnService
    {
        Task<IEnumerable<Task>> GetAllTasksOfColumnAsync(Guid columnID);
        Task<IEnumerable<Task>> GetAllColumnsAsync();
    }
}
