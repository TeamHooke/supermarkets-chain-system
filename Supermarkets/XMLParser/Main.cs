﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            var parser = new XMLParser("../../Sample-Vendor-Expenses.xml");
            parser.SaveExpensesDataToDB();
        }
    }
}
