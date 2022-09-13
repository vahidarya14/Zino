namespace Zino_v2.Domain
{
    /// <summary>واحد فرمول دار</summary>
    public class UnitFormula : Unit
    {
        private readonly FormulaSpecification formulaSpecification=new FormulaSpecification();
        public string FormulaFromBase { get; private set; }
        public string FormulaToBase { get; private set; }

        public UnitFormula(string perName, string engName, string simbol, Dimension dimension, string formulaFromBase, string formulaToBase) : base(perName, engName, simbol, dimension)
        {
            if (!ValidateFormula(formulaFromBase))
                throw new Exception("invalid FormulaFromBase");
            if (!ValidateFormula(formulaToBase))
                throw new Exception("invalid FormulaToBase");

            FormulaFromBase = formulaFromBase;
            FormulaToBase = formulaToBase;
        }

        public new decimal ConvertTo(Unit newUnit, decimal valu)
        {
            if (newUnit == null)
                throw new ArgumentException("چنین واحدی یافت نشد");
            if (newUnit.Dimension != Dimension)
                throw new ArgumentException("تبدیل نامعتبر");

            decimal val = newUnit switch
            {
                UnitCoefficient coefficientUnitTo => FormulaToCofficient(coefficientUnitTo, valu),
                UnitFormula unitFormulaTo => FormulaToFormula(unitFormulaTo, valu),
                _ => FormulaToBaseUnit(valu)
            };

            return val;


            decimal FormulaToCofficient(UnitCoefficient coefficientUnitTo, decimal valu)
            {
                var val = FormulaToBaseUnit(valu);
                val = BaseToCofficient(coefficientUnitTo, val);
                return val;
            }
            decimal FormulaToBaseUnit(decimal valu) => ParseFormula(FormulaToBase, valu);
            decimal FormulaToFormula(UnitFormula unitFormulaTo, decimal valu)
            {
                var val = FormulaToBaseUnit(valu);
                val = BaseToFormula(unitFormulaTo, val);
                return val;
            }
        }


        public bool ValidateFormula(string formula) => formulaSpecification.CanExecure(formula);

        public decimal ParseFormula(string formula, decimal valueOfA) => formulaSpecification.Execute(formula, valueOfA);

    }


    public interface ISpecification<T>
    {
        bool CanExecure(string formula);
        decimal Execute(string formula, decimal valueOfA);
    }

    public class FormulaSpecification : ISpecification<UnitFormula>
    {
        public bool CanExecure(string formula)
        {
            //todo : use Regex to validate
            //return new Regex(@"^[0-9().+-/*a]$").IsMatch(formula);

            var validCharacters = new[] { '^', 'a', '(', ')', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', ' ' };
            if (formula.Count(x => x == '(') != formula.Count(x => x == ')'))
                return false;
            return formula.All(item => validCharacters.Contains(item));
        }

        public decimal Execute(string formula, decimal valueOfA)
        {
            var mainOprations = new[] {'^', '*', '/', '+', /*'-',*/ };
            if (string.IsNullOrWhiteSpace(formula))
                return 0;

            formula = formula.Replace(" ", "");
            formula = formula.Replace("a", valueOfA.ToString());

            while (formula.Contains('('))
            {
                var start = formula.LastIndexOf('(');
                var end = formula.IndexOf(')', start + 1);
                var subStr = formula.Substring(start + 1, end - start - 1);
                var subStr2 = ParseAndCalcTheBlock(subStr);
                formula = formula.Replace($"{subStr}", "");
                formula = formula.Replace("()", subStr2);
            }

            formula = ParseAndCalcTheBlock(formula);


            return decimal.Parse(formula);


            string ParseAndCalcTheBlock(string subStr)
            {
                var subStr2 = subStr.Replace("-", "+-");
                if (subStr2.StartsWith("+-"))
                    subStr2 = subStr2.Substring(1);
                var oprands = GetOperations(subStr2);
                foreach (var op in mainOprations)
                {
                    while (oprands.Contains(op))
                    {
                        var digits = subStr2.Split(mainOprations, StringSplitOptions.RemoveEmptyEntries).Select(x => decimal.Parse(x)).ToList();

                        var index = oprands.FindIndex(0, x => x == op);
                        var resultInPrenteze = DoOperation(digits[index], digits[index + 1], op.ToString());
                        oprands.Remove(oprands[index]);

                        subStr2 = subStr2.Replace($"{digits[index]}{op}{digits[index + 1]}", resultInPrenteze.ToString());
                    }
                }

                return subStr2;
            }

            decimal DoOperation(decimal digit1, decimal digit2, string op)
            {
                decimal resultInPrenteze = 0M;
                switch (op)
                {
                    case "+":
                        resultInPrenteze = digit1 + digit2;
                        break;
                    case "-":
                        resultInPrenteze = digit1 - digit2;
                        break;
                    case "*":
                        resultInPrenteze = digit1 * digit2;
                        break;
                    case "/":
                        resultInPrenteze = digit1 / digit2;
                        break;
                    case "^":
                        resultInPrenteze =(decimal)Math.Pow((double)digit1 , (double)digit2);
                        break;
                    default:
                        break;
                }
                return resultInPrenteze;
            }

            List<char> GetOperations(string formula)
            {
                var opts = new List<char>();
                for (var i = 0; i < formula.Length; i++)
                {
                    var item = formula[i];
                    if (mainOprations.Contains(item))
                    {
                        opts.Add(item);
                    }
                }
                return opts;
            }
        }

    }

}
