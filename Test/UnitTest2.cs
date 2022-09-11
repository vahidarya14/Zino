namespace Test
{
    public class Tests2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Celsius_to_Fahrenheit()
        {
            var c = new Celsius() { Val = 3 };
            var f = c.ConvertTo<Fahrenheit>();

            Assert.That(f.Val,Is.EqualTo( 37.4));
        }

        [Test]
        public void Fahrenheit_to_Celsius()
        {
            var c = new Fahrenheit() { Val = 37.4m };
            var f = c.ConvertTo<Celsius>();

            Assert.That(f.Val, Is.EqualTo(3));
        }

        [Test]
        public void Celsius_to_Kelvin()
        {
            var c = new Celsius() { Val = 3 };
            var k = c.ConvertTo<Kelvin>();

            Assert.That(k.Val, Is.EqualTo(276.15));
        }

        [Test]
        public void Kelvin_to_Fahrenheit()
        {
            var k = new Kelvin() { Val= 276.15m };
            var f = k.ConvertTo<Fahrenheit>();

            Assert.That(f.Val, Is.EqualTo(37.4m));
        }

    }
}
