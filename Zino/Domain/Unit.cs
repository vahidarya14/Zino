
namespace Zino_v2.Domain
{
    public class Unit
    {
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
        }


        public override string ToString()
        {
            return $"{Simbol}";
        }

        public decimal ConvertTo(Unit newUnit, decimal valu)
        {
            if (newUnit == null)
                throw new ArgumentException("چنین واحدی یافت نشد");
            if (newUnit.Dimension != Dimension)
                throw new ArgumentException("تبدیل نامعتبر");


            decimal val = newUnit switch
            {
                UnitCoefficient coefficientUnitTo => BaseToCofficient(coefficientUnitTo, valu),
                UnitFormula unitFormulaTo => BaseToFormula(unitFormulaTo, valu),
                _ => valu
            };

            return val;
        }
     
        protected decimal BaseToCofficient(UnitCoefficient coefficientUnit, decimal val) => val / coefficientUnit.Coefficient;
        protected decimal BaseToFormula(UnitFormula unitFormulaTo, decimal val) => unitFormulaTo.ParseFormula(unitFormulaTo.FormulaFromBase, val);

    }
}