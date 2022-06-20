using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Project.Data;
using WPF_Project.Helpers;
using WPF_Project.Models.Database;
using WPF_Project.Models.ViewModels;
using WPF_Project.Services;
using WPF_Project.Services.Interfaces;


namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ObservableCollection<BoardTask>> Tasks { get; set; }
        private readonly ITaskService _taskService;
        private readonly AppDbContext _dbContext;

        public const int NumberOfColumns = 3;

        public MainWindow(AppDbContext dbContext, ITaskService taskService, ITagService tagService, IColumnService columnService)
        {
            InitializeComponent();

            _dbContext = dbContext;
            _taskService = taskService;
            // TODO_AntiPattern
            ITaskService.instance = taskService;
            ITagService.instance = tagService;
            IColumnService.instance = columnService;

            FetchDataAsync();
            TaskList_todo.ItemsSource       = Tasks[0];
            TaskList_inProgress.ItemsSource = Tasks[1];
            TaskList_done.ItemsSource       = Tasks[2];
            _taskService = taskService;
        }

        private async void FetchDataAsync()
        {
            var tasks = Enumerable.Range(1, NumberOfColumns).Map(i => _taskService.GetAllTasksOfColumnAsync(i));

            await System.Threading.Tasks.Task.WhenAll(tasks);

            Tasks = tasks.Map(task => new ObservableCollection<BoardTask>(task.Result.IfFail(ResultHandlers<IEnumerable<BoardTask>>.ErrorDefault))).ToList();
        }

        public void MoveTask(BoardTask task, int toColumnID)
        {
            int fromColumnIdx = task.Column_ID - 1;

            // For deletion from Tasks lists.
            task = Tasks[fromColumnIdx].First(e => e.ID == task.ID);
            Tasks[fromColumnIdx].Remove(task);
            task = _taskService.MoveTask(task.ID, toColumnID).Result.IfFail(ResultHandlers<BoardTask>.ErrorDefault);
            Tasks[toColumnID - 1].Add(task);
        }

        public void DeleteTask(BoardTask task)
        {
            int columnIdx = task.Column_ID - 1;

            _taskService.DeleteTaskAsync(task.ID).Result.IfFail(ResultHandlers<BoardTask>.ErrorDefault);
            // For deletion from Tasks lists.
            task = Tasks[columnIdx].First(e => e.ID == task.ID);
            Tasks[columnIdx].Remove(task);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private async void btn_AddTask_Click(object sender, RoutedEventArgs e)
        {
            var task = (await _taskService.AddTaskAsync(new BoardTask {Column_ID = 1})).Match(
                    some => some,
                    ResultHandlers<BoardTask>.ErrorDefault
                );
            Tasks[0].Add(task);
            //TaskList_todo.Items.Refresh();
        }
    }
}
