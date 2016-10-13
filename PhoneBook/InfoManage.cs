using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class InfoManage
    {
        public string GetInfo(String name)
        {
            DataTools dt = new DataTools();
            var sql = "select * from phonebook where name like @name";


            var result = dt.Query(sql, name);

            return MakeResult(result);


        }

        public int Insert()
        {
            DataTools dt = new DataTools();
            var sqls = new string[1];
            sqls[0] = "insert or replace into phonebook values(6, 'test4', 18000000000)";
            var result = dt.NonQuery(sqls);
            return result;
        }

        private String MakeResult(DataTable resultTable)
        {
            String result = "";
            if ((resultTable != null) && (resultTable.Rows.Count > 0))
            {
                for (int i = 0; i < resultTable.Rows.Count; i++)
                {
                    result += "Name:" + resultTable.Rows[i]["Name"] + "    PhoneNum:" + resultTable.Rows[i]["PhoneNum"] +
                              "\n";
                }
                return result;
            }
            else
            {
                return @"Nothing founded";
            }
        }

    }
}
