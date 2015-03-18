using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    class XMLParser
    {
        private string path;
        private static SupermarketsEntities db = new SupermarketsEntities();

        public XMLParser(string pathToXML)
        {
            path = pathToXML;
        }

        public void SaveExpensesDataToDB()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            var vendors = doc.SelectNodes("/expenses-by-month/vendor");

            try
            {
                foreach (XmlNode vendorNode in vendors)
                {
                    var vendorName = vendorNode.Attributes["name"].Value;
                    var vendor = db.Vendors.FirstOrDefault(v => v.Name == vendorName);

                    if (vendor == null)
                    {
                        throw new ArgumentException("There is no such vendor with name: " + vendorName, "vendorName");
                    }
                    foreach (XmlNode expense in vendorNode.ChildNodes)
                    {
                        var date = DateTime.ParseExact(expense.Attributes["month"].Value, "MMM-yyyy",
                            CultureInfo.InvariantCulture);
                        var money = decimal.Parse(expense.InnerText, CultureInfo.InvariantCulture);
                        db.Expenses.Add(new Expense()
                        {
                            Date = date,
                            Vendor = vendor,
                            Money = money
                        });
                    }
                    Console.WriteLine("Successfully added the expense data for vendor \"" + vendorName + "\" to the database.");
                }
                db.SaveChanges();
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("There was an error adding the expenses.");
            }

        }
    }
}
