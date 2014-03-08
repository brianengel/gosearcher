using System;
using System.Collections.Generic;
using GoSearcher.Business.Csv;

namespace GoSearcher.Business.Models
{
    public class SkinDetailCache : ISkinDetailCache
    {
        private static SkinDetailCache current;
        private Dictionary<string, SkinDetail> lookup = new Dictionary<string, SkinDetail>(StringComparer.InvariantCultureIgnoreCase);

        public static SkinDetailCache Current
        {
            get
            {
                if (current == null)
                {
                    current = new SkinDetailCache();
                }

                return current;
            }
        }

        private SkinDetailCache()
        {

        }

        public void LoadFile(string path)
        {
            SkinDetailReader reader = new SkinDetailReader();
            List<SkinDetail> records = reader.GetRecords(path);

            foreach (var record in records)
            {
                lookup.Add(record.Name, record);
            }
        }

        public SkinDetail Get(string name)
        {
            if (lookup.ContainsKey(name))
            {
                return lookup[name];
            }

            return null;
        }
    }
}
