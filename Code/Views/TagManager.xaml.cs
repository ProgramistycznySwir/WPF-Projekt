using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Project.Helpers;
using WPF_Project.Models.Database;
using WPF_Project.Services.Interfaces;

namespace WPF_Project.Views
{
    /// <summary>
    /// Interaction logic for TagManager.xaml
    /// </summary>
    public partial class TagManager : Window
    {
        public ObservableCollection<Tag> Tags;

        private readonly ITagService _tagService;

        public TagManager()
        {
            InitializeComponent();

            _tagService = ITagService.instance;

            Tags = _tagService.GetTagsCollectionAsync().Result.IfFail(ResultHandlers<ObservableCollection<Tag>>.ErrorDefault);
            TagList.ItemsSource = Tags;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
