using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _9tasksRazorPages.Pages;

public class IndexModel : PageModel
{
    public int DayOfYear { get; private set; }
    public char RandomChar { get; private set; }

    public void OnGet()
    {
        DayOfYear = DateTime.Now.DayOfYear;
        RandomChar = "qwertyuiopasdfghjklzxcvbnm"[DateTime.Now.Second % "qwertyuiopasdfghjklzxcvbnm".Length];
    }
}
