using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using Spire.Doc;
using System.Text.RegularExpressions;

namespace MyDemos
{
    public class WordToPdfConvertor
    {
        public void Convert(string docFilePath, string pdfFilePath)
        {

            object missingValue = System.Reflection.Missing.Value;
            var WORD = new Word.Application();

            Word.Document doc = WORD.Documents.Open(docFilePath);
            doc.Activate();

            doc.SaveAs2(pdfFilePath, Word.WdSaveFormat.wdFormatPDF, missingValue, missingValue, missingValue,
                missingValue, missingValue, missingValue, missingValue, missingValue, missingValue, missingValue);

            doc.Close();
            WORD.Quit();


            doc = null;
            WORD = null;
        }

        public void ConvertUsingSpireDoc()
        {
            Console.WriteLine("Hello, World!");

            Document document = new Document();
            //Load a sample document
            document.LoadFromFile(@"./example03.docx");

            //Save to PDF
            document.SaveToFile("./converted/sample.pdf", FileFormat.PDF);

            //Save to HTML
            //document.HtmlExportOptions.CssStyleSheetType = CssStyleSheetType.Internal;
            //document.HtmlExportOptions.HasHeadersFooters = false;
            document.SaveToFile("./converted/sample-as-html.html", FileFormat.Html);

            //customize
            var html = System.IO.File.ReadAllText("./converted/sample-as-html.html");
            html = Regex.Replace(html, "<!DOCTYPE(.*)<body", "<div");
            html = Regex.Replace(html, "</body></html>", "</div>");
            html = $"<style>{GetCss()}</style>{html}";

            Console.WriteLine("complete!");

            Console.ReadLine();
        }

        private string GetCss()
        {
            return @"body{ font-family:'Times New Roman'; font-size:1em; }
                    ul, ol{ margin-top: 0; margin-bottom: 0; }
                       ins{color:#2E97D3;}    del{color:#FF0000;} 
                    .Normal{page-break-inside:auto;page-break-after:auto;page-break-before:auto;line-height:1.5;margin-top:0pt;margin-bottom:0pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:12pt;font-family:Arial;}
                    .Heading-1{page-break-inside:auto;page-break-after:avoid;page-break-before:auto;line-height:1.5;margin-top:12pt;margin-bottom:3pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:16pt;font-family:Arial;mso-bidi-font-family:Arial;font-weight:bold;}
                    .Heading-2{page-break-inside:auto;page-break-after:avoid;page-break-before:auto;line-height:1.5;margin-top:0pt;margin-bottom:0pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:14pt;font-family:Arial;mso-bidi-font-family:Arial;font-weight:bold;}
                    .Heading-3{page-break-inside:auto;page-break-after:avoid;page-break-before:auto;line-height:1.5;margin-top:12pt;margin-bottom:3pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:13pt;font-family:Arial;mso-bidi-font-family:Arial;font-weight:bold;}
                    .Default-Paragraph-Font{font-family:'Times New Roman';mso-fareast-font-family:'Times New Roman';mso-bidi-font-family:'Times New Roman';lang:EN-US;mso-fareast-language:EN-US;mso-ansi-language:AR-SA;}
                    .Normal-Table{}
                    .No-List{}
                    .Strong{font-family:'Times New Roman';mso-fareast-font-family:'Times New Roman';mso-bidi-font-family:'Times New Roman';lang:EN-US;mso-fareast-language:EN-US;mso-ansi-language:AR-SA;font-weight:bold;}
                    .Table-Grid{}
                    .Style-Heading-2---Not-Italic-Before---0-pt-After---0-pt-Line-spa---{page-break-inside:auto;page-break-after:avoid;page-break-before:auto;line-height:1.5;margin-top:0pt;margin-bottom:0pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:14pt;font-family:Arial;mso-bidi-font-family:'Times New Roman';font-weight:bold;font-style:italic;}
                    .Style-Heading-2---Not-Italic{page-break-inside:auto;page-break-after:avoid;page-break-before:auto;line-height:1.5;margin-top:0pt;margin-bottom:0pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:14pt;font-family:Arial;mso-bidi-font-family:Arial;font-weight:bold;font-style:italic;}
                    .Header{page-break-inside:auto;page-break-after:auto;page-break-before:auto;line-height:1.5;margin-top:0pt;margin-bottom:0pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:12pt;font-family:Arial;}
                    .Header-Char{font-size:12pt;font-family:Arial;}
                    .Footer{page-break-inside:auto;page-break-after:auto;page-break-before:auto;line-height:1.5;margin-top:0pt;margin-bottom:0pt;margin-left:0pt;text-indent:0pt;border-top-style: none;border-left-style: none;border-right-style: none;border-bottom-style: none;font-size:12pt;font-family:Arial;}
                    .Footer-Char{font-size:12pt;font-family:Arial;}";
        }
    }
}
