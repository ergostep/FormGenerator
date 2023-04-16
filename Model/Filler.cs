using FormGenerator.Data;

namespace FormGenerator.Model
{
    public class Filler:IHtmlElement
    {
        public string GetHtmlRepresentation(Item item)
        {
            return item.message;
        }
    }
}