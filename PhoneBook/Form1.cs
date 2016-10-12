using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //MessageBox.Show(Insert().ToString());

            
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable result = Insert();
            MessageBox.Show(result.ToString());
            for (int i = 0; i < result.Rows.Count; i++)
            {
                MessageBox.Show(result.Rows[i].ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
            String name = textBox1.Text;
        }

   

        private String GetInfo()
        {
            String sql = "select * from phonebook where name = '" + textBox1.Text + "'";
            

            DataTable result = DataConnection(sql);
            return "Name:" + result.Rows[0]["Name"] + "    PhoneNum:" + result.Rows[0]["PhoneNum"];
        }

        private DataTable Insert()
        {
            String sql_insert = "insert or replace into phonebook values(6, 'test4', 18000000000)";
            DataTable result = DataConnection(sql_insert);
            return result;
        }

        private DataTable DataConnection(String SqlCommand)
        {
            
            SQLiteConnection myConnection = new SQLiteConnection(@"Data Source = C:\Users\lnc\Documents\Visual Studio 2015\Projects\PhoneBook\PhoneBook.db");
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteTransaction transaction = myConnection.BeginTransaction();

            try
            {
                myConnection.Open();
                SQLiteCommand sqLiteCommand = myConnection.CreateCommand();
                sqLiteCommand.CommandText = SqlCommand;
                sqLiteCommand.CommandTimeout = 15;
                sqLiteCommand.CommandType = CommandType.Text;
                ad = new SQLiteDataAdapter(sqLiteCommand);
                ad.Fill(dt);
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
            return dt;
        }

    }
}
        
