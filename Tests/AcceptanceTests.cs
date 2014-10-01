using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CharDown.Tests
{
    using fn = CharDown.Functions;

    public class AcceptanceTests
    {
        [Fact]
        public void Converts_a_valid_Markdown_character_sheet()
        {
            var tmpPdfPath = Path.GetTempFileName() + ".pdf";
            
            fn.Convert("test.markdown", tmpPdfPath);

            var pdfReader = new PdfReader(tmpPdfPath);
            var fields = pdfReader.AcroFields;

            Assert.Equal("Luther", fields.GetField("CharacterName"));

            Assert.Equal("13", fields.GetField("STR"));
            Assert.Equal("+1", fields.GetField("STRmod"));
            Assert.Equal("14", fields.GetField("DEX"));
            Assert.Equal("+2", fields.GetField("DEXmod "));
            Assert.Equal("13", fields.GetField("CON"));
            Assert.Equal("+1", fields.GetField("CONmod"));
            Assert.Equal("9", fields.GetField("INT"));
            Assert.Equal("-1", fields.GetField("INTmod"));
            Assert.Equal("11", fields.GetField("WIS"));
            Assert.Equal("+0", fields.GetField("WISmod"));
            Assert.Equal("6", fields.GetField("CHA"));
            Assert.Equal("-2", fields.GetField("CHamod"));
        }
    }
}
