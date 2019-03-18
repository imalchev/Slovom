using System;
using System.Collections.Generic;
using System.Text;

namespace Slovom.SpellerRules
{
    internal interface ISpellingRule
    {
        bool Match(ushort number);

        string Spell(ushort number);
    }
}
