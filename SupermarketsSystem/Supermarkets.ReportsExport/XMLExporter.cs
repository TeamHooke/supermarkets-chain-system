﻿using System;

using System.Text;
using System.Globalization;
using System.Xml;
using System.Data.Entity;
using System.Linq;
using Supermarkets.Data;

namespace Supermarkets.ReportsExport
{
    public static class XMLExporter 
    {
        public static void WriteToXml(SupermarketsEntities db,
            DateTime startDate,DateTime endDate)
        {

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "\t";

            var vendors = from ss in db.Supermarket_Sales
                        join p in db.Products on ss.ProductId equals p.Id
                        join v in db.Vendors on p.VendorId equals v.Id
                        group ss by new { v.Id, v.Name } into g
                        select new
                        {
                            Name = g.Key.Name,
                            Sales = db.Supermarket_Sales
                            .Where(ss => ss.Product.VendorId == g.Key.Id && 
                                ss.Date >= startDate && ss.Date <= endDate)
                                .OrderBy(ss => ss.Date)
                        };

          
            using (XmlWriter writer = XmlWriter.Create("Sales-by-Vendors-Report.xml",settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var v in vendors)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", v.Name);

                    foreach (var s in v.Sales)
                    {
                        writer.WriteStartElement("summary");
                        writer.WriteAttributeString("date", s.Date.ToString("dd-MMM-yyyy",CultureInfo.InvariantCulture));
                        writer.WriteAttributeString("total-sum", 
                            decimal.Round(s.Product.Price * s.CountOfSales,2)
                            .ToString(CultureInfo.InvariantCulture));
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }


    }
}
