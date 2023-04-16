using FormGenerator.Data;

namespace FormGenerator.Model
{
    public class Button : IHtmlElement
    {    
        public string GetHtmlRepresentation(Item item)
        {
            return $"<button class=\"{item.@class}\">{item.text}</button>";
        }
    }
}