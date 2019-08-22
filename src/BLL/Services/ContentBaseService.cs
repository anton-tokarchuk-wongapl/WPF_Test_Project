using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLC.Interfaces;
using BLC.Models.ContentModels;
using DAL.Entities.ContentEntities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

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
                   .Include<ContentBaseEntity, ContentFileModel>()
                   .Include<ContentBaseEntity, ContentFolderModel>()
                   .ReverseMap();
                cfg.CreateMap<ContentBaseEntity, ContentFileModel>()
                   .ReverseMap();
                cfg.CreateMap<ContentBaseEntity, ContentFolderModel>()
                   .ReverseMap();
            });

            mapper = configuration.CreateMapper();
        }

        public ContentBaseModel GetContentItemById(int id)
            => mapper.Map<ContentBaseModel>(repository.GetContentItemById(id));

        public ICollection<ContentBaseModel> GetFoldersTree()
        {
            var collection = GetContentItemsList();

            var list = collection.Where(x => x.GetType() == typeof(ContentFolderModel) && x.ParentContentItem == null)
                                              .Select(i =>
                                              {
                                                  i.Children = new List<ContentBaseModel>(Flatten(i, x => x.Children.Where(y => y.GetType() == typeof(ContentFolderModel))));
                                                  return i;
                                              });

            return new List<ContentBaseModel>(list);
        }

        public void Update(ContentBaseModel item)
            => repository.Update(mapper.Map<ContentBaseEntity>(item));

        private ICollection<ContentBaseModel> GetContentItemsList()
            => mapper.Map<ContentBaseEntity[], ICollection<ContentBaseModel>>(repository.GetContentItemsList().ToArray());

        private IEnumerable<ContentBaseModel> Flatten(ContentBaseModel source, Func<ContentBaseModel, IEnumerable<ContentBaseModel>> selector)
        {
            return selector(source).Select(c =>
            {
                c.Children = new List<ContentBaseModel>(Flatten(c, selector));
                return c;
            });
        }
    }
}
