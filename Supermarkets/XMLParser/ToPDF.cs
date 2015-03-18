using XMLParser;

namespace PDFSalesReports
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public static class ToPDF
    {
        public static void CreateAndStylePdf(DateTime startDate, DateTime endDate)
        {
            var fileName = DateTime.Now.ToString("dd.MMMM.yyyy") + "-Sale-Report" + ".pdf";
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName);

            var saleExport = new Document(PageSize.A4, 2, 2, 2, 2);

            var ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            var fontHeader = new Font(bf, 18, Font.BOLD, BaseColor.GRAY);
            var fontBody = new Font(bf, 8, Font.NORMAL, BaseColor.BLACK);

            try
            {
                FillSaleReportPdf(saleExport, filePath, startDate, endDate, fontHeader, fontBody);
            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Print operation failed \n" + e.Message);
                Console.ResetColor();
            }
            finally
            {
                if (saleExport.IsOpen())
                {
                    saleExport.Close();
                }
            }
        }

        private static void FillSaleReportPdf(Document saleExport, string filePath, DateTime startDate, DateTime endDate, Font fontHeader, Font fontBody)
        {
            PdfWriter.GetInstance(saleExport, new FileStream(filePath, FileMode.Create));
            var dataForExport = SalesReportBetweenDates(startDate, endDate);

            if (dataForExport == null || dataForExport.ToList().Count <= 0) { throw new IOException("In these interval doesn't have sales"); }

            saleExport.Open();

            var grandTotal = 0m;

            foreach (var key in dataForExport)
            {
                PdfPTable table = new PdfPTable(5)
                {
                    HorizontalAlignment = 1,
                    SpacingAfter = 10f,
                    SpacingBefore = 10f
                };

                PdfPCell dateCell =
                    new PdfPCell(new Phrase(string.Format("{0}", key.Key.ToString("dd.MM.yyyy")), fontHeader))
                    {
                        Colspan = 5,
                    };
                table.AddCell(dateCell);
                table.AddCell("Product");
                table.AddCell("Quantity");
                table.AddCell("Unit Price");
                table.AddCell("Location");
                table.AddCell("Sum");

                var sum = 0m;

                foreach (var sale in key.ToList())
                {
                    table.AddCell(new PdfPCell(new Phrase(string.Format("{0}",
                        string.Format("{0}\"{1}\"", sale.Product.Name, sale.Product.Vendor.Name)), fontBody)));
                    table.AddCell(new PdfPCell(new Phrase(string.Format("{0}",
                        string.Format("{0} {1}", sale.CountOfSales, sale.Product.Measure.Name)), fontBody)));
                    table.AddCell(new PdfPCell(new Phrase(string.Format("{0}", sale.Product.Price), fontBody)));
                    table.AddCell(
                        new PdfPCell(new Phrase(string.Format("Supermarket \"{0}\"", sale.Supermarket.Location), fontBody)));
                    table.AddCell(
                        new PdfPCell(new Phrase(string.Format("{0:F2}", sale.CountOfSales * sale.Product.Price), fontBody)));
                    sum += (sale.CountOfSales * sale.Product.Price);
                }
                PdfPCell sumCell =
                    new PdfPCell(new Phrase(string.Format("{0:F2}", sum), fontHeader))
                    {
                        Colspan = 5,
                        HorizontalAlignment = 2
                    };
                table.AddCell(sumCell);
                saleExport.Add(table);
                grandTotal += sum;
            }
            PdfPTable totalData = new PdfPTable(1)
            {
                HorizontalAlignment = 1,
                SpacingAfter = 10f,
                SpacingBefore = 10f
            };
            var totalCell = new PdfPCell(new Phrase(string.Format("Grand Total: {0:F2}", grandTotal), fontHeader))
            {
                HorizontalAlignment = 2,
                BackgroundColor = new BaseColor(108, 232, 248)
            };

            totalData.AddCell(totalCell);
            saleExport.Add(totalData);

            saleExport.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finish. The file Will be open any seconds.");
            Console.ResetColor();

            System.Diagnostics.Process.Start(filePath);
        }

        private static IOrderedEnumerable<IGrouping<DateTime, Supermarket_Sales>> SalesReportBetweenDates(DateTime startDate, DateTime endDate)
        {
            var context = new SupermarketsEntities();

            var SalesReportList = context.Supermarket_Sales
                .Include(s => s.Product)
                .Include(s => s.Product.Vendor)
                .Include(s => s.Product.Measure)
                .Include(s => s.Supermarket)
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .ToList();
            var OrderByDate = SalesReportList.GroupBy(s => s.Date).OrderBy(s => s.Key);

            return OrderByDate;
        }
    }
}
