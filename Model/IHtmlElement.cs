using FormGenerator.Data;

namespace FormGenerator.Model
{
    public interface IHtmlElement
    {
        public string GetHtmlRepresentation(Item item);
        
    }
}