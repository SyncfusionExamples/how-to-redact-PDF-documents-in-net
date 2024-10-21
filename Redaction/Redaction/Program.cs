using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Pdf.Graphics;

namespace Redaction {
    internal class Program {
        static void Main(string[] args) {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
            RedactPDF();
            //RedactPDF_FillColor();
            //Redact_Image();
            //Redact_Text();
            
        }
        static void RedactPDF() {
            //Create stream from an existing PDF document. 
            FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
            //Load the existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
            //Get the first page from the document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create a redaction object.
            PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17));
            //Add a redaction object into the redaction collection of loaded page.
            page.AddRedaction(redaction);
            //Redact the contents from the PDF document.
            document.Redact();

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
        static void RedactPDF_FillColor() {
            //Get stream from an existing PDF document.
            FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
            //Load the PDF document. 
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
            //Get the first page from the document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create a PDF redaction for the page.
            PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17));
            //Set fill color for the redaction bounds.
            redaction.FillColor = Color.Red;
            //Add a redaction object into the redaction collection of loaded page.
            page.AddRedaction(redaction);
            //Redact the contents from the PDF document.
            document.Redact();

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output1.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
        static void Redact_Text() {
            //Get stream from an existing PDF document. 
            FileStream docStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read);
            //Load the existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
            //Get the first page from the document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create a redaction object.
            PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17));
            //Font for the overlay text.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Courier, 10);
            //Draw text on the redacted area.
            redaction.Appearance.Graphics.DrawString("Redacted", font, PdfBrushes.Red, new PointF(5, 5));
            //Add a redaction object into the redaction collection of loaded page.
            page.AddRedaction(redaction);
            //Redact the contents from the PDF document.
            document.Redact();

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output2.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
        static void Redact_Image() {
            //Get stream from an existing PDF document. 
            FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
            //Load the existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
            //Get the first page from the document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create a PDF redaction for the page.
            PdfRedaction redaction = new PdfRedaction(new RectangleF(63, 57, 182, 157));
            //Get stream from the image file.
            FileStream imageStream = new FileStream(Path.GetFullPath(@"../../../Image.jpg"), FileMode.Open, FileAccess.Read);
            //Load the image file. 
            PdfImage image = new PdfBitmap(imageStream);
            //Draw image on the redaction appearance. 
            redaction.Appearance.Graphics.DrawImage(image, new RectangleF(0, 0, 182, 157));
            //Add a redaction object into the redaction collection of loaded page.
            page.AddRedaction(redaction);
            //Redact the contents from the PDF document.
            document.Redact();

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output3.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
    }
}