using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_Project.Models
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
        public ICollection<Tag>? Tags { get; set; }
        //public ICollection<SubTask>? SubTasks { get; set; }
        public ICollection<SubTask>? SubTasks { get; set; }
        int __Column_ID;
        public int Column_ID { get => __Column_ID; set { __Column_ID = value; OnPropertyChanged(nameof(Column_ID)); } }
        //BoardColumn __Column;
        public BoardColumn Column { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string argName)
        {
            if (PropertyChanged is null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(argName));
        }


        public BoardTask ToDB()
            => new BoardTask
            {
                ID = this.ID,
                Title = this.Title,
                Description = this.Description,
                Priority = this.Priority,
                Tags = this.Tags,
                SubTasks = this.SubTasks,
                Column_ID = this.Column_ID,
                Column = this.Column
            };
    }
}
