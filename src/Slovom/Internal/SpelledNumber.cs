namespace Slovom.Internal
{
    /// <summary>
    /// Represent positive spelled number. Holds information if there is concatenation using "и" word.
    /// </summary>
    internal class SpelledNumber
    {
        public string Spelled { get; }

        public bool ContainsAnd { get; }

        public SpelledNumber(string spelled, bool containsAnd)
        {
            Spelled = spelled;
            ContainsAnd = containsAnd;
        }

        public SpelledNumber Concat(SpelledNumber other)
        {
            if (!other.ContainsAnd)
            {
                return new SpelledNumber(
                    spelled: this.Spelled + " и " + other.Spelled,
                    containsAnd: true);
            }

            return new SpelledNumber(
                spelled: this.Spelled + " " + other.Spelled,
                containsAnd: true);
        }

        public override string ToString()
        {
            return this.Spelled;
        }
    }
}
