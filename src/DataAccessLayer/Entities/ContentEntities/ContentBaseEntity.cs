using DAL.Entities.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities.ContentEntities
{
    public class ContentBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ContentTypeEnum Type { get; set; }

        public DateTime LastChangedDate { get; set; }

        public IEnumerable<ContentBaseEntity> Children { get; set; }

        public int? ParentContentItemId { get; set; }

        public ContentBaseEntity ParentContentItem { get; set; }
    }
}
