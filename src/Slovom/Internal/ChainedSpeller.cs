namespace Slovom.Internal
{
    internal abstract class ChainedSpeller : Speller
    {
        public Speller InnerSpeller { get; }

        public ChainedSpeller(Speller innerSpeller)
        {
            InnerSpeller = innerSpeller;
        }
    }
}
