﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Data;
using WPF_Project.Models;
using WPF_Project.Services.Interfaces;

namespace WPF_Project.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<BoardTask>> GetAllTasksWithTagAsync(Guid taskID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BoardTask>> GetTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
