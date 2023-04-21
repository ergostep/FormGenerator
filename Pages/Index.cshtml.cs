using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FormGenerator.Model;

namespace FormGenerator.Pages;

public class IndexModel : PageModel
{
    public InputModel Input{get; set;}
    public FormModel form = new FormModel("test2.json");
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }

    public class InputModel
    {
        public string FormHtmlCode{get; set;}
    }
}
