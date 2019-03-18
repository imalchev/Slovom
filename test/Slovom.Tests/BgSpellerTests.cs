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
            var sut = new BgSpeller();

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
            var sut = new BgSpeller();

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
            var sut = new BgSpeller();

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
        [TestCase(870, "���������� � ����������")]
        [TestCase(999, "����������� ���������� � �����")]
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