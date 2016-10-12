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
            SQLiteConnection myConnection = new SQLiteConnection(@"Data Source = C:\sqlite\PhoneBook.db");

            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand sqLiteCommand;
                myConnection.Open();
                sqLiteCommand = myConnection.CreateCommand();
                sqLiteCommand.CommandText = "select * from phonebook";
                sqLiteCommand.CommandTimeout = 15;
                sqLiteCommand.CommandType = CommandType.Text;
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
            Console.Write(dt.Rows);
            MessageBox.Show("Name:" + dt.Rows[0]["Name"] + "    PhoneNum:" + dt.Rows[0]["PhoneNum"]);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}
        
