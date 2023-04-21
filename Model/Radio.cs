using System.Text;
using FormGenerator.Data;

namespace FormGenerator.Model;
public class Radio : IHtmlElement
{
    public string GetHtmlRepresentation(Item item)
    {
        Generator.CheckValidationRule(item.validationRules.type);
        var sb = new StringBuilder();
        foreach (var radioitem in item.items)
        {
            string id = Guid.NewGuid().ToString();
            if(radioitem.label != "")
            {
                sb.Append("<br>"+Generator.GenerateLabel(id, radioitem.label));
            }
            sb.Append($"<input type=\"radio\"");
            sb.Append(Generator.GenerateTextAttributes(id, item.name, radioitem.value, item.@class, item.disabled, item.placeholder, item.required));
            if(radioitem.@checked)
            {
                sb.Append(" checked");
            }
            sb.Append(">");
        }
        return sb.ToString();     
    }      
}