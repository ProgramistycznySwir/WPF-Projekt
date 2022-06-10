using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.Services.Interfaces
{
    public interface ITagService
    {
        Task<BoardTask> AddTagAsync(Tag newTag);

        Task<IEnumerable<BoardTask>> GetTag(Guid taskID);

        Task<BoardTask> UpdateTagAsync(BoardTask task);

        Task<BoardTask> DeleteTagAsync(Guid id);
    }
}
