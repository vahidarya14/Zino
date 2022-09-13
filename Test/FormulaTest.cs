namespace Test;

public class FormulaTest
{
    [Test]
    public void F1() => Assert.That(Execute("4*(3^2)^2", 1), Is.EqualTo(324));

    [Test]
    public void F2() => Assert.That(Execute("(4*(3^2))^2", 1), Is.EqualTo(1296));

    [Test]
    public void F3() => Assert.That(Execute("(a*3)^2^2", 4), Is.EqualTo(20736));



    decimal Execute(string formula, decimal val) => new FormulaSpecification().Execute(formula, val);
}

