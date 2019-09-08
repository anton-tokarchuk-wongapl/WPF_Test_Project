namespace WPFProject.Helpers.Validation
{
    public class UserInputValidation
    {
        public string ValidateStringProperty(string property)
        {
            string result = string.Empty;

            if (string.IsNullOrWhiteSpace(property))
            {
                result = "Field cannot be empty";
            }
            else if (property.Length > 100)
            {
                result = "Field cannot be more 100 symbols";
            }
            else if (property.Length < 3)
            {
                result = "Field cannot be less of 3 symbols";
            }

            return result;
        }
    }
}
