using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class Tag
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<Models.Task> Tasks { get; set; }
        public Guid Category_ID { get; set; }
        public TagCategory Category { get; set; }
    }
}
