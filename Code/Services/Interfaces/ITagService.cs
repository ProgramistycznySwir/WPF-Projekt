using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;
using WPF_Project.Models.Database;
using WPF_Project.Models.ViewModels;

namespace WPF_Project.Services.Interfaces
{
    public interface ITagService
    {
        public static ITagService instance;

        Task<Result<Tag>> AddTagAsync(Tag newTag);

        Task<Result<IEnumerable<Tag>>> GetAllTagsAsync();
        Task<Result<ObservableCollection<Tag>>> GetTagsCollectionAsync();
        Task<Result<Tag>> GetTagAsync(Guid tagID);

        Task<Result<Tag>> UpdateTagAsync(Tag tag);

        Task<Result<Tag>> DeleteTagAsync(Guid id);
    }
}
