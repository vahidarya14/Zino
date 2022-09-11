namespace zinoo2.Domain
{
    /// <summary>واحد فرمول دار</summary>
    public class UnitFormula : UnitSub
    {
        public string FormulaFromBase { get; set; }
        public string FormulaToBase { get; set; }

        public UnitFormula(string perName, string engName, string simbol, Dimension dimension, string formulaFromBase, string formulaToBase) : base(perName, engName, simbol, dimension)
        {
            FormulaFromBase = formulaFromBase;
            FormulaToBase = formulaToBase;

            var isOK = ValidateFormula(FormulaFromBase);
            var isOK2 = ValidateFormula(FormulaToBase);

            if (!isOK)
                throw new Exception("invalid FormulaFromBase");

            if (!isOK2)
                throw new Exception("invalid FormulaToBase");

            Val = 1;
        }



        protected override Unit ConvertToBase()
        {
            var baseUnit = DB.GetAll.FirstOrDefault(x => x.Dimension == Dimension && x is Unit);
            if (baseUnit == null)
                throw new ArgumentException("چنین واحدی یافت نشد");


            baseUnit.Val = ParseFormula(FormulaToBase,Val);

            return baseUnit;
        }


        public bool ValidateFormula(string formula)
        {
            //todo : use Regex to validate
            //return new Regex(@"^[0-9().+-/*a]$").IsMatch(formula);

            var validCharacters = new[] { 'a', '(', ')', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', ' ' };
            if (formula.Count(x => x == '(') != formula.Count(x => x == ')'))
                return false;
            return formula.All(item => validCharacters.Contains(item));
        }

        public decimal ParseFormula(string formula,decimal valueOfA)
        {
            var mainOprations = new[] { '*', '/', '+', '-', };
            if (string.IsNullOrWhiteSpace(formula))
                return 0;

            formula = formula.Replace(" ", "");
            formula = formula.Replace("a", valueOfA.ToString());

            while (formula.Contains('('))
            {
                var start = formula.LastIndexOf('(');
                var end = formula.IndexOf(')', start + 1);
                var subStr = formula.Substring(start + 1, end - start - 1);
                var subStr2=DoTheBlock( subStr);
                formula = formula.Replace($"{subStr}", "");
                formula=formula.Replace("()", subStr2);
            }
            //formula = formula.Replace("-", "+-");
            //if(formula.StartsWith("+-"))
            //    formula=formula.Substring(1);
            //var opts = GetOperations(formula);
            //foreach (var op in new[] { '*', '/', '+' })
            //{
            //    while (opts.Contains(op))
            //    {
            //        var digits = formula.Split(new[] { '*', '/', '+' }, StringSplitOptions.RemoveEmptyEntries).Select(x => decimal.Parse(x)).ToList();

            //        var index = opts.FindIndex(0, x => x == op);
            //        var resultInPrenteze = DoOperation(digits[index], digits[index + 1], op.ToString());
            //        opts.Remove(opts[index]);
            //        formula = formula.Replace($"{digits[index]}{op}{digits[index + 1]}", resultInPrenteze.ToString());
            //    }
            //}
            formula = DoTheBlock(formula);


            return decimal.Parse(formula);


            string  DoTheBlock(string subStr)
            {
                var subStr2 = subStr.Replace("-", "+-");
                if (subStr2.StartsWith("+-"))
                    subStr2 = subStr2.Substring(1);
                var opts1 = GetOperations(subStr2);
                foreach (var op in new[] { '*', '/', '+' })
                {
                    while (opts1.Contains(op))
                    {
                        var digits = subStr2.Split(new[] { '*', '/', '+' }, StringSplitOptions.RemoveEmptyEntries).Select(x => decimal.Parse(x)).ToList();

                        var index = opts1.FindIndex(0, x => x == op);
                        var resultInPrenteze = DoOperation(digits[index], digits[index + 1], op.ToString());
                        opts1.Remove(opts1[index]);

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
                    if (new[] { '*', '/', '+' }.Contains(item))
                    {
                        //if (item == '-')
                        //{
                        //    if (i>0 && formula[i - 1] != '[')
                        //        opts.Add(item);
                        //}
                        //else
                            opts.Add(item);
                    }
                }
                return opts;
            }
        }

    }

    public class Kelvin : UnitFormula { public Kelvin() : base("کلوین", "Kelvin", "K", Dimension.Temp, "a + 273.15", "a - 273.15") { } }
    public class Fahrenheit : UnitFormula { public Fahrenheit() : base("فارنهایت", "Fahrenheit", "F", Dimension.Temp,"(a * 9/5) + 32", "(a - 32) * 5/9") { } }
}
