namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Meter_to_Millimeter()
        {
            var m = new Meter() { Val = 10 };
            var mm = m.ConvertTo<Millimeter>();

            Assert.That(mm.Val, Is.EqualTo(10_000m));
        }

        [Test]
        public void Milligram_to_Gram()
        {
            var m = new Milligram() { Val = 10 };
            var mm = m.ConvertTo<Gram>();

            Assert.AreEqual(mm.Val, 0.01);
        }

        [Test]
        public void Ampere_Gram_Exception()
        {
            var a = new Ampere() { Val = 1 };

            var ex = Assert.Throws<ArgumentException>(() => { var g = a.ConvertTo<Gram>(); });
            Assert.That(ex.Message, Is.EqualTo("تبدیل نامعتبر"));
        }


        [Test]
        public void ValidateFormula1()
        {
            var unitFormula = new UnitFormula("", "", "x", Dimension.Gram, "a+(1-3)*4", "((2-5)/(3-1)-9)+4");
            Assert.That(unitFormula.ValidateFormula(unitFormula.FormulaToBase), Is.EqualTo(true));
        }

        [Test]
        public void ValidateFormula2()
        {
            
            var ex = Assert.Throws<Exception>(() => { 
                var unitFormula = new UnitFormula("", "", "x", Dimension.Gram, "a+(1-3*4", "((2-5)/(3-1)-9)+4");
                });

            Assert.That(ex.Message, Is.EqualTo("invalid FormulaFromBase"));
        }


    }
}