// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WhenLinqIsNotLinq;

class Program
{
    public static void Main(string[] args)
    {
        var appDbContext = new AppDbContext();

        var animalsFromDb = appDbContext.Animals;
        var animalsInList = new List<Animal>();

        var sql = animalsFromDb.Where(x => x.Name == "Dog").ToQueryString();
        var filteredDbAnimals = animalsFromDb.Where(x => x.Name == "Dog").ToList();
        var filteredListAnimals = animalsInList.Where(x => x.Name == "Dog").ToList();
        
        Console.WriteLine($"{filteredDbAnimals.Count} animals in the Database.");
        Console.WriteLine($"{filteredListAnimals.Count} animals in the List.");
    }

    private static AppDbContext InitialiseDatabase()
    {
        var services = new ServiceCollection()
            .AddDbContext<AppDbContext>()
            .BuildServiceProvider();

        var appDbContext = services.GetRequiredService<AppDbContext>();
        appDbContext.Database.Migrate();
        return appDbContext;

    }
}
