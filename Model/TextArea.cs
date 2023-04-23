using System.Text;
using FormGenerator.Data;

namespace FormGenerator.Model;
public class TextArea : IHtmlElement
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
        sb.Append($"<textarea type=\"{item.validationRules.type}\"");
        sb.Append(Generator.GenerateTextAttributes(id, item.name, item.value, item.@class, item.disabled, item.placeholder, item.required));
        sb.Append("></textarea>");
        return sb.ToString();     
    }  
    
}