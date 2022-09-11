namespace zinoo2.Domain
{
    public abstract class UnitSub : Unit
    {
        protected UnitSub(string persianName, string englishName, string simbol, Dimension dimension) : base(persianName, englishName, simbol, dimension)
        {
        }

        public new T ConvertTo<T>() where T : Unit
        {
            var unit = ConvertToBase();
            if (unit.GetType() == typeof(T))
                return (T)unit;
            return unit.ConvertTo<T>();
        }

        protected abstract Unit ConvertToBase();
    }


}
