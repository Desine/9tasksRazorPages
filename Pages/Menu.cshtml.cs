using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace _9tasksRazorPages.Pages;

public class MenuModel : PageModel
{


    public List<string> DrinksInfo { get; set; } = new();


    public interface ITextRepresentation
    {
        string GetInfo();
    }
    public abstract class BaseDrink : ITextRepresentation
    {
        public string? Name { get; set; }
        public int? Sugar { get; set; }

        public abstract string GetInfo();
    }
    public class Tea : BaseDrink
    {
        public string? Fruits { get; set; }

        public override string GetInfo()
        {
            return $"Tea name: {Name}. Sugar: {Sugar}g. Fruits: {Fruits}";
        }
    }
    public class Coffee : BaseDrink
    {
        public string? PoopHazardLevel { get; set; }

        public override string GetInfo()
        {
            return $"Coffee name: {Name}. Sugar: {Sugar}g. Poop hazard level: {PoopHazardLevel}";
        }
    }

    public class Juice : BaseDrink
    {
        public bool? peelContents { get; set; }

        public override string GetInfo()
        {
            return $"Juice name: {Name}. Sugar: {Sugar}g. Contains peels: {peelContents}";
        }
    }


    public void OnGet()
    {
        List<BaseDrink> drinks = [
            new Tea { Name = "Ninja tea", Sugar=0, Fruits="Pamello, .45 caliber round" },
            new Coffee { Name = "Poopee coofee", Sugar=20, PoopHazardLevel="Imposible" },
            new Juice { Name = "Floor mix", Sugar=-5, peelContents=true }
        ];


        DrinksInfo = drinks.Select(b => b.GetInfo()).ToList();

        string fileData = "";
        drinks.ForEach(d => fileData += d.GetInfo() + "\n");
        System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Menu.txt"), fileData);
    }
}
