using FormGenerator.Data;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FormGenerator.Model
{
    public class FormModel
    {
        private string _jsonPath;
        private Form _form;
        private string _postMessage;
        public FormModel(string jsonPath)
        {
            _jsonPath = jsonPath;
            LoadJson();
        }
        private List<string> _webElementsHtml = new List<string>();
        public List<string> webElementsHtml
        {
            get { return _webElementsHtml; }
        }
        public string PostMessage
        {
            get{return _postMessage;}
        }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(_jsonPath))
            {
                string json = r.ReadToEnd();
                var obj =  JObject.Parse(json);
                _form = obj["form"].ToObject<Form>();
            }
        }

        public string GetFormHtml()
        {
            _postMessage = _form.postmessage;
            var sb = new StringBuilder();
            string html = "";
            IHtmlElement element = new Filler();
            sb.Append($"<form name=\"{_form.name}\">\n");
            foreach (var item in _form.items)
            {
                switch (item.type)
                {   
                    case "filler":
                        element = new Filler();
                        //html = _element.GetHtmlRepresentation(item);
                        break;
                    case "text":
                        element = new Input();
                        //html = _element.GetHtmlRepresentation(item);
                        break;
                    case "textarea":
                        element = new TextArea();
                        //html = element.GetHtmlRepresentation(item);
                        break;
                    case "checkbox":
                        element = new CheckBox();
                        //html = _element.GetHtmlRepresentation(item);
                        break;
                    case "button":
                        element = new Button();
                        //html = _element.GetHtmlRepresentation(item);
                        break;
                    case "select":
                        element = new Select();
                        //html = _element.GetHtmlRepresentation(item);
                        break;
                    case "radio":
                        //element = new Radio();
                        break;
                    default:
                        throw new Exception("Incorrect element type");
                }
                html = element.GetHtmlRepresentation(item);
                sb.Append(html);
                _webElementsHtml.Add(html);
                
            }
            sb.Append("/n</form>"); 
            return sb.ToString(); 
        }
    }
}