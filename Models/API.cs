namespace Quartermaster;
using Quartermaster.Models;

class QuartermasterAPI
{
    public bool IsInitialized
    {
        get => BaseURL != null;
    }

    public string? BaseURL { get; set; }
    public HttpClient? Http { get; set; }

    public List<Category>? Categories { get; set; }
    public List<Thing>? Things { get; set; }
    public Int64? LastUpdated { get; private set; }

    public void Update()
    {
        // Get categories & things from the server
    }

    public void AddCategory(Category category)
    {

    }

    public void AddThing(Thing thing) {

    }

    public void IncreaseThing(Thing thing) {
        thing.Multiplier += 1;
        Console.WriteLine(thing.Make);
    }

    public void DecreaseThing(Thing thing) {
        thing.Multiplier -= 1;
        Console.WriteLine(thing.Make);
    }

    public void DeleteThing(Thing thing) {

    }
}
