namespace Zino_v2.Domain
{
    /// <summary>واحد ضریب دار </summary>
    public class UnitCoefficient : Unit
    {
        public decimal Coefficient { get; protected set; }

        public UnitCoefficient(string perName, string engName, string simbol, Dimension dimension, decimal coefficient) : base(perName, engName, simbol, dimension)
        {
            Coefficient = coefficient;
        }

        public new decimal ConvertTo(Unit newUnit, decimal valu)
        {
            if (newUnit == null)
                throw new ArgumentException("چنین واحدی یافت نشد");


            if (newUnit.Dimension != Dimension)
                throw new ArgumentException("تبدیل نامعتبر");

            decimal val;
            if (newUnit is UnitCoefficient coefficientUnitTo)
                val = CofficientToCofficient(coefficientUnitTo, valu);
            else if (newUnit is UnitFormula unitFormulaTo)
                val = CofficientToFormula(unitFormulaTo, valu);
            else
                val = CofficienToBase(valu);


            return val;


            decimal CofficienToBase(decimal valu) => valu * Coefficient;
            decimal CofficientToCofficient(UnitCoefficient coefficientUnitTo, decimal valu)
            {
                var val = CofficienToBase(valu);
                return BaseToCofficient(coefficientUnitTo, val);
            }
            decimal CofficientToFormula(UnitFormula unitFormulaTo, decimal valu)
            {
                var val = CofficienToBase(valu);
                val = BaseToFormula(unitFormulaTo, val);
                return val;
            }
        }


    }




}
