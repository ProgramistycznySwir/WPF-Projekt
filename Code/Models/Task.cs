using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    internal class Task
    {
        [Key]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid Parent_ID { get; set; }
        public Task Parent { get; set; }
    }
}
