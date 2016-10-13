using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace PhoneBook
{
    public partial class Index : Form
    {
        private InfoManage infoManage;
        public Index()
        {
            InitializeComponent();
            infoManage = new InfoManage();
        }

        public void querybutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(infoManage.GetInfo(textBox1.Text));
        }

        public void testaddbutton_Click(object sender, EventArgs e)
        {
            var result = infoManage.Insert();
            MessageBox.Show(result + @" was successful");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
            var name = textBox1.Text;
        }


        

    }
}