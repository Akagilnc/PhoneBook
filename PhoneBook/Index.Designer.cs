namespace PhoneBook
{
    partial class Index
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.querybutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addtestbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // querybutton
            // 
            this.querybutton.Location = new System.Drawing.Point(104, 161);
            this.querybutton.Name = "querybutton";
            this.querybutton.Size = new System.Drawing.Size(75, 23);
            this.querybutton.TabIndex = 0;
            this.querybutton.Text = "Query";
            this.querybutton.UseVisualStyleBackColor = true;
            this.querybutton.Click += new System.EventHandler(this.querybutton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // addtestbutton
            // 
            this.addtestbutton.Location = new System.Drawing.Point(104, 191);
            this.addtestbutton.Name = "addtestbutton";
            this.addtestbutton.Size = new System.Drawing.Size(75, 23);
            this.addtestbutton.TabIndex = 2;
            this.addtestbutton.Text = "Add test";
            this.addtestbutton.UseVisualStyleBackColor = true;
            this.addtestbutton.Click += new System.EventHandler(this.testaddbutton_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addtestbutton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.querybutton);
            this.Name = "Index";
            this.Text = "Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button querybutton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addtestbutton;
    }
}

