using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models.Database
{
    public class BoardColumn
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<BoardTask>? Tasks { get; set; }
    }
}
