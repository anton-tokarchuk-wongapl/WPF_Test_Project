using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Repositories.Interfaces;
using DAL.Entities.ContentEntities;
using DTO.DTOs.ContentBaseDTOs;

namespace DAL.Repositories
{
    public class ContentBaseRepository : IRepository
    {
        private readonly ContentBaseContext db;

        private readonly MapperConfiguration configuration;

        private readonly IMapper mapper;

        private bool disposed = false;

        public ContentBaseRepository(string connection)
        {
            db = new ContentBaseContext(connection);
            db.Configuration.LazyLoadingEnabled = false;

            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContentBaseEntity, ContentBaseDTO>()
                   .Include<ContentFileEntity, ContentFileDTO>()
                   .Include<ContentFolderEntity, ContentFolderDTO>()
                   .ReverseMap();
                cfg.CreateMap<ContentFileEntity, ContentFileDTO>()
                   .ReverseMap();
                cfg.CreateMap<ContentFolderEntity, ContentFolderDTO>()
                   .ReverseMap();
            });

            mapper = configuration.CreateMapper();
        }

        public ContentBaseDTO GetContentItemById(int id)
            => mapper.Map<ContentBaseDTO>(db.Content.Find(id));

        public ICollection<ContentBaseDTO> GetContentItemsList()
        {
            var collection = db.Content
                               .Include(x => x.Children)
                               .ToArray();

            return mapper.Map<ContentBaseEntity[], ICollection<ContentBaseDTO>>(collection);
        }

        public void Update(ContentBaseDTO item)
        {
            var editableContent = db.Content.Find(item.Id);

            editableContent.Name = item.Name;
            editableContent.Description = item.Description;
            editableContent.LastChangedDate = item.LastChangedDate;

            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
