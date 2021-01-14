/*
 **********************************************************
 *                                                        *
 * By: Ameer Kassis - Sameer Zaher - Yuri Malamoud - 41/1 *
 *                                                        *
 **********************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace BeerStoreProject
{

    class Pfile
    {
        public Document doc;
        // public Font myFont;
        public Pfile()//con creates file with default name
        {
            doc = new Document();
            doc.Open();
            PdfWriter.GetInstance(doc, new FileStream("NewPdf.pdf", FileMode.Create));
        }

        public Pfile(string name)//con creates file with given name
        {
            doc = new Document();
            if (doc.IsOpen() == false)
            {
                doc.Open();
            }
            PdfWriter.GetInstance(doc, new FileStream(name, FileMode.Create));
        }

        public void SetTitle(string title)//set title
        {
            Font myFont = new Font(Font.FontFamily.COURIER, 20, Font.ITALIC);
            myFont.Color = BaseColor.GREEN;
            doc.Add(new Paragraph(title, myFont));
            doc.Add(new Paragraph("\n\n\n"));
        }

        public void SetImage(string imagePath)//add image
        {
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(imagePath);
            this.doc.Add(png);
            doc.Add(new Paragraph("\n\n\n"));

        }

        public void CloseReport()//close document
        {
            this.doc.Close();
        }


    }
}
