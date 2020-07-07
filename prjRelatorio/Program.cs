using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRelatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            string caminho = @"C:\pdf\" + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Título\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));
            string conteudo = "Lorem ipsum class varius litora lacinia tempus ut, himenaeos quisque faucibus fermentum pharetra " +
                "commodo libero, sodales aenean potenti sapien scelerisque sociosqu. litora proin etiam dictum euismod morbi" +
                " est etiam erat, amet torquent augue pellentesque metus quam auctor, aliquet a fringilla duis " +
                "dui viverra a. aenean ut rhoncus aptent at mattis risus duis nulla sit inceptos elit " +
                "curabitur adipiscing, at imperdiet sit enim sociosqu justo etiam faucibus vitae dictumst risus netus. " +
                "sit euismod duis feugiat quis nisi class litora imperdiet, adipiscing nec pulvinar scelerisque orci " +
                "sit sagittis, rhoncus tellus vivamus leo commodo sociosqu hac.\n\n";
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);


            /* Gerar linhas de forma dinamica (nesse caso 10)*/
              for (int i = 1; i <=10; i++) 
            {
                table.AddCell("Linha " + i + ", Coluna 1");
                table.AddCell("Linha " + i + ", Coluna 2");
                table.AddCell("Linha " + i + ", Coluna 3");
            }

            doc.Add(table);

            /*string simg = "https://static-wp-eqi15-prd.euqueroinvestir.com/wp-content/uploads/2020/01/logo-anima-555x370.jp";
            Image img = Image.GetInstance(simg);
            img.ScaleAbsolute(100, 130);
            //img.SetAbsolutePosition (10, 30);*/

           // doc.Add(img);

            doc.Close();
            System.Diagnostics.Process.Start(caminho);




        }
    }
}
