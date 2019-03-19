using NUnit.Framework;

namespace Slovom.Tests.BgSpellerTests
{
    class Spell_MaleGender_Should
    {
        [TestCase(1, "един")]
        [TestCase(2, "два")]
        [TestCase(101, "сто и един")]
        [TestCase(2_001, "две хиляди и един")]
        public void Spell_Positive_Numbers_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number, Gender.Male);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(-1, "минус един")]
        [TestCase(-2, "минус два")]
        [TestCase(-2_001, "минус две хиляди и един")]
        [TestCase(99_999_991, "деветдесет и девет милиона деветстотин деветдесет и девет хиляди деветстотин деветдесет и един")]
        [TestCase(100_000_001, "сто милиона и един")]
        [TestCase(100_000_000_002, "сто милиарда и два")]
        public void Spell_Negative_Numbers_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number, Gender.Male);

            // Assert
            Assert.AreEqual(result, inWords);
        }
    }
}
