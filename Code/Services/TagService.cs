using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WPF_Project.Data;
using WPF_Project.Models.Database;
using WPF_Project.Models.ViewModels;
using WPF_Project.Services.Interfaces;

namespace WPF_Project.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;
        static ObservableCollection<Tag> _tags = new ObservableCollection<Tag>(); // It is here so this service could act as single source of truth.
        bool _hasFetchedTags = false;

        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Tag>> AddTagAsync(Tag newTag)
        {
            if (newTag == null)
                throw new ArgumentNullException(nameof(newTag));
            var newTag_entity = await _context.Tags.AddAsync(newTag);
            await _context.SaveChangesAsync();
            _tags.Add(newTag_entity.Entity);
            return newTag_entity.Entity;
        }

        public async Task<Result<ObservableCollection<Tag>>> GetTagsCollectionAsync()
        {
            if (_hasFetchedTags)
                return (Result<ObservableCollection<Tag>>)_tags;
            lock(_tags)
            {
                if (_hasFetchedTags)
                    return (Result<ObservableCollection<Tag>>)_tags;
                _hasFetchedTags = true;
                _tags = new ObservableCollection<Tag>();
                var tags_ = _context.Tags;
                foreach(var tag in tags_)
                    _tags.Add(tag);
            }
            return (Result<ObservableCollection<Tag>>)_tags;
        }
        public async Task<Result<ObservableCollection<Tag>>> DEBUG_GetTagsCollectionAsync() => new ObservableCollection<Tag>() {
                    new Tag { ID= Guid.NewGuid(), Name= "School"},
                    new Tag { ID= Guid.NewGuid(), Name= "Project"},
                };

        // TODO_Deprecated: This way of getting tags is deprecated and shuld be removed in further refactoring.
        public Task<Result<IEnumerable<Tag>>> GetAllTagsAsync()
        {
            throw new NotImplementedException();
            if (_tags is not null)
                return (Task<Result<IEnumerable<Tag>>>)_tags.AsEnumerable();
            return (Task<Result<IEnumerable<Tag>>>)_context.Tags.AsEnumerable();
        }

        public async Task<Result<Tag>> GetTagAsync(Guid tagID)
        {
            var tag = await _context.Tags.FindAsync(tagID);
            if(tag is null)
                return new Result<Tag>(new ArgumentException($"Couldn't get tag with id {tagID}!", nameof(tagID)));
            return tag;
        }

        public Task<Result<Tag>> DeleteTagAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Tag>> UpdateTagAsync(BoardTask task)
        {
            throw new NotImplementedException();
        }
    }
}