namespace SharpRepository.Scrutor.ConsoleApp.Client;

using Features.Greeters.Interfaces;
using Infra.Entities;
using InMemoryRepository;
using Spectre.Console;

public class App
{
    private readonly IGreeterWelcomeService _greeterWelcomeService;

    public App(IGreeterWelcomeService greeterWelcomeService)
    {
        this._greeterWelcomeService = greeterWelcomeService;
    }

    public async Task RunAsync()
    {
        // Insert program code below...
        this._greeterWelcomeService.WelcomeMessage();
        
        
        // Declare your generic InMemory Repository.  
        // Check out HowToAbstractAwayTheGenericRepository.cs for cleaner ways to new up a repo.
        
        var repo = new InMemoryRepository<Grade, int>();
            
        // Create 
        var create = new Grade { GradeName = "A+", Section = "Passing"};
        repo.Add(create);

        const int expectedOrderId = 1;
        if (create.GradeId == expectedOrderId)
        {
            AnsiConsole.MarkupLine("[green] Passed >> Initial Grade Id[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red] Failed... Grade Id was not as expected...[/]");
        }

        // Read 
        var read = repo.Get(expectedOrderId);
        
        if (read.GradeName == "A+")
        {
            AnsiConsole.MarkupLine("[green] Passed >> Grade was A+[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red] Failed... Grade Name was not as expected...[/]");
        }
        
        if (read.Section == "Passing")
        {
            AnsiConsole.MarkupLine("[green] Passed >> We expected 'passing' and saw 'passing'[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red] Failed... Grade Section was not as expected...[/]");
        }
 
            
        // Update
        read.GradeName = "F";
        read.Section = "Failing";
        repo.Update(read);
            
        var update = repo.Get(expectedOrderId);
        
        if (update.GradeName == "F")
        {
            AnsiConsole.MarkupLine("[green] Passed >> We expected to see 'F' and we saw 'F'[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red] Failed... Grade Name was not as expected...[/]");
        }
        
        if (update.Section == "Failing")
        {
            AnsiConsole.MarkupLine("[green] Passed >> We expected 'Failing' and saw 'Failing'[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red] Failed... Grade Section was not as expected...[/]");
        }

 

        // Delete
        repo.Delete(update);
        var delete = repo.Get(expectedOrderId);
        if (delete == null)
        {
            AnsiConsole.MarkupLine("[green] Passed >> We expected to see null[/]");

        }
        else
        {
            AnsiConsole.MarkupLine("[red] Failed... we did not see null[/]");

        }



        var r =new Rule("End Demo");
        r.Border = BoxBorder.Double;
        AnsiConsole.Write(r);
        AnsiConsole.MarkupLine("[salmon1]Press any key to exit...[/]");
        Console.ReadLine();
        await Task.CompletedTask;
    }
}