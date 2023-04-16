using FormGenerator.Data;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FormGenerator.Model
{
    public class FormModel
    {
        private string _jsonPath;
        private Form _form;
        private IHtmlElement _element;
        private string _postMessage;
        public FormModel(string jsonPath)
        {
            jsonPath = _jsonPath;
            LoadJson();
        }
        private List<string> _webElementsHtml;
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
            sb.Append($"<form name=\"{_form.name}\">\n");
            foreach (var item in _form.items)
            {
                switch (item.type)
                {   
                    case "filler":
                        _element = new Filler();
                        break;
                    case "text":
                        _element = new Input();
                        break;
                    case "textarea":
                        _element = new TextArea();
                        break;
                    case "checkbox":
                        _element = new CheckBox();
                        break;
                    case "button":
                        _element = new Button();
                        break;
                    case "select":
                        _element = new Select();
                        break;
                    case "radio":
                        _element = new Radio();
                        break;
                    default:
                        throw new Exception("Incorrect element type");
                }
                sb.Append(_element.GetHtmlRepresentation(item));
                 _webElementsHtml.Add(_element.GetHtmlRepresentation(item));
            }
            sb.Append("/n</form>"); 
            return sb.ToString(); 
        }
    }
}