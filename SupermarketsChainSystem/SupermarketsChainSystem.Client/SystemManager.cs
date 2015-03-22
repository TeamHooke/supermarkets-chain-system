using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketsChainSystem.Client
{
    public static class SystemManager
    {
        public static string tempDir = @"..\..\temp";
        public static string reportsDir = @"..\..\reports";

        public static void DropFolder(string directoryPath)
        {
            DirectoryInfo d = new DirectoryInfo(directoryPath);
            foreach (FileInfo fi in d.GetFiles())
            {
                fi.Delete();
            }
            foreach (DirectoryInfo di in d.GetDirectories())
            {
                DropFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
