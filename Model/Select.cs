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
            sb.Append(Generator.GenerateLabel(id, item.label));
        }
        sb.Append($"<select");
        sb.Append(Generator.GenerateTextAttributes(id, item.name, item.value, item.@class, item.disabled, item.placeholder, item.required));
        sb.Append(">");
        foreach (var option in item.options)
        {
            sb.Append($" <option value=\"{option.value}\"");
            if ((option.selected.HasValue) && (option.selected.Value))
            {
                sb.Append(" selected");
            }

            sb.Append($">{option.text}");
            sb.Append(" </option>");
        }

        sb.Append("</select>");
        return sb.ToString();     
    }    
}