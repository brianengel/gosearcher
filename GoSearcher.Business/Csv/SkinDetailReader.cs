using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using GoSearcher.Business.Models;

namespace GoSearcher.Business.Csv
{
    public class SkinDetailReader
    {
        public SkinDetailReader()
        {

        }

        public List<SkinDetail> GetRecords(string path)
        {
            List<SkinDetail> result = null;

            using (TextReader textReader = File.OpenText(path))
            using (CsvReader csvReader = new CsvReader(textReader))
            {
                result = csvReader.GetRecords<SkinDetail>().ToList();
            }

            return result;
        }
    }
}
