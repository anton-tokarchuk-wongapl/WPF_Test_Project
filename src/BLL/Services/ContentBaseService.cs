using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using DAL.Entities.ContentEntities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using BLL.Services.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class ContentBaseService : IContentBaseService
    {
        private readonly IRepository repository;

        private readonly MapperConfiguration configuration;

        private readonly IMapper mapper;

        private readonly string stringConnection = @"C:\Users\atokar\Documents\WPF_Test_Project\localdb\localdb.sdf";

        public ContentBaseService()
        {
            repository = new ContentBaseRepository(stringConnection);

            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContentBaseEntity, ContentBaseModel>()
                   .Include<ContentFileEntity, ContentFileModel>()
                   .Include<ContentFolderEntity, ContentFolderModel>()
                   .ReverseMap();
                cfg.CreateMap<ContentFileEntity, ContentFileModel>()
                   .ReverseMap();
                cfg.CreateMap<ContentFolderEntity, ContentFolderModel>()
                   .ReverseMap();
            });

            mapper = configuration.CreateMapper();
        }

        public ContentBaseModel GetContentItemById(int id)
            => mapper.Map<ContentBaseModel>(repository.GetContentItemById(id));

        public void Create(ContentBaseModel item)
            => repository.Create(mapper.Map<ContentBaseEntity>(item));

        public void CreateRange(IEnumerable<ContentBaseModel> collection)
            => repository.CreateRange(mapper.Map<ContentBaseModel[], IEnumerable<ContentBaseEntity>>(collection.ToArray()));

        public IEnumerable<ContentBaseModel> GetContentItemsList()
            => mapper.Map<ContentBaseEntity[], ObservableCollection<ContentBaseModel>>(repository.GetContentItemsList().ToArray());

        public void Save()
            => repository.Save();

        public void Update(ContentBaseModel item)
            => repository.Update(mapper.Map<ContentBaseEntity>(item));

        public void Remove(ContentBaseModel item)
            => repository.Remove(mapper.Map<ContentBaseEntity>(item));
    }
}
