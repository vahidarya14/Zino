using System.Security.Cryptography;
using zinoo2;
using zinoo2.Domain;


var unitFormula = new UnitFormula("", "", "x", Dimension.Gram, "a+(1-3*4)", "((2-5)/(a-1)-9)+4");
var result = unitFormula.ParseFormula(unitFormula.FormulaToBase, 10);

//var v1=new Value(10,new Kilometer());
//var v2=v1.ConvertTo<Meter>();
//Console.WriteLine($"v1={v1}   => v2={v2}");

//var v3 = v1.ConvertTo<Millimeter>();
//Console.WriteLine($"v1={v1}   => v3={v3}");


//var v4 = v2.ConvertTo<Millimeter>();
//Console.WriteLine($"v2={v2}   => v4={v4}");


//var v5 = v2.ConvertTo<Meter>();
//Console.WriteLine($"v2={v2}   => v5={v5}");

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

//try
//{
//    var g1 = km.ConvertTo<Gram>();
//    Console.WriteLine($"{km} = {g1}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"{ex.Message}");
//}


var g = new Gram() { Val = 10 };
var mg = g.ConvertTo<Milligram>();
Console.WriteLine($"{g} = {mg}");

var kg = mg.ConvertTo<Kilogram>();
Console.WriteLine($"{mg} = {kg}");



var c = new Celsius() { Val = 3 };
var k = c.ConvertTo<Kelvin>();
var f = k.ConvertTo<Fahrenheit>();
Console.WriteLine($"{c} = {k} = {f}");

var c2=f.ConvertTo<Celsius>();
Console.WriteLine($"{f} = {c2} =");

//var a = new Kilometer() { Val = 10 };
////var m = a.ConvertTo<Meter>();
//var mm = a.ConvertTo<Centimeter>();

//var kg2 = mm.ConvertTo<Kilometer>();

//var a2 = new UnitFormula("کلوین", "Kelvin", "k", Dimension.Meter, "a", "a - 273.15"){ Val = 10 };

//var m=a2.ConvertToBase();

//Console.WriteLine($"Kelvin={a2.Val}   => meter={m.Val}");

//var k2 = m.ConvertTo1<Kilometer>();
//Console.WriteLine($"meter={m.Val}   => Kilometer={k2.Val}");

