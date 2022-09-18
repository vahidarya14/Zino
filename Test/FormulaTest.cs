namespace Test;

public class FormulaTest
{
    [Test]
    public void F01() => Assert.That(Execute("4*(3^2)^2", 1), Is.EqualTo(324));

    [Test]
    public void F02() => Assert.That(Execute("(4*(3^2))^2", 1), Is.EqualTo(1296));

    [Test]
    public void F03() => Assert.That(Execute("(x*3)^2^2", 4), Is.EqualTo(20736));

    [Test]
    public void F04() => Assert.That(Execute("(x * 9/5) + 32", 4), Is.EqualTo(39.2));

    [Test]
    public void F05() => Assert.That(Execute("(x * 9.5) + 32", 4), Is.EqualTo(70));

    [Test]
    public void F06() => Assert.That(Execute("((x * 9/5) + 32)^3", 4), Is.EqualTo(60_236.288));

    [Test]
    public void F07() => Assert.That(Execute("((x * 9/(3^2)) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F08() => Assert.That(Execute("((x * (3^2)/(3^2)) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F09() => Assert.That(Execute("((x * 3^2/(3^2)) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F10() => Assert.That(Execute("((x * 3^2/3^2) + 10)^2", 4), Is.EqualTo(196));

    [Test]
    public void F11()
    {
        var res1 = Execute("((x * 4^2/(3^2)) + 10)^2", 4);
        var res2 = Execute("((x * (4^2)/(3^2)) + 10)^2", 4);
        Assert.That(res1, Is.EqualTo(res2));
    }

    [Test]
    public void F12() => Assert.That(Execute("radical(8*2,2^0)"), Is.EqualTo(16));

    [Test]
    public void F13() => 
        Assert.That(Execute("radical(8*2+(5+1),2^2-(2^0))" ), Is.EqualTo(2.80203933065539M));

    [Test]
    public void F14() => 
        Assert.That(Execute("5+|4+|radical(radical(8*2+(5+1),2^2-(2^0)),3)*8/3|-2|-3"), Is.EqualTo(7.75947159580672M));

    [Test]
    public void F15() => 
        Assert.That(Execute("5+|4+|[radical(radical(8*2+(5+1),2^2-(2^0)),3)*8/3]|-2|-3"), Is.EqualTo(8));


    //----------------------------------------------------
    decimal Execute(string formula, decimal val) => new FormulaSpecification().Execute(formula, val);
    decimal Execute(string formula) => new FormulaSpecification().Execute(formula);
}

