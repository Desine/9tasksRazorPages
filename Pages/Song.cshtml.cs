using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace _9tasksRazorPages.Pages;

public class SongModel : PageModel
{


    public Song EpickSong { get; set; } = new Song
    {
        Name = "Epick",
        Author = "sigme",
        Year = DateTime.UtcNow.Year.ToString(),
        Text = "Ohh I wanna yeet my horse.\n"
            + "Go on the holy ride.\n"
            + "Though even poop my pents.\n"
            + "I'll spill it on the road."
    };


    public interface ITextRepresentation
    {
        string GetInfo();
    }
    public class Song : ITextRepresentation
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public string Year { get; set; } ="";
        public string Text { get; set; } = "";

        public string GetInfo()
        {
            return $"{Name}\n{Author}\n{Year}\n{Text}";
        }
    }

    public void OnGet()
    {
        string fileData = EpickSong?.GetInfo() ?? "no data";
        System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Song.txt"), fileData);
    }
}
