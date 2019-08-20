using System;
using System.Collections.Generic;

namespace DTO.DTOs.ContentBaseDTOs
{
    public class ContentBaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastChangedDate { get; set; }

        public virtual ICollection<ContentBaseDTO> Children { get; set; }

        public int? ParentContentItemId { get; set; }

        public virtual ContentBaseDTO ParentContentItem { get; set; }
    }
}
