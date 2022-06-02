using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Services.Interfaces
{
    internal interface ITagService
    {
        Task<IEnumerable<Task>> GetTagsInCategoryAsync(Guid tagCategoryID);
    }
}
