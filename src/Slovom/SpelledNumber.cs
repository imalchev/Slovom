namespace Slovom
{
    /// <summary>
    /// Represent positive spelled number. Holds information if there is concatenation using "и" word.
    /// </summary>
    internal class SpelledNumber
    {
        public ulong Number { get; }

        public string Spelled { get; }

        public bool ContainsAnd { get; }

        public SpelledNumber(ulong number, string spelled, bool containsAnd)
        {
            Number = number;
            Spelled = spelled;
            ContainsAnd = containsAnd;
        }

        public SpelledNumber Concat(SpelledNumber other)
        {
            if (!other.ContainsAnd)
            {
                return new SpelledNumber(
                    number: this.Number + other.Number,
                    spelled: this.Spelled + " и " + other.Spelled,
                    containsAnd: true);
            }

            return new SpelledNumber(
                number: this.Number + other.Number,
                spelled: this.Spelled + " " + other.Spelled,
                containsAnd: true);
        }

        public override string ToString()
        {
            return this.Spelled;
        }
    }
}
