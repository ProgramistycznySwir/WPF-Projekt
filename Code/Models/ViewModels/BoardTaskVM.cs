using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_Project.Models.Database;

namespace WPF_Project.Models.ViewModels
{
    public class BoardTaskVM : INotifyPropertyChanged
    {
        //Guid __ID;
        public Guid ID { get; set; }
        string __Title;
        public string Title { get => __Title; set { __Title = value; OnPropertyChanged(nameof(Title)); } }
        string __Description;
        public string Description { get => __Description; set { __Description = value; OnPropertyChanged(nameof(Description)); } }
        BoardTaskPriority __Priority;
        public BoardTaskPriority Priority { get => __Priority; set { __Priority = value; OnPropertyChanged(nameof(Priority)); } }

        //public ICollection<Tag>? Tags { get; set; }
        public ICollection<TagVM> Tags { get; set; }
        //public ICollection<SubTask>? SubTasks { get; set; }
        public ICollection<SubTask> SubTasks { get; set; }
        public float CompletionRate { get => (SubTasks is null || SubTasks.Count is 0) ? 1 : (SubTasks.Fold(0, (aggr, curr) => aggr + (curr.IsFinished ? 1 : 0)) / (float)SubTasks.Count); set { } }
        int __Column_ID;
        public int Column_ID { get => __Column_ID; set { __Column_ID = value; OnPropertyChanged(nameof(Column_ID)); } }
        //BoardColumn __Column;
        public BoardColumn Column { get; set; }

        public bool IsNotColumnLeftmost { get => Column_ID != 1; set { } }
        public bool IsNotColumnRightmost { get => Column_ID != MainWindow.NumberOfColumns; set { } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string argName)
        {
            if (PropertyChanged is null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(argName));
        }


        public BoardTask ToDB()
            => new BoardTask {
                ID = ID,
                Title = Title,
                Description = Description,
                Priority = Priority,
                Tags = Tags.Filter(e => e.IsChecked).Map(e => e.ToDB()).ToList(),
                SubTasks = SubTasks?.Select(e => e)?.ToList(),
                Column_ID = Column_ID,
                Column = Column
            };
    }
}
