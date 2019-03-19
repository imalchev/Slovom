using NUnit.Framework;

namespace Slovom.Tests.BgSpellerTests
{
    public class Spell_FemaleGender_Should
    {
        [TestCase(1, "една")]
        [TestCase(2, "две")]
        [TestCase(101, "сто и една")]
        [TestCase(2_001, "две хиляди и една")]
        public void Spell_Positive_Numbers_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number, Gender.Female);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(-1, "минус една")]
        [TestCase(-2, "минус две")]
        [TestCase(-2_001, "минус две хиляди и една")]
        [TestCase(99_999_991, "деветдесет и девет милиона деветстотин деветдесет и девет хиляди деветстотин деветдесет и една")]
        [TestCase(100_000_001, "сто милиона и една")]
        [TestCase(100_000_000_002, "сто милиарда и две")]
        public void Spell_Negative_Numbers_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number, Gender.Female);

            // Assert
            Assert.AreEqual(result, inWords);
        }
    }
}
