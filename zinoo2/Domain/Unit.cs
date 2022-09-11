namespace zinoo2.Domain
{
    public class Unit
    {
        public  decimal Val { get; set; }
        public string PersianName { get; private set; }
        public string EnglishName { get; private set; }
        public string Simbol { get; private set; }
        public Dimension Dimension { get; private set; }

        public Unit(string persianName, string englishName, string simbol, Dimension dimension)
        {
            if (string.IsNullOrEmpty(simbol))
                throw new Exception("سمبل باید مقدار داشته باشد");

            PersianName = persianName;
            EnglishName = englishName;
            Simbol = simbol;
            Dimension = dimension;
            Val = 1;
        }

        public T ConvertTo<T>() where T : Unit
        {
            //todo : if must be found in database and must move to domin service
            //var first = DB.GetAll.FirstOrDefault(x => x.Dimension == Dimension && x.GetType() == typeof(T));
            //if (first == null)
            //    throw new ArgumentException("چنین واحدی یافت نشد");


            var unit = (T)Activator.CreateInstance(typeof(T));

            if (unit.Dimension != Dimension)
                throw new ArgumentException("تبدیل نامعتبر");

            if (unit is UnitCoefficient coefficientUnit)
            {
                unit.Val = Val / coefficientUnit.Coefficient;
            }
            else if (unit is UnitFormula unitFormula)
            {
                unit.Val = unitFormula.ParseFormula(unitFormula.FormulaFromBase,Val);
            }
            else
            {
                unit.Val=Val;
            }
            return unit;

        }


        public override string ToString()
        {
            return $"{Val}{Simbol}";
        }
    }


    public class Meter : Unit { public Meter() : base("متر", "Meter", "m", Dimension.Meter) { } }
    public class Gram : Unit { public Gram() : base("گرم", "Gram", "g", Dimension.Gram) { } }
    public class Ampere : Unit { public Ampere() : base("امپر", "Ampere", "A", Dimension.Ampere) { } }
    public class Second : Unit { public Second() : base("ثانیه", "Second", "S", Dimension.Second) { } }
    public class Each : Unit { public Each() : base("عدد", "Each", "E", Dimension.Each) { } }
    public class Celsius:Unit { public Celsius() : base("دما", "Celsius", "C", Dimension.Temp) { }
}
}
