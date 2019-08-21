﻿using System;
using System.Collections.Generic;

namespace DTO.DTOs.ContentBaseDTOs
{
    public abstract class ContentBaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastChangedDate { get; set; }

        public ICollection<ContentBaseDTO> Children { get; set; }

        public int? ParentContentItemId { get; set; }

        public ContentBaseDTO ParentContentItem { get; set; }
    }
}
