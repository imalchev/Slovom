using NUnit.Framework;
using Slovom;

namespace Tests
{
    public class BgSpellerTests
    {
        [TestCase(0, "����")]
        [TestCase(1, "����")]
        [TestCase(2, "���")]
        [TestCase(3, "���")]
        [TestCase(4, "������")]
        [TestCase(5, "���")]
        [TestCase(6, "����")]
        [TestCase(7, "�����")]
        [TestCase(8, "����")]
        [TestCase(9, "�����")]
        public void Spell_Should_Spell_Positive_Digits_Correctly(int number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(-1, "����� ����")]
        [TestCase(-2, "����� ���")]
        [TestCase(-3, "����� ���")]
        [TestCase(-4, "����� ������")]
        [TestCase(-5, "����� ���")]
        [TestCase(-6, "����� ����")]
        [TestCase(-7, "����� �����")]
        [TestCase(-8, "����� ����")]
        [TestCase(-9, "����� �����")]
        public void Spell_Should_Spell_Negative_Digits_Correctly(int number, string result)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(result, inWords);
        }

        [TestCase(11, "����������")]
        [TestCase(12, "����������")]
        [TestCase(13, "����������")]
        [TestCase(15, "����������")]
        [TestCase(19, "������������")]
        [TestCase(20, "��������")]
        [TestCase(30, "��������")]
        [TestCase(33, "�������� � ���")]
        [TestCase(45, "����������� � ���")]
        [TestCase(51, "�������� � ����")]
        [TestCase(59, "�������� � �����")]
        [TestCase(68, "��������� � ����")]
        [TestCase(87, "��������� � �����")]
        [TestCase(99, "���������� � �����")]
        public void Spell_Should_Spell_TwoDigitNumbers_Correctly(int number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(100, "���")]
        [TestCase(101, "��� � ����")]
        [TestCase(113, "��� � ����������")]
        [TestCase(120, "��� � ��������")]
        [TestCase(250, "������ � ��������")]        
        [TestCase(468, "������������ ��������� � ����")]
        [TestCase(500, "���������")]
        [TestCase(630, "���������� � ��������")]
        [TestCase(719, "����������� � ������������")]
        [TestCase(870, "���������� � ����������")]
        [TestCase(999, "����������� ���������� � �����")]
        public void Spell_Should_Spell_ThreeDigitNumbers_Correctly(int number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(1_000, "������")]
        [TestCase(2_001, "��� ������ � ����")]
        [TestCase(10_045, "����� ������ ����������� � ���")]
        [TestCase(99_999, "���������� � ����� ������ ����������� ���������� � �����")]
        [TestCase(100_000, "��� ������")]
        [TestCase(100_100, "��� ������ � ���")]
        [TestCase(100_090, "��� ������ � ����������")]
        [TestCase(100_099, "��� ������ ���������� � �����")]
        [TestCase(101_099, "��� � ���� ������ ���������� � �����")]
        [TestCase(468_123, "������������ ��������� � ���� ������ ��� �������� � ���")]
        [TestCase(500_011, "��������� ������ � ����������")]
        [TestCase(634_100, "���������� �������� � ������ ������ � ���")]
        [TestCase(715_000, "����������� � ���������� ������")]
        public void Spell_Should_Spell_UpToSixDigitNumbers_Correctly(int number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(1_000_000, "���� ������")]
        [TestCase(2_030_005, "��� ������� �������� ������ � ���")]
        [TestCase(50_010_045, "�������� ������� ����� ������ ����������� � ���")]
        [TestCase(99_999_999, "���������� � ����� ������� ����������� ���������� � ����� ������ ����������� ���������� � �����")]
        [TestCase(100_000_000, "��� �������")]
        [TestCase(100_100_000, "��� ������� � ��� ������")]
        [TestCase(100_090_000, "��� ������� � ���������� ������")]
        [TestCase(247_100_100, "������ ����������� � ����� ������� ��� ������ � ���")]
        [TestCase(303_000_011, "������ � ��� ������� � ����������")]
        [TestCase(411_001_000, "������������ � ���������� ������� � ������")]
        [TestCase(537_010_000, "��������� �������� � ����� ������� � ����� ������")]
        [TestCase(600_700_101, "���������� ������� ����������� ������ ��� � ����")]
        public void Spell_Should_Spell_UpToNineDigitNumbers_Correctly(int number, string expected)
        {
            // Arrange
            var sut = new BgNumberSpeller();

            // Act
            string inWords = sut.Spell(number);

            // Assert
            Assert.AreEqual(expected, inWords);
        }

        [TestCase(int.MaxValue, "��� �������� ��� ����������� � ����� ������� ������������ ��������� � ��� ������ ���������� ����������� � �����")]
        [TestCase(int.MinValue, "����� ��� �������� ��� ����������� � ����� ������� ������������ ��������� � ��� ������ ���������� ����������� � ����")]
        public void Spell_Should_Spell_MaxAndMinLongNumber(int number, string expected)
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