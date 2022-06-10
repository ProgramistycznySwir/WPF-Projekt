using System;
using System.Collections.Generic;
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
using WPF_Project.Models;
using WPF_Project.Services;
using WPF_Project.Services.Interfaces;


namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BoardTask> Tasks_todo { get; set; }
        private readonly ITaskService _taskService;
        private readonly AppDbContext _dbContext;

        // TODO_AntiPattern: This direct construction of service is anti-pattern, but since wpf is bigger anti-pattern, we have to use parameterless constructor here.
        public ITagService TagServiceForInjection { get => new TagService(_dbContext); set => throw new NotImplementedException(); }

        public MainWindow(ITaskService taskService, AppDbContext dbContext)
        {
            InitializeComponent();

            _taskService = taskService;
            _dbContext = dbContext;

            FetchData();
            TaskList_todo.ItemsSource = Tasks_todo;
            _taskService = taskService;
        }

        private void FetchData()
        {
            var result = _taskService.GetAllTasksOfColumnAsync(1).Result;
            Tasks_todo = result.Match(
                    some => some.ToList(),
                    ResultHandlers<List<BoardTask>>.ErrorDefault
                );
            TaskList_todo.Items.Refresh();

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
            Tasks_todo.Add(task);
            TaskList_todo.Items.Refresh();
        }
    }
}
