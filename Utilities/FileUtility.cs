using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FileUtility
    {
        public static IEnumerable<dynamic> LoadCsvData(string filePath)
        {
            var users = new List<dynamic>();

            using (var reader = new StreamReader(filePath))
            using (var csvFile = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                users = csvFile.GetRecords<dynamic>().ToList();
            }
            return users;
        }

        public static void DeleteAllDirectoryFiles(string directoryPath)
        {
            string[] filePaths = Directory.GetFiles(directoryPath);
            foreach (var filePath in filePaths)
            {
                File.Delete(filePath);
            }
        }

        public void CreateDirectory(string directoryPath)
        {
            //string directoryPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//Screenshots";
            var IsDirectory = Directory.Exists(directoryPath);
            if (!IsDirectory)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

    }
}
