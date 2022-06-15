using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WPF_Project.Models;

namespace WPF_Project.Services.Interfaces
{
    public interface IColumnService
    {
        public static IColumnService instance;

        Task<IEnumerable<Column>> GetAllColumnsAsync();
    }
}
