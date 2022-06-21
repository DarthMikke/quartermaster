namespace Quartermaster.Models;

public class Thing
{
    public int Id { get; set; }
    public string Make { get; set; }
    public Amount Amount { get; set; }
    public int CategoryId { get; set; }
    public int Multiplier { get; set; }

    public Thing(int CategoryId) {
        this.Id = 0;
        this.Make = "Ny ting";
        this.Amount = new Amount(100, Unit.Gram);
        this.CategoryId = CategoryId;
        this.Multiplier = 1;
    }
}
