using System;
using System.Collections.Generic;
using System.Text;

namespace Slovom.SpellerRules
{
    internal interface INumberSpeller
    {
        SpelledNumber Spell(uint number, Gender gender = Gender.Neutral);
    }
}
