using FormGenerator.Data;
using System.Text;

namespace FormGenerator.Model
{
    public static class Generator
    {
        public static  string GenerateTextAttributes(string id, string name, string value,string @class, bool? disabled, string placeholder, bool? required)
        {
            var sb = new StringBuilder();

            sb.Append($" id=\"{id}\"");
            sb.Append($" name=\"{name}\"");
            if(value != "")
            {
                sb.Append($" value=\"{value}\"");
            }
            if(@class != "") 
            {
                
                sb.Append($" class=\"{@class}\"");
            }
            if((disabled.HasValue)  && (disabled.Value)) 
            {
                    sb.Append($" disabled");            
            }
            if(placeholder != "")
            {
                sb.Append($" placeholder=\"{placeholder}\"");
            }
            if((required.HasValue) && (required.Value)) 
            {
                
                sb.Append($" required");
            }
            return sb.ToString();
        }
        public static string GenerateLabel(string id, string label)
        {
            return $"<br><label for=\"{id}\">{label}</label><br>";
        }
        public static void CheckValidationRule(string rule)
        {
            var result = new ValidationRuleType();
            if(!ValidationRuleType.TryParse(rule, out result))
            {
                throw new ArgumentException("Incorrect validation type");
            }

        }
    }
}