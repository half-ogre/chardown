using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CharDown
{
    public static partial class Functions
    {
        static IEnumerable<Func<string, string, Character, string>> BuildRules()
        {
            var rules = new List<Func<string, string, Character, string>>();

            rules.Add(ReadCharacterName);
            rules.Add(ReadAbility);

            return rules;
        }

        static string ReadAbility(
            string section,
            string line,
            Character character)
        {
            if (!section.Equals("root", StringComparison.InvariantCultureIgnoreCase))
                return null;

            var regex = new Regex(@"^\*\*(STR|DEX|CON|WIS|INT|CHA)\*\*\s+(\d+)\s+\(\s*([+-]+\d+)\s*\)\s*$");
            var match = regex.Match(line);

            if (!match.Success)
                return null;
            
            var ability = match.Groups[1].Captures[0].Value;
            var value = match.Groups[2].Captures[0].Value;
            var modifier = match.Groups[3].Captures[0].Value;

            switch (ability)
            {
                case "STR":
                    character.Strength = value;
                    character.StrengthModifier = modifier;
                    break;
                case "DEX":
                    character.Dexterity = value;
                    character.DexterityModifier = modifier;
                    break;
                case "CON":
                    character.Constitution = value;
                    character.ConstitutionModifier = modifier;
                    break;
                case "INT":
                    character.Intelligence = value;
                    character.IntelligenceModifier = modifier;
                    break;
                case "WIS":
                    character.Wisdom = value;
                    character.WisdomModifier = modifier;
                    break;
                case "CHA":
                    character.Charisma = value;
                    character.CharismaModifier = modifier;
                    break;
            }

            return section;
        }
        
        static string ReadCharacterName(
            string section, 
            string line, 
            Character character)
        {
            if (!section.Equals("root", StringComparison.InvariantCultureIgnoreCase))
                return null;
            
            var regex = new Regex(@"^\#\ (.+)$");
            var match = regex.Match(line);

            if (!match.Success)
                return null;
                
            character.CharacterName = match.Groups[1].Captures[0].Value;

            return section;
        }
        
        public static Character ReadMarkdown(string pathToMarkdown)
        {
            var character = new Character();
            var rules = BuildRules();
            
            using (var reader = new StringReader(File.ReadAllText(pathToMarkdown)))
            {
                string line;
                string section = "root";

                while ((line = reader.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(line))
                        continue;

                    section = rules.Select(x => x(section, line, character)).FirstOrDefault(x => x != null) ?? section;
                }
            }

            return character;
        }
    }
}
