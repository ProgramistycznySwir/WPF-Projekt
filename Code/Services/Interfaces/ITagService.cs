using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;
using WPF_Project.Models;

namespace WPF_Project.Services.Interfaces
{
    public interface ITagService
    {
        Task<Result<Tag>> AddTagAsync(Tag newTag);

        Task<Result<IEnumerable<Tag>>> GetAllTagsAsync();
        Task<Result<ObservableCollection<Tag>>> GetTagsCollectionAsync();
        Task<Result<Tag>> GetTagAsync(Guid tagID);

        Task<Result<Tag>> UpdateTagAsync(BoardTask task);

        Task<Result<Tag>> DeleteTagAsync(Guid id);
    }
}
