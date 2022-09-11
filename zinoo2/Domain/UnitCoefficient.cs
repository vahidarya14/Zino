namespace zinoo2.Domain
{
    /// <summary>واحد ضریب دار </summary>
    public class UnitCoefficient : UnitSub
    {
        public decimal Coefficient { get; protected set; }

        public UnitCoefficient(string perName, string engName, string simbol, Dimension dimension, decimal coefficient) : base(perName, engName, simbol, dimension)
        {
            Coefficient = coefficient;
        }

        protected override Unit ConvertToBase()
        {
            var baseUnit = DB.GetAll.FirstOrDefault(x => x.Dimension == Dimension && x is Unit);
            if (baseUnit == null)
                throw new ArgumentException("چنین واحدی یافت نشد");


            baseUnit.Val = Val * Coefficient;

            return baseUnit;
        }



        public static UnitCoefficient Millimeter() => new("میلی متر", "Millimeter", "mm", Dimension.Meter, 0.001M);
        public static UnitCoefficient Centimeter() => new("سانتی متر", "Centimeter", "cm", Dimension.Meter, 0.01M);
        public static UnitCoefficient Kilometer() => new("کیلومتر", "Kilometer", "km", Dimension.Meter, 1000M);
    }


    public class Millimeter : UnitCoefficient { public Millimeter() : base("میلی متر", "Millimeter", "mm", Dimension.Meter, 0.001M) { } }
    public class Centimeter : UnitCoefficient { public Centimeter() : base("سانتی متر", "Centimeter", "cm", Dimension.Meter, 0.01M) { } }
    public class Kilometer : UnitCoefficient { public Kilometer() : base("کیلومتر", "Kilometer", "km", Dimension.Meter, 1000M) { } }
    //---------
    public class Milligram : UnitCoefficient { public Milligram() : base("میلی گرم", "Milligram", "mg", Dimension.Gram, 0.001M) { } }
    public class Kilogram : UnitCoefficient { public Kilogram() : base("کیلو گرم", "Kilogram", "kg", Dimension.Gram, 1000M) { } }
    public class Tonne : UnitCoefficient { public Tonne() : base("تن", "Tonne", "ton", Dimension.Gram, 1000000M) { } }

}
