using iTextSharp.text.pdf;
using System.IO;

namespace CharDown
{
    public static partial class Functions
    {
        public static void WritePdf(Character character, string pathToPdf)
        {
            using (Stream stream = typeof(Functions).Assembly.GetManifestResourceStream("CharDown.CharacterSheet.pdf"))
            {
                var pdfReader = new PdfReader(stream);
                var pdfStamper = new PdfStamper(pdfReader, new FileStream(pathToPdf, FileMode.Create));
                var fields = pdfStamper.AcroFields;

                fields.SetField("CharacterName", character.CharacterName);

                fields.SetField("STR", character.Strength);
                fields.SetField("STRmod", character.StrengthModifier);
                fields.SetField("DEX", character.Dexterity);
                fields.SetField("DEXmod ", character.DexterityModifier);
                fields.SetField("CON", character.Constitution);
                fields.SetField("CONmod", character.ConstitutionModifier);
                fields.SetField("INT", character.Intelligence);
                fields.SetField("INTmod", character.IntelligenceModifier);
                fields.SetField("WIS", character.Wisdom);
                fields.SetField("WISmod", character.WisdomModifier);
                fields.SetField("CHA", character.Charisma);
                fields.SetField("CHamod", character.CharismaModifier);

                pdfStamper.Close();
            }
        }
    }
}
