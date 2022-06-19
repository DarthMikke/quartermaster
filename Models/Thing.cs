namespace Quartermaster.Models;

public class Thing
{
    public int Id { get; set; }
    public string Make { get; set; }
    public Amount Amount { get; set; }
    public int CategoryId { get; set; }
    public int Multiplier { get; set; }
}
