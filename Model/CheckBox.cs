using System.Text;
using FormGenerator.Data;

namespace FormGenerator.Model;
public class CheckBox : IHtmlElement
{
   public string GetHtmlRepresentation(Item item)
    {
        string id = Guid.NewGuid().ToString();
        Generator.CheckValidationRule(item.validationRules.type);
        var sb = new StringBuilder();
        if(item.label != "")
        {
            sb.Append(Generator.GenerateLabel(id, item.label));
        }
        sb.Append($"<input type=\"checkbox\"");
        sb.Append(Generator.GenerateTextAttributes(id, item.name, item.value, item.@class, item.disabled, item.placeholder, item.required));
        if((item.@checked.HasValue) &&(item.@checked.Value))
        {
            sb.Append(" checked");
        }
        sb.Append("><br>");
        return sb.ToString();     
    }     
}