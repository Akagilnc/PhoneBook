using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        public void querybutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetInfo());
        }

        public void testaddbutton_Click(object sender, EventArgs e)
        {
            var result = Insert();
            MessageBox.Show(result.ToString() + @" was successful");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
            String name = textBox1.Text;
        }

   

        private String GetInfo()
        {
            String sql = "select * from phonebook where name = @name";
            

            DataTable result = Query(sql);
            if (result != null && result.Rows.Count > 0)
            {
                return "Name:" + result.Rows[0]["Name"] + "    PhoneNum:" + result.Rows[0]["PhoneNum"];
            }
            else
            {
                return @"Nothing founded";
            }
            
        }

        private int Insert()
        {
            String[] sqls = new string[1];
            sqls[0] = "insert or replace into phonebook values(6, 'test4', 18000000000)";
            var result = NonQuery(sqls);
            return result;
        }

        private DataTable Query(String sqlCommand)
        {
            SQLiteConnection myConnection = GetConnection();

            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
           
            try
            {
                myConnection.Open();
                SQLiteCommand sqLiteCommand = myConnection.CreateCommand();
                sqLiteCommand.CommandText = sqlCommand;
                sqLiteCommand.CommandTimeout = 15;
                sqLiteCommand.CommandType = CommandType.Text;
                sqLiteCommand.Parameters.Add(new SQLiteParameter("@name", textBox1.Text)); 
                ad = new SQLiteDataAdapter(sqLiteCommand);
                ad.Fill(dt);
            }
            catch (SQLiteException)
            {
                throw;
            }
            finally
            {
                myConnection.Close();
            }
            return dt;
        }

        private int NonQuery(String[] sqlCommands)
        {
            SQLiteConnection myConnection = GetConnection();
            myConnection.Open();
            SQLiteTransaction transaction = myConnection.BeginTransaction();

            var count = 0;
            try
            {
                SQLiteCommand sqLiteCommand = myConnection.CreateCommand();
                sqLiteCommand.Transaction = transaction;
                sqLiteCommand.CommandTimeout = 15;
                sqLiteCommand.CommandType = CommandType.Text;
                foreach (var sql in sqlCommands)
                {
                    sqLiteCommand.CommandText = sql;
                    count += sqLiteCommand.ExecuteNonQuery();
                }
                
                transaction.Commit();
            }
            catch (SQLiteException)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                myConnection.Close();
            }
            return count;
        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(@"Data Source = C:\Users\lnc\Documents\Visual Studio 2015\Projects\PhoneBook\PhoneBook.db");
        }

        private void test_Click(object sender, EventArgs e)
        {

        }
    }
}
        
