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

namespace WPF_Project
{
    /// <summary>
    /// Logika interakcji dla klasy Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        public static readonly DependencyProperty BoardTask_Property = DependencyProperty.Register("BoardTask", typeof(BoardTask), typeof(Task));
        public BoardTask BoardTask
        {
            get => this.GetValue(BoardTask_Property) as BoardTask;
            set => this.SetValue(BoardTask_Property, value);
        }

        private readonly ITagService _tagService;

        public ObservableCollection<Tag> Tags;

        public Task(ITagService tagService)
        {
            InitializeComponent();
            // TODO_AntiPattern: This direct construction of service is anti-pattern, but since wpf is bigger anti-pattern, we have to use parameterless constructor here.
            _tagService = tagService;

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
            int _ = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        public class Model : INotifyPropertyChanged
        {
            public BoardTask Task;
            public MyBehaviourSubject<Color> FillColor;

            public Model(BoardTask task)
            {
                Task = task;
                FillColor = new(PropertyChanged!);
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            private void OnPropertyChanged(string argName)
            {
                var handler = PropertyChanged;
                if (handler is not null)
                    handler(this, new PropertyChangedEventArgs(argName));
            }
        }
    }
}
