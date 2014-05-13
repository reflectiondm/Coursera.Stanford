using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflectiondm.Utils
{
    public static class FileHelper
    {
        public static long[] GetArrayFromFile(string filePath)
        {
            var result = new List<long>();
            var fullPath = Path.GetFullPath(filePath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fullPath);

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var number = Int64.Parse(line);
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
}
