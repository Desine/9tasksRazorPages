using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _9tasksRazorPages.Pages;

public class RestaurantModel : PageModel
{
    public string? Name { get; private set; }
    public string? Location { get; private set; }

    public void OnGet()
    {
        Name = "But Scrubs";
        Location = "Googel where am I?";
    }
}
