using NUnit.Framework;

namespace Slovom.Tests.BgSpellerTests
{
    public class Spell_NeutralGender_Should
    {
        [TestCase(-0, "нула")]
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
        public void Spell_Positive_Digits_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(-1, "минус едно")]
        [TestCase(-2, "минус две")]
        [TestCase(-3, "минус три")]
        [TestCase(-99, "минус деветдесет и девет")]
        [TestCase(-500, "минус петстотин")]
        [TestCase(-2_001, "минус две хиляди и едно")]
        public void Spell_Negative_Numbers_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

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
        public void Spell_TwoDigitNumbers_Correctly(long number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

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
        [TestCase(630, "шестстотин и тридесет")]
        [TestCase(719, "седемстотин и деветнадесет")]
        [TestCase(870, "осемстотин и седемдесет")]
        [TestCase(999, "деветстотин деветдесет и девет")]
        public void Spell_ThreeDigitNumbers_Correctly(long number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(1_000, "хиляда")]
        [TestCase(2_001, "две хиляди и едно")]
        [TestCase(10_045, "десет хиляди четиридесет и пет")]
        [TestCase(99_999, "деветдесет и девет хиляди деветстотин деветдесет и девет")]
        [TestCase(100_000, "сто хиляди")]
        [TestCase(100_100, "сто хиляди и сто")]
        [TestCase(100_090, "сто хиляди и деветдесет")]
        [TestCase(100_099, "сто хиляди деветдесет и девет")]
        [TestCase(101_099, "сто и една хиляди деветдесет и девет")]
        [TestCase(468_123, "четиристотин шестдесет и осем хиляди сто двадесет и три")]
        [TestCase(500_011, "петстотин хиляди и единадесет")]
        [TestCase(634_100, "шестстотин тридесет и четири хиляди и сто")]
        [TestCase(715_000, "седемстотин и петнадесет хиляди")]
        public void Spell_UpToSixDigitNumbers_Correctly(long number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(1_000_000, "един милион")]
        [TestCase(2_030_005, "два милиона тридесет хиляди и пет")]
        [TestCase(50_010_045, "петдесет милиона десет хиляди четиридесет и пет")]
        [TestCase(99_999_999, "деветдесет и девет милиона деветстотин деветдесет и девет хиляди деветстотин деветдесет и девет")]
        [TestCase(100_000_000, "сто милиона")]
        [TestCase(100_100_000, "сто милиона и сто хиляди")]
        [TestCase(100_090_000, "сто милиона и деветдесет хиляди")]
        [TestCase(247_100_100, "двеста четиридесет и седем милиона сто хиляди и сто")]
        [TestCase(303_000_011, "триста и три милиона и единадесет")]
        [TestCase(411_001_000, "четиристотин и единадесет милиона и хиляда")]
        [TestCase(537_010_000, "петстотин тридесет и седем милиона и десет хиляди")]
        [TestCase(600_700_101, "шестстотин милиона седемстотин хиляди сто и едно")]
        public void Spell_UpToNineDigitNumbers_Correctly(long number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(int.MaxValue, "два милиарда сто четиридесет и седем милиона четиристотин осемдесет и три хиляди шестстотин четиридесет и седем")]
        [TestCase(int.MinValue, "минус два милиарда сто четиридесет и седем милиона четиристотин осемдесет и три хиляди шестстотин четиридесет и осем")]
        public void Spell_MaxAndMinLongNumber(long number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }
    }
}
