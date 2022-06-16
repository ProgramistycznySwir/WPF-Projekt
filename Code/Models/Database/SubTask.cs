using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models.Database
{
    public class SubTask
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }

        public Guid Task_ID { get; set; }
        public BoardTask Task { get; set; }
    }
}
