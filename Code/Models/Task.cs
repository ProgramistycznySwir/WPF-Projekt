using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class Task
    {
        [Key]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<SubTask> SubTasks { get; set; }
        public Guid Column_ID { get; set; }
        public Column Column { get; set; }
    }
}
