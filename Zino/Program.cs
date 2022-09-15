using Zino_v2.DomainService;
using Zino_v2.Domain;




decimal Execute(string formula, decimal val) {
    FormulaSpecification FormulaSpecification=new();
    if(!FormulaSpecification.CanExecure(formula)) 
        throw new Exception("invalid formula");
    return  FormulaSpecification.Execute(formula, val);
}

var res = Execute("radical(radical(8*2,4/2),3)*8/3", 4);
var res2 = Execute("((x * (3^2)/(3^2)) + 10)^2", 4);
var eq =  res2;


var km = new Value(10, Kilometer());
var m = km.ConvertTo("m");
Console.WriteLine($"{km}   =   {m} ");

var cm = km.ConvertTo("cm");
Console.WriteLine($"{km}   =     {cm}");

var km2 = m.ConvertTo("کیلومتر");
Console.WriteLine($"{m}   =   {km2}");

var c = new Value(3, Celsius());
var k = c.ConvertTo("Kelvin");
var f = k.ConvertTo("Fahrenheit");
Console.WriteLine($"{c} = {k} = {f}");

var c2 = f.ConvertTo("Celsius");
Console.WriteLine($"{f} = {c2} =");


////helper---------------------------------------------------------------
static Unit Meter() => new("متر", "Meter", "m", Dimension.Meter);
static Unit Gram() => new("گرم", "Gram", "g", Dimension.Gram);
static Unit Ampere() => new("امپر", "Ampere", "A", Dimension.Ampere);
static Unit Second() => new("ثانیه", "Second", "S", Dimension.Second);
static Unit Each() => new("عدد", "Each", "E", Dimension.Each);
static Unit Celsius() => new("دما", "Celsius", "C", Dimension.Temp);
static UnitCoefficient Millimeter() => new("میلی متر", "Millimeter", "mm", Dimension.Meter, 0.001M);
static UnitCoefficient Centimeter() => new("سانتی متر", "Centimeter", "cm", Dimension.Meter, 0.01M);
static UnitCoefficient Kilometer() => new("کیلومتر", "Kilometer", "km", Dimension.Meter, 1000M);
