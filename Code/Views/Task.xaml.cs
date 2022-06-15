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
        public static readonly DependencyProperty BoardTask_Property = DependencyProperty.Register("BoardTask_ID",
                typeof(Guid),
                typeof(Task),
                new PropertyMetadata(BoardTask_Property_OnChanged));

        private static void BoardTask_Property_OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Task c = d as Task;
            if (c is null)
                return;
            c.BoardTask_Property_OnChanged();
        }
        public void BoardTask_Property_OnChanged()
        {
            if (BoardTask_ID is not null)
                _model = _taskService.GetTaskAsync(BoardTask_ID.Value).Result.IfFail(ResultHandlers<BoardTask>.ErrorDefault).ToVM();
            if(_model is not null)
                this.DataContext = _model;
        }

        public Guid? BoardTask_ID
        {
            get => this.GetValue(BoardTask_Property) as Guid?;
            set { this.SetValue(BoardTask_Property, value); }
        }

        private BoardTaskVM _model;
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
        private void OnPropertyAnyChanged()
        {
            // Don't know why but this bit of code is required if we want to notifying about changes to work :/
            if (DataContext != _model)
                DataContext = _model;
        }

        public Task()
        {
            InitializeComponent();
            // TODO_AntiPattern: This direct construction of service is anti-pattern, but since wpf is bigger anti-pattern, we have to use parameterless constructor here.
            _taskService = ITaskService.instance;
            _tagService = ITagService.instance;

            FetchData();

            datePicker1.BlackoutDates.AddDatesInPast();
            datePicker1.BlackoutDates.Add(new CalendarDateRange(DateTime.Now));
        }

        private void FetchData()
        {
            Tags = _tagService.GetTagsCollectionAsync().Result.Match(
                    some => some,
                    ResultHandlers<ObservableCollection<Tag>>.ErrorDefault
                );
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void tb_Title_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_model is null)
                return;
            _model = (await _taskService.UpdateTaskAsync(_model.ToDB())).Match(
                    some => some.ToVM(),
                    ResultHandlers<BoardTaskVM>.ErrorDefault
                );
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Priority_Click(object sender, RoutedEventArgs e)
        {
            BoardTaskPriority priority = (BoardTaskPriority)((int)(_model.Priority + 1) % 3);
            _model.Priority = priority;
            OnPropertyAnyChanged();
        }
    }
}
