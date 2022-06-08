using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WPF_Project.Data;
using WPF_Project.Models;
using WPF_Project.Services.Interfaces;

namespace WPF_Project.Services
{
    public class ColumnService : IColumnService
    {
        private readonly AppDbContext _context;

        public ColumnService(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Column>> GetAllColumnsAsync()
        {
            throw new NotImplementedException();
        }
    }
}