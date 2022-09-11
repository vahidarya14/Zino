using zinoo2.Domain;




var m = new Meter() { Val = 10 };
var mm = m.ConvertTo<Millimeter>();
Console.WriteLine($"{m} = {mm}");

var km = mm.ConvertTo<Kilometer>();
Console.WriteLine($"{mm} = {km}");

var km2 = km.ConvertTo<Kilometer>();
Console.WriteLine($"{km} = {km2}");

var m3 = m.ConvertTo<Meter>();
Console.WriteLine($"{m} = {m3}");

var cm = km.ConvertTo<Centimeter>();
Console.WriteLine($"{km} = {cm}");

var m4 = km.ConvertTo<Meter>();
Console.WriteLine($"{km} = {m4}");



var g = new Gram() { Val = 10 };
var mg = g.ConvertTo<Milligram>();
Console.WriteLine($"{g} = {mg}");

var kg = mg.ConvertTo<Kilogram>();
Console.WriteLine($"{mg} = {kg}");



var c = new Celsius() { Val = 4 };
var k = c.ConvertTo<Kelvin>();
var f = k.ConvertTo<Fahrenheit>();
Console.WriteLine($"{c} = {k} = {f}");

var c2=f.ConvertTo<Celsius>();
Console.WriteLine($"{f} = {c2} =");

