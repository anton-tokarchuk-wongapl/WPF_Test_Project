using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities.ContentEntities
{
    public abstract class ContentBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastChangedDate { get; set; }

        public virtual ICollection<ContentBaseEntity> Children { get; set; }

        [ForeignKey("ParentContentItem")]
        public int? ParentContentItemId { get; set; }

        public virtual ContentBaseEntity ParentContentItem { get; set; }
    }
}
