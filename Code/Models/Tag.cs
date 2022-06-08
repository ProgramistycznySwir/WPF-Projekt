using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_Project.Models
{
    public class Tag
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public byte Color_A { get; set; }
        public byte Color_R { get; set; }
        public byte Color_G { get; set; }
        public byte Color_B { get; set; }
        [NotMapped]
        public Color Color {
                get => Color.FromArgb(Color_A, Color_R, Color_G, Color_B);
                set => (Color_A, Color_R, Color_G, Color_B) = (value.A, value.R, value.G, value.B);
        }

        public ICollection<BoardTask> Tasks { get; set; }
    }
}
