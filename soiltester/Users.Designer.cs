namespace soiltester
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CreateBut = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.cell1 = new System.Windows.Forms.TextBox();
            this.cell2 = new System.Windows.Forms.TextBox();
            this.cell3 = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cell2butt = new System.Windows.Forms.Button();
            this.cell3butt = new System.Windows.Forms.Button();
            this.DataT = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.DataT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 62);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(113, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(26, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(26, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cell:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(26, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Surname:";
            // 
            // CreateBut
            // 
            this.CreateBut.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CreateBut.FlatAppearance.BorderSize = 0;
            this.CreateBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBut.ForeColor = System.Drawing.SystemColors.Window;
            this.CreateBut.Location = new System.Drawing.Point(30, 414);
            this.CreateBut.Name = "CreateBut";
            this.CreateBut.Size = new System.Drawing.Size(186, 42);
            this.CreateBut.TabIndex = 6;
            this.CreateBut.Text = "CREATE";
            this.CreateBut.UseVisualStyleBackColor = false;
            this.CreateBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(121, 86);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(276, 26);
            this.name.TabIndex = 7;
            // 
            // surname
            // 
            this.surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surname.Location = new System.Drawing.Point(121, 130);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(276, 26);
            this.surname.TabIndex = 8;
            // 
            // cell1
            // 
            this.cell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cell1.Location = new System.Drawing.Point(121, 181);
            this.cell1.Name = "cell1";
            this.cell1.Size = new System.Drawing.Size(276, 26);
            this.cell1.TabIndex = 9;
            // 
            // cell2
            // 
            this.cell2.Enabled = false;
            this.cell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cell2.Location = new System.Drawing.Point(121, 213);
            this.cell2.Name = "cell2";
            this.cell2.Size = new System.Drawing.Size(276, 26);
            this.cell2.TabIndex = 10;
            // 
            // cell3
            // 
            this.cell3.Enabled = false;
            this.cell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cell3.Location = new System.Drawing.Point(121, 245);
            this.cell3.Name = "cell3";
            this.cell3.Size = new System.Drawing.Size(276, 26);
            this.cell3.TabIndex = 11;
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(121, 295);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(276, 79);
            this.address.TabIndex = 13;
            this.address.Text = "";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Firebrick;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(259, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 42);
            this.button2.TabIndex = 14;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // cell2butt
            // 
            this.cell2butt.FlatAppearance.BorderSize = 0;
            this.cell2butt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell2butt.Image = ((System.Drawing.Image)(resources.GetObject("cell2butt.Image")));
            this.cell2butt.Location = new System.Drawing.Point(406, 212);
            this.cell2butt.Name = "cell2butt";
            this.cell2butt.Size = new System.Drawing.Size(41, 30);
            this.cell2butt.TabIndex = 15;
            this.cell2butt.UseVisualStyleBackColor = true;
            this.cell2butt.Click += new System.EventHandler(this.button3_Click);
            // 
            // cell3butt
            // 
            this.cell3butt.FlatAppearance.BorderSize = 0;
            this.cell3butt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell3butt.Image = ((System.Drawing.Image)(resources.GetObject("cell3butt.Image")));
            this.cell3butt.Location = new System.Drawing.Point(406, 243);
            this.cell3butt.Name = "cell3butt";
            this.cell3butt.Size = new System.Drawing.Size(41, 30);
            this.cell3butt.TabIndex = 16;
            this.cell3butt.UseVisualStyleBackColor = true;
            this.cell3butt.Click += new System.EventHandler(this.cell3butt_Click);
            // 
            // DataT
            // 
            this.DataT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataT.Location = new System.Drawing.Point(4, 4);
            this.DataT.Name = "DataT";
            this.DataT.Size = new System.Drawing.Size(31, 55);
            this.DataT.TabIndex = 1;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 487);
            this.Controls.Add(this.cell3butt);
            this.Controls.Add(this.cell2butt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.address);
            this.Controls.Add(this.cell3);
            this.Controls.Add(this.cell2);
            this.Controls.Add(this.cell1);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.name);
            this.Controls.Add(this.CreateBut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CreateBut;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox cell1;
        private System.Windows.Forms.TextBox cell2;
        private System.Windows.Forms.TextBox cell3;
        private System.Windows.Forms.RichTextBox address;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cell2butt;
        private System.Windows.Forms.Button cell3butt;
        private System.Windows.Forms.DataGridView DataT;
    }
}