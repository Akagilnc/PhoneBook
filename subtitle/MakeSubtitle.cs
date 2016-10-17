using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subtitle
{
    class MakeSubtitle
    {
        public Hashtable FileToString()
        {
            Hashtable table = new Hashtable();
            
            StreamReader reader = GetFile();

            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                else if (line.Trim() == "")
                {
                    continue;
                }


                string[] field = line.Split("--".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (field == null)
                {
                    continue;
                }

                string pattern = "hh:mm:ss,FFF";
               
                Key key = new Key(ParserTime(field[0]), ParserTime(field[1]));
                table.Add(key,field[2]);
            }

            return table;
        }

        private StreamReader GetFile()
        {
            Stream stream = new FileStream("..\\..\\test.srt", FileMode.Open);
            return new StreamReader(stream);
        }

        public DateTime ParserTime(String time)
        {
            DateTime parsedTime;
            string pattern = "hh:mm:ss,fff";
            time = time.Trim();
            DateTime.TryParseExact(time, pattern, null, DateTimeStyles.None, out parsedTime);
            //DateTime.TryParse(time, out parsedTime);
            return parsedTime;
        }

        public string GetValue(Hashtable table, Key key)
        {
            foreach (System.Collections.DictionaryEntry line in table)
            {
                Key tempKey = (Key)line.Key;
                if (tempKey.min <= key.min && tempKey.max >= key.max)
                {
                    return line.Value.ToString();
                }
            }

            return "";
        }
    }

    class Key
    {
        public DateTime min;
        public DateTime max;

        public Key(DateTime min, DateTime max)
        {
            this.min = min;
            this.max = max;
        }

        public Key(DateTime pos)
        {
            this.min = pos;
            this.max = pos;
        }

        public override bool Equals(object obj)
        {
            Key pom = (Key) obj;
            if (pom.max <= max && pom.min >= min)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
