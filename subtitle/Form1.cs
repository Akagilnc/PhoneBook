using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subtitle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeSubtitle makeSubtitle = new MakeSubtitle();

            Hashtable table = makeSubtitle.FileToString();
            Key key = new Key(makeSubtitle.ParserTime("00:00:05,607"));

            this.result.Text = makeSubtitle.GetValue(table, key); 
        }

        private void result_Click(object sender, EventArgs e)
        {

        }
    }
}
