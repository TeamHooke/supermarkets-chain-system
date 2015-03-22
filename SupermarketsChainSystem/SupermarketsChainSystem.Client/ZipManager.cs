using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
namespace SupermarketsChainSystem.Client
{
    public class ZipManager
    {      

        public void UnZipFile(string zipFile,string toDir)
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(zipFile, toDir);
        }
    }
}
