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
using WPF_Project.Views.Dialogs;

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

        private void btn_DeleteTag_Click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as FrameworkElement)?.DataContext as Tag;
            if (tag is null)
                throw new InvalidOperationException("It seems there is no tag to delete!");
            MessageBoxResult result = MessageBox.Show($"Do you want to delete tag \"{tag.Name}\"?", "Delete tag", MessageBoxButton.YesNo);
            if (result is not MessageBoxResult.Yes)
                return;

            _tagService.DeleteTagAsync(tag.ID).Result.IfFail(ResultHandlers<Tag>.ErrorDefault);
        }
        private void btn_EditTag_Click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as FrameworkElement)?.DataContext as Tag;
            if (tag is null)
                throw new InvalidOperationException("It seems there is no tag to edit!");
            var dialog = new EditTagDialog(tag);
            if (dialog.ShowDialog() is false)
                return; // Do nothing, when dialog is closed without saving.
            tag = dialog.DataContext as Tag;
            if (tag is null)
                throw new InvalidOperationException("EditTagDialog can't return null!");
            _tagService.UpdateTagAsync(tag);
        }
        private void btn_AddTag_Click(object sender, RoutedEventArgs e)
        {
            var name = TagNameText.Text;
            if(string.IsNullOrWhiteSpace(name))
            {
                MessageBoxResult result = MessageBox.Show("You can't create subtask without name!", "Invalid subtask name", MessageBoxButton.OK);
                return;
            }

            _tagService.AddTagAsync(new Tag {
                Name = name
            });
        }
    }
}
