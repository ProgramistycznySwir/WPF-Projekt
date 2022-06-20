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
using WPF_Project.Services.Interfaces;
using WPF_Project.Services;
using Microsoft.EntityFrameworkCore;
using WPF_Project.Models.Database;
using WPF_Project.Models.ViewModels;

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
            if (BoardTask_ID is not null && Tags is not null)
                _model = _taskService.GetTaskAsync(BoardTask_ID.Value).Result.IfFail(ResultHandlers<BoardTask>.ErrorDefault).ToVM(Tags);
            if (_model is not null)
                OnAnyPropertyChanged();
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
        private void OnAnyPropertyChanged()
        {
            // Don't know why but this bit of code is required if we want notifying about changes to work :/
            if (DataContext != _model)
            {
                DataContext = _model;
                TagsComboBox.ItemsSource = _model.Tags;
                TagsComboBox.Items.Refresh();
                if(_model.SubTasks is not null)
                    TasksComboBox.ItemsSource = _model.SubTasks;
                TasksComboBox.Items.Refresh();
            }
        }

        public Task()
        {
            InitializeComponent();
            // TODO_AntiPattern: This direct construction of service is anti-pattern, but since wpf is bigger anti-pattern, we have to use parameterless constructor here.
            _taskService = ITaskService.instance;
            _tagService = ITagService.instance;

            TasksComboBox.ItemsSource = new List<SubTask>();

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
            // TODO: Move ItemSource definition to .xaml
            OnPropertyChanged(nameof(Tags));
            OnAnyPropertyChanged();
        }

        private void tb_Title_OnIsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // TODO: Make this action async.
            var textBox = sender as TextBox;
            if (_model.Title == textBox!.Text)
                return;
            _model.Title = textBox.Text;
            _model = _taskService.UpdateTaskAsync(_model.ToDB())
                    .Result
                    .IfFail(ResultHandlers<BoardTask>.ErrorDefault)
                    .ToVM(Tags);
            OnAnyPropertyChanged();
        }

        private void btn_Priority_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Make this action async.
            BoardTaskPriority priority = (BoardTaskPriority)((int)(_model.Priority + 1) % 3);
            _model.Priority = priority;
            OnAnyPropertyChanged();
            _model = _taskService.UpdateTaskAsync(_model.ToDB())
                    .Result
                    .IfFail(ResultHandlers<BoardTask>.ErrorDefault)
                    .ToVM(Tags);
            OnAnyPropertyChanged();
        }

        private void cb_Tags_DropDownClosed(object sender, EventArgs e)
        {
            _model = _taskService.UpdateTagsOfTask(_model.ID, _model.ToDB().Tags)
                    .Result
                    .IfFail(ResultHandlers<BoardTask>.ErrorDefault)
                    .ToVM(Tags);
            OnAnyPropertyChanged();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // TODO_HIGH: Add addition of Subtasks and updating of finished tasks.
        //             You can do it via event DropDownClosed.

        private void tb_AddNewSubtask_OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key is not Key.Return)
                return;
            var textBox = sender as TextBox;
            if (textBox is null)
                throw new InvalidOperationException("Tried to use callback meant only for TextBoxes!");
            _model.SubTasks ??= new List<SubTask>();
            _model.SubTasks.Add(new SubTask {
                    Name= textBox.Text,
                    IsFinished= false,
                });
            OnAnyPropertyChanged();
        }

        private void btn_AddSubTask_Click(object sender, RoutedEventArgs e)
        {
            _model.SubTasks ??= new List<SubTask>();
            _model.SubTasks.Add(new SubTask {
                    Name = AddNewSubTask_Text.Text,
                    IsFinished = false,
                });
            _model = _taskService.UpdateSubTasksOfTask(_model.ID, _model.SubTasks)
                    .Result
                    .IfFail(ResultHandlers<BoardTask>.ErrorDefault)
                    .ToVM(Tags);
            OnAnyPropertyChanged();
        }

        public bool IsNotColumnLeftmost => _model.Column_ID != 1;
        public bool IsNotColumnRightmost => _model.Column_ID != MainWindow.NumberOfColumns;

        private void btn_MoveTask_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button is null)
                throw new InvalidOperationException("Tried to use callback meant only for Buttons!");

            bool isRight = button.Name.Contains("Right");

            MainWindow parent = Window.GetWindow(this) as MainWindow;
            if (parent is null)
                throw new InvalidOperationException("This method is meant to be used only in MainWindow context!");

            _model.SubTasks ??= new List<SubTask>();
            _model.SubTasks.Add(new SubTask {
                Name = AddNewSubTask_Text.Text,
                IsFinished = false,
            });
            _model = _taskService.UpdateSubTasksOfTask(_model.ID, _model.SubTasks)
                    .Result
                    .IfFail(ResultHandlers<BoardTask>.ErrorDefault)
                    .ToVM(Tags);
            OnAnyPropertyChanged();
        }
    }
}
