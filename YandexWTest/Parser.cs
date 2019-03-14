using System;
using System.Collections.Generic;
using System.IO;

namespace YandexWTest
{
    class Parser: IDisposable
    {
        StreamReader streamReader;
        string[] titles;
        public Parser(string path)
        {
            streamReader = new StreamReader(path);
        }

        public void ReadHeader()
        {
            var s = streamReader.ReadLine();
            titles = s.Split(';');
        }

        public bool HasMoreRecords()
        {
            return streamReader.EndOfStream;
        }

        public Dictionary<string,string> GetRecord()
        {
            Dictionary<string, string> record = new Dictionary<string, string>(titles.Length);
            var s = streamReader.ReadLine();
            var subs = s.Split(';');
            int i = 0;
            foreach (var t in subs)
                record.Add(titles[i++], t);
            return record;
        }

        public void Dispose()
        {
            streamReader.Dispose();
        }
        
    }
}
