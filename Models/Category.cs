namespace Quartermaster.Models;

public class Category {
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Thing>? Things { get; set; }

    public void AddThing(Thing thing) {
        if (Things == null) { Things = new List<Thing>(); }
        Things.Add(thing);
    }
}
