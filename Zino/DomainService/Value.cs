using Zino_v2.Domain;
using Zino_v2.Persistance;

namespace Zino_v2.DomainService
{
    public class Value
    {
        public decimal Valu { get; set; }
        public Unit Unit { get; set; }
        public Value(decimal val, Unit unit)
        {
            Unit = unit;
            Valu = val;
        }

        public override string ToString()
        {
            return $"{Valu}{Unit.Simbol}";
        }

        public Value ConvertTo(string simbolOfEnglishNameOrPersianname)
        {
            var newUnit = DB.GetAll.FirstOrDefault(x => x.Simbol == simbolOfEnglishNameOrPersianname ||
                                                        x.PersianName == simbolOfEnglishNameOrPersianname ||
                                                        x.EnglishName == simbolOfEnglishNameOrPersianname);
            if (newUnit == null)
                throw new ArgumentException("چنین واحدی یافت نشد");


            if (newUnit.Dimension != Unit.Dimension)
                throw new ArgumentException("تبدیل نامعتبر");

            var val = 0m;
            val = Unit switch
            {
                UnitCoefficient coefficientUnitFrom => coefficientUnitFrom.ConvertTo(newUnit, Valu),
                UnitFormula unitFormulaFrom => unitFormulaFrom.ConvertTo(newUnit, Valu),
                //Unit is base unit
                _ => Unit.ConvertTo(newUnit, Valu),
            };
            return new Value(val, newUnit);
        }

        //decimal CofficienToBase(UnitCoefficient coefficientUnit) => Valu * coefficientUnit.Coefficient;
        //decimal CofficientToCofficient(UnitCoefficient coefficientUnitFrom, UnitCoefficient coefficientUnitTo)
        //{
        //    var val = CofficienToBase(coefficientUnitFrom);
        //    return BaseToCofficient(coefficientUnitTo, val);
        //}
        //decimal CofficientToFormula(UnitCoefficient unitCoefficientFrom, UnitFormula unitFormulaTo)
        //{
        //    var val = CofficienToBase(unitCoefficientFrom);
        //    val = BaseToFormula(unitFormulaTo, val);
        //    return val;
        //}

        //decimal FormulaToCofficient(UnitFormula unitFormula, UnitCoefficient coefficientUnitTo)
        //{
        //    var val = FormulaToBase(unitFormula);
        //    val = BaseToCofficient(coefficientUnitTo, val);
        //    return val;
        //}
        //decimal FormulaToBase(UnitFormula unitFormula) => unitFormula.ParseFormula(unitFormula.FormulaToBase, Valu);
        //decimal FormulaToFormula(UnitFormula unitFormulaFrom, UnitFormula unitFormulaTo)
        //{
        //    var val = FormulaToBase(unitFormulaFrom);
        //    val = BaseToFormula(unitFormulaTo, val);
        //    return val;
        //}

        //decimal BaseToBase() => Valu;
        //decimal BaseToCofficient(UnitCoefficient coefficientUnit, decimal val) => val / coefficientUnit.Coefficient;
        //decimal BaseToFormula(UnitFormula unitFormulaTo, decimal val) => unitFormulaTo.ParseFormula(unitFormulaTo.FormulaFromBase, val);

    }
}
