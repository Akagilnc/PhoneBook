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
            
            
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Moji";
            label1.ForeColor = System.Drawing.Color.BlueViolet;

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.DarkRed;
            toolTip1.ForeColor = System.Drawing.Color.Blue;
            toolTip1.SetToolTip(label1, "Moji means character");

        }
        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {       
        }

        
    }
}