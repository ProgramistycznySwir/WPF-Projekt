using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    internal class Tag
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
