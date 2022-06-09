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
using WPF_Project.Models;
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

        // public MainWindow() { InitializeComponent(); }
        public MainWindow(ITaskService taskService)
        {
            InitializeComponent();

            _taskService = taskService;

            // Tasks_todo = new() {
            //         new BoardTask{
            //             ID= new Guid(),
            //             Title= "Some task 1",
            //             Description= "Don't",
            //             Tags= null,
            //             SubTasks= null,
            //             Column_ID= 1,
            //             Column= new BoardColumn { ID= 1, Name= "To Do" }
            //         },
            //         new BoardTask{
            //             ID= new Guid(),
            //             Title= "Some task 2",
            //             Description= "Don't",
            //             Tags= null,
            //             SubTasks= null,
            //             Column_ID= 1,
            //             Column= new BoardColumn { ID= 1, Name= "To Do" }
            //         }
            //     };

            FetchDataAsync();
            TaskList_todo.ItemsSource = Tasks_todo;
            _taskService = taskService;
        }

        private async System.Threading.Tasks.Task FetchDataAsync()
        {
            Tasks_todo = (await _taskService.GetAllTasksOfColumnAsync(1)).Match(
                    item => item.ToList(),
                    error => { Console.WriteLine(error); return new List<BoardTask>(); }
                );
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
