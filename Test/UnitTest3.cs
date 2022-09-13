using Dimension = zinoo2.Domain.Dimension;
using UnitFormula = zinoo2.Domain.UnitFormula;
namespace Test
{
    public class UnitTest3
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateFormula1()
        {
            var unitFormula = new UnitFormula("", "", "x", Dimension.Gram, "a+(1-3*4)", "((2-5)/(a-1)-9)+4");
            var result = unitFormula.ParseFormula(unitFormula.FormulaToBase, 10);

            Assert.That(result, Is.EqualTo(-5.333333333333333333333333333));
        }
    }
}
