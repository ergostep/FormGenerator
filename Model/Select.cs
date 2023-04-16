using System.Text;
using FormGenerator.Data;

namespace FormGenerator.Model;
public class Select : IHtmlElement
{
    public string GetHtmlRepresentation(Item item)
    {
        string id = Guid.NewGuid().ToString();
        Generator.CheckValidationRule(item.validationRules.type);
        var sb = new StringBuilder();
        if(item.label != "")
        {
            sb.Append(Generator.GenerateLabel(item.name, item.label));
        }
        sb.Append($"<select");
        sb.Append(Generator.GenerateTextAttributes(id, item.name, item.value, item.@class, item.disabled, item.placeholder, item.required));
        foreach (var option in item.options)
        {
            sb.Append($" <option value=\"{option.value}\"");
            if ((option.selected.HasValue)&&(option.selected.Value))
            {
                sb.Append(" selected");
            }
            sb.Append("> </option>");
        }
        sb.Append("{option.text}>");
        return sb.ToString();     
    }    
}