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
        public static Character ReadPdf(string pathToPdf)
        {
            var pdfReader = new PdfReader(pathToPdf);

            var character = new Character();

            character.CharacterName = ReadRequiredPdfField(pdfReader, "CharacterName");
            
            character.StrengthModifier = ReadRequiredPdfField(pdfReader, "STRmod");
            character.Strength = ReadRequiredPdfField(pdfReader, "STR");
            character.DexterityModifier = ReadRequiredPdfField(pdfReader, "DEXmod ");
            character.Dexterity = ReadRequiredPdfField(pdfReader, "DEX");
            character.ConstitutionModifier = ReadRequiredPdfField(pdfReader, "CONmod");
            character.Constitution = ReadRequiredPdfField(pdfReader, "CON");
            character.IntelligenceModifier = ReadRequiredPdfField(pdfReader, "INTmod");
            character.Intelligence = ReadRequiredPdfField(pdfReader, "INT");
            character.WisdomModifier = ReadRequiredPdfField(pdfReader, "WISmod");
            character.Wisdom = ReadRequiredPdfField(pdfReader, "WIS");
            character.CharismaModifier = ReadRequiredPdfField(pdfReader, "CHamod");
            character.Charisma = ReadRequiredPdfField(pdfReader, "CHA");

            return character;
        }

        public static string ReadRequiredPdfField(PdfReader pdfReader, string key)
        {
            return pdfReader.AcroFields.GetField(key);
        }
    }
}
