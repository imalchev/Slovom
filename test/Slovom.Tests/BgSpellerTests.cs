using NUnit.Framework;
using Slovom;

namespace Tests
{
    public class BgSpellerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, "нула")]
        [TestCase(1, "едно")]
        [TestCase(2, "две")]
        [TestCase(3, "три")]
        [TestCase(4, "четири")]
        [TestCase(5, "пет")]
        [TestCase(6, "шест")]
        [TestCase(7, "седем")]
        [TestCase(8, "осем")]
        [TestCase(9, "девет")]
        public void Spell_Should_Spell_Positive_Digits_Correctly(int number, string result)
        {
            // Arrange
            var sut = new BgSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(-1, "минус едно")]
        [TestCase(-2, "минус две")]
        [TestCase(-3, "минус три")]
        [TestCase(-4, "минус четири")]
        [TestCase(-5, "минус пет")]
        [TestCase(-6, "минус шест")]
        [TestCase(-7, "минус седем")]
        [TestCase(-8, "минус осем")]
        [TestCase(-9, "минус девет")]
        public void Spell_Should_Spell_Negative_Digits_Correctly(int number, string result)
        {
            // Arrange
            var sut = new BgSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(11, "единадесет")]
        [TestCase(12, "дванадесет")]
        [TestCase(13, "тринадесет")]
        [TestCase(15, "петнадесет")]
        [TestCase(19, "деветнадесет")]
        [TestCase(20, "двадесет")]
        [TestCase(30, "тридесет")]
        [TestCase(33, "тридесет и три")]
        [TestCase(45, "четиридесет и пет")]
        [TestCase(51, "петдесет и едно")]
        [TestCase(59, "петдесет и девет")]
        [TestCase(68, "шестдесет и осем")]
        [TestCase(87, "осемдесет и седем")]
        [TestCase(99, "деветдесет и девет")]
        public void Spell_Should_Spell_TwoDigitNumbers_Correctly(int number, string expected)
        {
            // Arrange
            var sut = new BgSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(100, "сто")]
        [TestCase(101, "сто и едно")]
        [TestCase(113, "сто и тринадесет")]
        [TestCase(120, "сто и двадесет")]
        [TestCase(250, "двеста и петдесет")]        
        [TestCase(468, "четиристотин шестдесет и осем")]
        [TestCase(500, "петстотин")]
        [TestCase(870, "осемстотин и седемдесет")]
        [TestCase(999, "деветстотин деветдесет и девет")]
        public void Spell_Should_Spell_ThreeDigitNumbers_Correctly(int number, string expected)
        {
            // Arrange
            var sut = new BgSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }
    }
}