using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using WPF_Project.Helpers;
using WPF_Project.Models;
using WPF_Project.Services.Interfaces;
using WPF_Project.Services;
using Microsoft.EntityFrameworkCore;

namespace WPF_Project
{
    /// <summary>
    /// Logika interakcji dla klasy Task.xaml
    /// </summary>
    public partial class Task : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty BoardTask_Property = DependencyProperty.Register("BoardTask",
                typeof(BoardTask),
                typeof(Task),
                new PropertyMetadata(BoardTask_Property_OnChanged));

        private static void BoardTask_Property_OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Task c = d as Task;
            if (c is null)
                return;
            c.BoardTask_Property_OnChanged();
            //PropertyChangedEventHandler h = c.PropertyChanged;
            //if (h is not null)
            //    h(c, new PropertyChangedEventArgs(nameof(BoardTask)));
        }
        public void BoardTask_Property_OnChanged()
        {
            OnPropertyChanged(nameof(BoardTask));
        }

        public BoardTask BoardTask
        {
            get => this.GetValue(BoardTask_Property) as BoardTask;
            set => this.SetValue(BoardTask_Property, value);
        }
        // TODO_AntiPattern: This direct construction of service is anti-pattern, but since wpf is bigger anti-pattern, we have to use parameterless constructor here.
        //public static readonly DependencyProperty TagService_Property = DependencyProperty.Register("_tagService", typeof(ITagService), typeof(Task));
        //public ITagService _tagService
        //{
        //    get => this.GetValue(TagService_Property) as ITagService;
        //    set => this.SetValue(TagService_Property, value);
        //}
        private readonly ITaskService _taskService;
        private readonly ITagService _tagService;

        public ObservableCollection<Tag> Tags;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string argName)
        {
            var handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(argName));
        }

        public Task()
        {
            InitializeComponent();
            _taskService = ITaskService.instance;
            _tagService = ITagService.instance;

            //this.DataContext = BoardTask;

            FetchData();

            datePicker1.BlackoutDates.AddDatesInPast();
            datePicker1.BlackoutDates.Add(new CalendarDateRange(DateTime.Now));
        }

        private void FetchData()
        {
            //var result = _tagService.GetAllTasksOfColumnAsync(1).Result;
            Tags = _tagService.GetTagsCollectionAsync().Result.Match(
                    some => some,
                    ResultHandlers<ObservableCollection<Tag>>.ErrorDefault
                );
            //Tags = TagService.DEBUG_GetTagsCollectionAsync().Result.Match(
            //        some => some,
            //        ResultHandlers<ObservableCollection<Tag>>.ErrorDefault
            //    );
            int _ = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void tb_Title_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            BoardTask = (await _taskService.UpdateTaskAsync(BoardTask)).Match(
                    some => some,
                    ResultHandlers<BoardTask>.ErrorDefault
                );
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Priority_Click(object sender, RoutedEventArgs e)
        {
            BoardTaskPriority priority = (BoardTaskPriority)((int)(BoardTask.Priority + 1) % 3);
            var boardTask = new BoardTask {
                    ID= BoardTask.ID,
                    Title= BoardTask.Title,
                    Description= BoardTask.Description,
                    Priority= priority,
                    Tags= BoardTask.Tags,
                    SubTasks= BoardTask.SubTasks,
                    Column_ID= BoardTask.Column_ID,
                    Column= BoardTask.Column
                };
            //BoardTask = boardTask;
            this.SetValue(BoardTask_Property, boardTask);
            //OnPropertyChanged("Priority");
            //OnPropertyChanged(nameof(BoardTask_Property));
        }
    }
}
