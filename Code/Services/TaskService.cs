using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using WPF_Project.Data;
using WPF_Project.Models.Database;
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

        public async Task<Result<BoardTask>> AddTaskAsync(BoardTask newTask)
        {
            if (newTask is null)
                return new Result<BoardTask>(new ArgumentNullException(nameof(newTask)));
            var newTask_entity = await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();
            return newTask_entity.Entity;
        }

        public Task<Result<IEnumerable<BoardTask>>> GetAllTasksWithTagAsync(Guid tagID)
        {
            throw new NotImplementedException();
            // var column = await _context.Columns.FindAsync(columnID);
            // if(column is null)
            //     return new Result<IEnumerable<BoardTask>>(new ArgumentException($"Couldn't get tasks!"));
            // return new Result<IEnumerable<BoardTask>>(column.Tasks);
        }

        public async Task<Result<IEnumerable<BoardTask>>> GetAllTasksOfColumnAsync(int columnID)
        {
            var column = _context.Columns // TODO: Potential errors when handling collections, beware.
                    .Include(e => e.Tasks)
                        .ThenInclude(e => e.SubTasks)
                    .Include(e => e.Tasks)
                        .ThenInclude(e => e.Tags)
                    .FirstOrDefault(e => e.ID == columnID);
            //var column = _context.Columns.Find(columnID);
            if (column is null)
                return new Result<IEnumerable<BoardTask>>(new ArgumentException($"Couldn't get tasks!"));
            return new Result<IEnumerable<BoardTask>>(column.Tasks!);
        }

        public async Task<Result<IEnumerable<BoardTask>>> GetAllTasksAsync()
        {
            var tasks = _context.Tasks;
            if(tasks is null)
                return new Result<IEnumerable<BoardTask>>(new ArgumentException($"Couldn't get tasks!"));
            return tasks;
        }

        public async Task<Result<BoardTask>> GetTaskAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if(task is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {id}!", nameof(id)));
            return task;
        }

        public async Task<Result<BoardTask>> UpdateTaskAsync(BoardTask task)
        {
            // TODO: Put check-clause here.
            var taskDB = await _context.Tasks.FindAsync(task.ID);
            if(taskDB is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {task.ID}!", nameof(task.ID)));
            
            taskDB.Title = task.Title;
            taskDB.Description = task.Description;
            taskDB.Priority = task.Priority;
            taskDB.Column_ID = task.Column_ID;
            _context.Tasks.Update(taskDB);
            await _context.SaveChangesAsync();
            return taskDB;
        }
        public async Task<Result<BoardTask>> UpdateTagsOfTask(Guid taskID, IEnumerable<Tag>? tags)
        {
            // TODO: Put check-clause here.
            var taskDB = await _context.Tasks.Include(e => e.Tags).FirstOrDefaultAsync(e => e.ID == taskID);
            if (taskDB is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {taskID}!", nameof(taskID)));
            var allTags = await _context.Tags.ToListAsync();

            taskDB.Tags ??= new List<Tag>();
            tags ??= new List<Tag>();

            var toRemove = taskDB.Tags.Where(e => tags.All(e1 => e1.ID != e.ID));
            foreach (var tag in toRemove)
                taskDB.Tags.Remove(tag);
            var toAdd = tags.Where(e => taskDB.Tags.All(e1 => e1.ID != e.ID));
            foreach (var tag in toAdd)
                taskDB.Tags.Add(allTags.First(e => e.ID == tag.ID));

            _context.Tasks.Update(taskDB);
            await _context.SaveChangesAsync();
            return taskDB;
        }
        public async Task<Result<BoardTask>> UpdateSubTasksOfTask(Guid taskID, IEnumerable<SubTask>? subtasks)
        {
            // TODO: Put check-clause here.
            var taskDB = await _context.Tasks.Include(e => e.SubTasks).FirstOrDefaultAsync(e => e.ID == taskID);
            if (taskDB is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {taskID}!", nameof(taskID)));

            taskDB.SubTasks ??= new List<SubTask>();
            subtasks ??= new List<SubTask>();

            var toRemove = taskDB.SubTasks.Where(e => subtasks.All(e1 => e1.ID != e.ID));
            foreach (var subtask in toRemove)
                taskDB.SubTasks.Remove(subtask);

            foreach (var subtask in taskDB.SubTasks)
                subtask.IsFinished = subtasks.First(e => e.ID == subtask.ID).IsFinished;

            var toAdd = subtasks.Where(e => taskDB.SubTasks.All(e1 => e1.ID != e.ID));
            foreach(var subtask in toAdd)
                taskDB.SubTasks.Add(subtask);

            _context.Tasks.Update(taskDB);
            await _context.SaveChangesAsync();
            return taskDB;
        }

        public async Task<Result<BoardTask>> DeleteTaskAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if(task is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {id}!", nameof(id)));
            var deletedTask = _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return deletedTask.Entity;
        }

        public async Task<Result<BoardTask>> MoveTask(Guid taskID, int toColumn_ID)
        {
            var taskTask = _context.Tasks.FindAsync(taskID).AsTask();
            var columnTask = _context.Columns.FindAsync(toColumn_ID).AsTask();
            await System.Threading.Tasks.Task.WhenAll(taskTask, columnTask);

            var task = taskTask.Result;
            if(task is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {taskID}!", nameof(taskID)));
            var column = columnTask.Result;
            if(column is null)
                return new Result<BoardTask>(new ArgumentException($"There is no task with id {column}!", nameof(column)));
            
            task.Column_ID = column.ID;
            task.Column = column;

            _context.Tasks.Update(task);

            await _context.SaveChangesAsync();
            return task;
        }
    }
}
