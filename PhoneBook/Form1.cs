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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetInfo());
        }

        private void button2_Click(object sender, EventArgs e)
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
            return "Name:" + result.Rows[0]["Name"] + "    PhoneNum:" + result.Rows[0]["PhoneNum"];
        }

        private int Insert()
        {
            String[] sqls;
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
            
            SQLiteTransaction transaction = myConnection.BeginTransaction();
            var count = 0;
            try
            {
                myConnection.Open();
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
    }
}
        
