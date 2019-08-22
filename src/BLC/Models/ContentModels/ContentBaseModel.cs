using System;
using System.Collections.Generic;

namespace BusinessLogicContracts.Models.ContentModels
{
    public abstract class ContentBaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastChangedDate { get; set; }

        public virtual ICollection<ContentBaseModel> Children { get; set; }

        public int? ParentContentItemId { get; set; }

        public ContentBaseModel ParentContentItem { get; set; }
    }
}
