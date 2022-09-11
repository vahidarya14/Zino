using Zino_v2.DomainService;
using Zino_v2.Domain;

var km = new Value(10, UnitCoefficient.Kilometer());
var m = km.ConvertTo("m");
Console.WriteLine($"{km}   =   {m} ");

var cm = km.ConvertTo("cm");
Console.WriteLine($"{km}   =     {cm}");

var km2 = m.ConvertTo("کیلومتر");
Console.WriteLine($"{m}   =   {km2}");

var c = new Value(3, Unit.Celsius());
var k = c.ConvertTo("Kelvin");
var f = k.ConvertTo("Fahrenheit");
Console.WriteLine($"{c} = {k} = {f}");

var c2 = f.ConvertTo("Celsius");
Console.WriteLine($"{f} = {c2} =");

