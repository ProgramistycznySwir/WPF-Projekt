using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_Project.Models.Database;

namespace WPF_Project.Models.ViewModels
{
    public class TagVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public bool IsChecked { get; set; }

        public Tag ToDB()
            => new Tag {
                ID = ID,
                Name = Name,
                Color = Color,
            };
    }
}
