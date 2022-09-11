//using zinoo2.Domain;

//namespace zinoo2
//{
//    public class Value
//    {
//        public decimal Val { get; set; }
//        public Unit Unit { get; set; }
//        public Value(decimal val, Unit unit)
//        {
//            unit.Val = val;
//            Unit = unit;
//            Val = val;
//        }

//        public override string ToString()
//        {
//            return $"{Val}{Unit.Simbol}";
//        }

//        public Value ConvertTo<T>() where T : Unit
//        {
//            //todo : if must be found in database and must move to domin service

//            //var first = DB.GetAll().FirstOrDefault(x => x.Dimension == Dimension && x.GetType() == typeof(T));
//            //if (first == null)
//            //    throw new ArgumentException("چنین واحدی یافت نشد");


//            var unit = (T)Activator.CreateInstance(typeof(T));

//            if (unit.Dimension != Unit. Dimension)
//                throw new ArgumentException("تبدیل نامعتبر");

//            //if (unit is CoefficientUnit coefficientUnit)
//            //{
//            //    unit = (T)coefficientUnit.ConvertTo<T>();
//            //}
//            //else if (unit is UnitFormula unitFormula)
//            //{
//            //    unit = (T)unitFormula.ConvertTo<T>();
//            //}
//            //else 
//            //{
//                if (Unit is UnitCoefficient coefficientUnit2)
//                {
//                    unit = (T)coefficientUnit2.ConvertTo<T>();
//                }
//                else if (Unit is UnitFormula unitFormula2)
//                {
//                    unit = (T)unitFormula2.ConvertTo<T>();
//                }
//               else
//                    unit=(T)Unit.ConvertTo<T>();
//            //}
//            return new Value(unit.Val, unit);

//        }
//    }
//}
