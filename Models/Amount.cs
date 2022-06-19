namespace Quartermaster.Models;

/*

*/

public struct Amount {
    public Amount(int quantity, Unit unit) {
        Quantity = quantity;
        Unit = unit;
    }

    public int Quantity { get; set; }
    public Unit Unit { get; set; }

    public static Amount operator +(Amount left, Amount right) {
    return new Amount {
        Quantity = left.Quantity + right.Quantity*right.Unit.ConversionFactor/left.Unit.ConversionFactor,
        Unit = left.Unit
    };
    }
}

public class Unit {
    public Unit(string Name, Dimension Dimension, int ConversionFactor) {
        this.Name = Name;
        this.Dimension = Dimension;
        this.ConversionFactor = ConversionFactor;
    }
    public string Name { get; set; }
    public Dimension Dimension { get; set; }
    public int ConversionFactor { get; set; }
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
