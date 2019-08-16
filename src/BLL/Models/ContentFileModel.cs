using DAL.Entities.Enums;

namespace BLL.Models
{
    public class ContentFileModel : ContentBaseModel
    {
        public ContentFileModel()
        {
            Type = ContentTypeEnum.File;
        }
    }
}
