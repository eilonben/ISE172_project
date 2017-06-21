using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Business_Layer
{
    public class PDFGenerator
    {
        
        public PDFGenerator(string toSave) {
            FileStream fs = new FileStream("../../../Reports/UserReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(toSave));
            doc.Close();
        }

    }
}
