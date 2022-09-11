using zinoo2.Domain;

namespace zinoo2
{
    public static class DB
    {
        static DB()
        {
            Meter base1 = new();
            Gram base2 = new();
            Ampere base3 = new();
            Second base4 = new();
            Each base5 = new();
            Celsius base6 = new();

            Millimeter multiplicative1 = new();
            Centimeter multiplicative2 = new();
            Kilometer multiplicative3 = new();
            Milligram multiplicative4 = new();
            Kilogram multiplicative5 = new();
            Tonne multiplicative6 = new();

            GetAll = new List<Unit>
            {
                base1,
                base2,
                base3,
                base4,
                base5,
                base6,
                //multiplicative1,
                //multiplicative2,
                //multiplicative3,
                //multiplicative4,
                //multiplicative5,
                //multiplicative6
            };

        }

        public static List<Unit> GetAll{get; } 
    }
}
