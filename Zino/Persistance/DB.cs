using Zino_v2.Domain;

namespace Zino_v2.Persistance
{
    public static class DB
    {
        public static List<Unit> GetAll => new ()
        {
            new("متر", "Meter", "m", Dimension.Meter),
            new("گرم", "Gram", "g", Dimension.Gram),
            new("امپر", "Ampere", "A", Dimension.Ampere),
            new("ثانیه", "Second", "S", Dimension.Second),
            new("عدد", "Each", "E", Dimension.Each),
            new("دما", "Celsius", "C", Dimension.Temp),
        //-----
            new UnitCoefficient("میلی متر", "Millimeter", "mm", Dimension.Meter, 0.001M) ,
            new UnitCoefficient ("سانتی متر", "Centimeter", "cm", Dimension.Meter, 0.01M) ,
            new UnitCoefficient("کیلومتر", "Kilometer", "km", Dimension.Meter, 1000M) ,
            //--
            new UnitCoefficient ("میلی گرم", "Milligram", "mg", Dimension.Gram, 0.001M) ,
            new UnitCoefficient ("کیلو گرم", "Kilogram", "kg", Dimension.Gram, 1000M),
            new UnitCoefficient ("تن", "Tonne", "ton", Dimension.Gram, 1000000M) ,
        //-----
            new UnitFormula("کلوین", "Kelvin", "K", Dimension.Temp, "x + 273.15", "x - 273.15") ,
            new UnitFormula("فارنهایت", "Fahrenheit", "F", Dimension.Temp, "(x * 9/5) + 32", "(x - 32) * 5/9")
        };
    }
}
