namespace FormGenerator.Model
{
        public class Item
    {
        public string type { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public string placeholder { get; set; }
        public bool? required { get; set; }
        public ValidationRules validationRules { get; set; }
        public string value { get; set; }
        public string label { get; set; }
        public string @class { get; set; }
        public bool? disabled { get; set; }
        public bool? @checked { get; set; }
        public string text { get; set; }
        
        public List<Option> options { get; set; }
        public List<RadioItem> items{get; set;}
    }
}