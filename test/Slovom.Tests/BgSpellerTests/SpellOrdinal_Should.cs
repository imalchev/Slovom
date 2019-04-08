using NUnit.Framework;

namespace Slovom.Tests.BgSpellerTests
{
    public class SpellOrdinal_Should
    {
        [TestCase(-0, "нулево")]
        [TestCase(0, "нулево")]
        [TestCase(1, "първо")]
        [TestCase(2, "второ")]
        [TestCase(3, "трето")]
        [TestCase(4, "четвърто")]
        [TestCase(5, "пето")]
        [TestCase(6, "шесто")]
        [TestCase(7, "седмо")]
        [TestCase(8, "осмо")]
        [TestCase(9, "девето")]
        public void Spell_Positive_Digits_Correctly(long number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(10, Gender.Neutral, "десето")]
        [TestCase(10, Gender.Male, "десети")]
        [TestCase(11, Gender.Neutral, "единадесето")]
        [TestCase(12, Gender.Neutral, "дванадесето")]
        [TestCase(12, Gender.Female, "дванадесета")]
        [TestCase(13, Gender.Neutral, "тринадесето")]
        [TestCase(14, Gender.Neutral, "четиринадесето")]
        [TestCase(14, Gender.Female, "четиринадесета")]
        [TestCase(15, Gender.Neutral, "петнадесето")]
        [TestCase(17, Gender.Male, "седемнадесети")]
        [TestCase(18, Gender.Female, "осемнадесета")]
        [TestCase(19, Gender.Neutral, "деветнадесето")]
        [TestCase(19, Gender.Female, "деветнадесета")]
        public void Spell_Positive_Numbers_From_10_UpTo_19_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(20, Gender.Neutral, "двадесето")]
        [TestCase(21, Gender.Male, "двадесет и първи")]
        [TestCase(35, Gender.Female, "тридесет и пета")]
        [TestCase(44, Gender.Neutral, "четиридесет и четвърто")]
        [TestCase(55, Gender.Male, "петдесет и пети")]
        [TestCase(60, Gender.Neutral, "шестдесето")]
        [TestCase(77, Gender.Female, "седемдесет и седма")]
        [TestCase(78, Gender.Male, "седемдесет и осми")]
        [TestCase(90, Gender.Male, "деветдесети")]
        [TestCase(93, Gender.Female, "деветдесет и трета")]
        public void Spell_Positive_Numbers_From_20_UpTo_99_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(100, Gender.Male, "стотен")]
        [TestCase(101, Gender.Female, "сто и първа")]
        [TestCase(200, Gender.Female, "двестна")]
        [TestCase(200, Gender.Male, "двестен")]
        [TestCase(210, Gender.Neutral, "двеста и десето")]
        [TestCase(248, Gender.Male, "двеста четиридесет и осми")]
        [TestCase(351, Gender.Female, "триста петдесет и първа")]
        [TestCase(444, Gender.Neutral, "четиристотин четиридесет и четвърто")]
        [TestCase(500, Gender.Male, "петстотен")]
        [TestCase(600, Gender.Neutral, "шестстотно")]
        [TestCase(713, Gender.Female, "седемстотин и тринадесета")]
        [TestCase(780, Gender.Male, "седемстотин и осемдесети")]
        [TestCase(909, Gender.Female, "деветстотин и девета")]
        public void Spell_Positive_Numbers_From_100_UpTo_999_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(1_000, Gender.Male, "хиляден")]
        [TestCase(1_000, Gender.Female, "хилядна")]
        [TestCase(1_001, Gender.Male, "хиляда и първи")]
        [TestCase(1_100, Gender.Female, "хиляда и стотна")]
        [TestCase(2_000, Gender.Male, "две хиляден")]
        [TestCase(2_000, Gender.Female, "две хилядна")]
        [TestCase(2_000, Gender.Neutral, "две хилядно")]
        [TestCase(2_001, Gender.Neutral, "две хиляди и първо")]
        [TestCase(2_019, Gender.Female, "две хиляди и деветнадесета")]
        [TestCase(2_150, Gender.Female, "две хиляди сто и петдесета")]
        [TestCase(33_000, Gender.Male, "тридесет и три хиляден")]
        [TestCase(100_000, Gender.Female, "сто хилядна")]
        [TestCase(100_011, Gender.Neutral, "сто хиляди и единадесето")]
        [TestCase(100_110, Gender.Male, "сто хиляди сто и десети")]
        [TestCase(101_000, Gender.Male, "сто и една хиляден")]
        [TestCase(101_000, Gender.Female, "сто и една хилядна")]
        [TestCase(102_000, Gender.Male, "сто и две хиляден")]
        [TestCase(102_000, Gender.Female, "сто и две хилядна")]
        [TestCase(102_000, Gender.Neutral, "сто и две хилядно")]
        [TestCase(321_123, Gender.Neutral, "триста двадесет и една хиляди сто двадесет и трето")]
        public void Spell_Positive_Numbers_From_1_000_UpTo_999_999_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(1_000_000, Gender.Male, "милионен")]
        [TestCase(1_000_000, Gender.Female, "милионна")]
        [TestCase(1_000_001, Gender.Male, "един милион и първи")]
        [TestCase(1_100_000, Gender.Female, "един милион и сто хилядна")]
        [TestCase(2_000_000, Gender.Male, "два милионен")]
        [TestCase(2_000_000, Gender.Female, "два милионна")]
        [TestCase(2_000_000, Gender.Neutral, "два милионно")]
        [TestCase(2_000_001, Gender.Neutral, "два милиона и първо")]
        [TestCase(2_000_019, Gender.Female, "два милиона и деветнадесета")]
        [TestCase(2_123_150, Gender.Female, "два милиона сто двадесет и три хиляди сто и петдесета")]
        [TestCase(33_000_000, Gender.Male, "тридесет и три милионен")]
        [TestCase(100_000_000, Gender.Female, "сто милионна")]
        [TestCase(100_100_011, Gender.Neutral, "сто милиона сто хиляди и единадесето")]
        [TestCase(111_100_110, Gender.Male, "сто и единадесет милиона сто хиляди сто и десети")]
        public void Spell_Positive_Numbers_From_1_000_000_UpTo_999_999_999_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(1_000_000_000, Gender.Female, "милиардна")]
        [TestCase(1_000_000_100, Gender.Male, "един милиард и стотен")]
        [TestCase(315_111_100_000, Gender.Neutral, "триста и петнадесет милиарда сто и единадесет милиона и сто хилядно")]
        [TestCase(1_000_000_000_000, Gender.Neutral, "трилионно")]
        [TestCase(1_000_000_000_000, Gender.Female, "трилионна")]
        [TestCase(1_000_000_000_000_000, Gender.Male, "квадрилионен")]
        [TestCase(1_000_000_000_000_000, Gender.Female, "квадрилионна")]
        public void Spell_Positive_Numbers_Bigger_Than_999_999_999_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }


        [TestCase(-0, Gender.Male, "нулев")]
        [TestCase(0, Gender.Female, "нулева")]
        [TestCase(1, Gender.Male, "първи")]
        [TestCase(1, Gender.Female, "първа")]
        [TestCase(2, Gender.Male, "втори")]
        [TestCase(2, Gender.Female, "втора")]
        [TestCase(3, Gender.Male, "трети")]
        [TestCase(4, Gender.Male, "четвърти")]
        [TestCase(4, Gender.Neutral, "четвърто")]
        [TestCase(5, Gender.Male, "пети")]
        [TestCase(6, Gender.Male, "шести")]
        [TestCase(7, Gender.Male, "седми")]
        [TestCase(7, Gender.Female, "седма")]
        [TestCase(8, Gender.Male, "осми")]
        [TestCase(9, Gender.Male, "девети")]
        [TestCase(9, Gender.Neutral, "девето")]
        public void Spell_Positive_Numbers_Correctly(long number, Gender gender, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.SpellOrdinal(number, gender);

            // Assert
            Assert.AreEqual(result, inWords);
        }
    }
}
