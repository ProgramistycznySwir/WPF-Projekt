using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class Column
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
    }
}
