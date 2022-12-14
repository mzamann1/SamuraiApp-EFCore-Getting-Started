using SamuraiApp.Domain;
using SamuraiApp.Infrastructure;

namespace SamuraiApp.UI;
public class Program
{
    private static SamuraiContext _context = new SamuraiContext();

    private static void Main(string[] args)
    {
        _context.Database.EnsureCreated();
        GetSamurais("Before Add:");
        AddSamurai();
        GetSamurais("After Add:");
        Console.WriteLine("Press any key...");
        Console.ReadLine();
    }

    private static void AddSamurai()
    {
        var samurai = new Samurai { Name = "Julie" };
        _context.Samurais.Add(samurai);
        _context.SaveChanges();
    }
    private static void GetSamurais(string text)
    {
        var samurais = _context.Samurais.ToList();
        Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
        Console.WriteLine(string.Join(" , ", samurais.Select(x => x.Name)));

    }
}
