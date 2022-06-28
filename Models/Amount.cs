namespace Quartermaster.Models;

using System.Text.Json.Serialization;

/*

*/

public class Amount {
    [JsonConstructor]
    public Amount(int quantity, Unit unit) {
        Quantity = quantity;
        Unit = unit;
    }
    public Amount(int quantity, string unit) {
        Quantity = quantity;
        Unit = Unit.FromString(unit);
    }

    public int Quantity { get; set; }
    public Unit Unit { get; set; }

    public static Amount operator +(Amount left, Amount right) {
    return new Amount(
        left.Quantity + right.Quantity*right.Unit.ConversionFactor/left.Unit.ConversionFactor,
        left.Unit);
    }
}

public class Unit {
    public string Name { get; private set; }

    [JsonIgnore]
    public Dimension Dimension { get; private set; }

    [JsonIgnore]
    public int ConversionFactor { get; private set; }

    public Unit(string Name, Dimension Dimension, int ConversionFactor) {
        this.Name = Name;
        this.Dimension = Dimension;
        this.ConversionFactor = ConversionFactor;
    }

    [JsonConstructor]
    public Unit(string name) {
        Unit parsed = Unit.FromString(name);
        this.Name = parsed.Name;
        this.Dimension = parsed.Dimension;
        this.ConversionFactor = parsed.ConversionFactor;
    }
    public static Unit FromString(string unit) {
        switch (unit) {
            case "g":
                return Unit.Gram;
            case "kg": 
                return Unit.Kilogram;
            case "lbs":
                return Unit.Pound;
            case "oz":
                return Unit.Ounce;
            case "ml":
                return Unit.Milliliter;
            case "l":
                return Unit.Liter;
            case "gal":
                return Unit.Gallon;
            case "qt":
                return Unit.Quart;
            case "pt":
                return Unit.Pint;
            case "c":
                return Unit.Cup;
            case "pcs":
                return Unit.Pieces;
            default:
                throw new Exception("Unknown unit");
        }
    }

    public override string ToString() { return Name; }

    public static Unit Gram = new Unit("g", Dimension.Mass, 1);
    public static Unit Kilogram = new Unit("kg", Dimension.Mass, 1000);
    public static Unit Pound = new Unit("lbs", Dimension.Mass, 454);
    public static Unit Ounce = new Unit("oz", Dimension.Mass, 28);

    public static Unit Milliliter = new Unit("ml", Dimension.Volume, 1);
    public static Unit Liter = new Unit("l", Dimension.Volume, 1000);
    public static Unit FluidOunce = new Unit("fl oz", Dimension.Volume, 30);
    public static Unit Cup = new Unit("c", Dimension.Volume, 237);
    public static Unit Pint = new Unit("pt", Dimension.Volume, 473);
    public static Unit Quart = new Unit("qt", Dimension.Volume, 946);
    public static Unit Gallon = new Unit("gal", Dimension.Volume, 3785);

    public static Unit Pieces = new Unit("pcs", Dimension.Count, 1);
}

public enum Dimension {
    Volume, Mass, Count
}
