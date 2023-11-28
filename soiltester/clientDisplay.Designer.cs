namespace soiltester
{
    partial class clientDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clientName = new System.Windows.Forms.Label();
            this.clientNo = new System.Windows.Forms.Label();
            this.clientAdd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 118);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // clientName
            // 
            this.clientName.AutoSize = true;
            this.clientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientName.Location = new System.Drawing.Point(201, 21);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(179, 25);
            this.clientName.TabIndex = 1;
            this.clientName.Text = "Maqeta Makeka";
            // 
            // clientNo
            // 
            this.clientNo.AutoSize = true;
            this.clientNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clientNo.Location = new System.Drawing.Point(203, 58);
            this.clientNo.Name = "clientNo";
            this.clientNo.Size = new System.Drawing.Size(121, 20);
            this.clientNo.TabIndex = 2;
            this.clientNo.Text = "+266 59999999";
            // 
            // clientAdd
            // 
            this.clientAdd.AutoSize = true;
            this.clientAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clientAdd.Location = new System.Drawing.Point(203, 91);
            this.clientAdd.Name = "clientAdd";
            this.clientAdd.Size = new System.Drawing.Size(182, 20);
            this.clientAdd.TabIndex = 3;
            this.clientAdd.Text = "Lithabaneng, Box 11920";
            // 
            // clientDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.clientAdd);
            this.Controls.Add(this.clientNo);
            this.Controls.Add(this.clientName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "clientDisplay";
            this.Size = new System.Drawing.Size(753, 148);
            this.Load += new System.EventHandler(this.clientDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label clientName;
        private System.Windows.Forms.Label clientNo;
        private System.Windows.Forms.Label clientAdd;
    }
}
