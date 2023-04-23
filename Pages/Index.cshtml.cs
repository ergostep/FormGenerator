using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FormGenerator.Model;

namespace FormGenerator.Pages;

public class IndexModel : PageModel
{
    public FormModel form;
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    

    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void OnGet()
    {
        var jsonPath = _configuration["JsonPath"];
        form = jsonPath is not null ? new FormModel(jsonPath) : new FormModel("test1.json");
    }
}
