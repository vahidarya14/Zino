namespace Test;

public class FormulaTest
{
    [Test]
    public void F1() => Assert.That(Execute("4*(3^2)^2", 1), Is.EqualTo(324));

    [Test]
    public void F2() => Assert.That(Execute("(4*(3^2))^2", 1), Is.EqualTo(1296));

    [Test]
    public void F3() => Assert.That(Execute("(x*3)^2^2", 4), Is.EqualTo(20736));

    [Test]
    public void F4() => Assert.That(Execute("(x * 9/5) + 32", 4), Is.EqualTo(39.2));

    [Test]
    public void F5() => Assert.That(Execute("(x * 9.5) + 32", 4), Is.EqualTo(70));

    [Test]
    public void F6() => Assert.That(Execute("((x * 9/5) + 32)^3", 4), Is.EqualTo(60_236.288));

    [Test]
    public void F7() => Assert.That(Execute("((x * 9/(3^2)) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F8() => Assert.That(Execute("((x * (3^2)/(3^2)) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F9() => Assert.That(Execute("((x * 3^2/(3^2)) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F10() => Assert.That(Execute("((x * 3^2/3^2) + 10)^2", 4), Is.EqualTo(196));


    [Test]
    public void F11()
    {
        var res1 = Execute("((x * 4^2/(3^2)) + 10)^2", 4);
        var res2 = Execute("((x * (4^2)/(3^2)) + 10)^2", 4);
        Assert.That(res1, Is.EqualTo(res2));
    }



    decimal Execute(string formula, decimal val) => new FormulaSpecification().Execute(formula, val);
}

