using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharDown
{
    public static partial class Functions
    {
        public static void WriteMarkdown(Character character, string pathToMarkdown)
        {
            using (var writer = new StreamWriter(pathToMarkdown, append: false))
            {
                writer.WriteLine("# {0}", character.CharacterName);
                writer.WriteLine();
                writer.WriteLine("**STR**: {0} ({1})", character.StrengthModifier, character.Strength);
                writer.WriteLine("**DEX**: {0} ({1})", character.DexterityModifier, character.Dexterity);
                writer.WriteLine("**CON**: {0} ({1})", character.ConstitutionModifier, character.Constitution);
                writer.WriteLine("**INT**: {0} ({1})", character.IntelligenceModifier, character.Intelligence);
                writer.WriteLine("**WIS**: {0} ({1})", character.WisdomModifier, character.Wisdom);
                writer.WriteLine("**CHA**: {0} ({1})", character.CharismaModifier, character.Charisma);
                writer.WriteLine();
            }
        }
    }
}
