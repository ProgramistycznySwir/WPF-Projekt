using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

// TODO_Low: Fix namespace pollution. It requires solving how to propperly link resources in .xaml 
namespace WPF_Project
{
    public class BoardTaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Task.Model((Models.BoardTask)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as Task.Model)?.Task!;
        }
    }
}
