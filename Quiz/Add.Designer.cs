namespace MyFacebook_LaxamanaJ.Quiz
{
    partial class Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDC = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Number";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(121, 13);
            this.txtNum.MaxLength = 8;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 1;
            // 
            // txtLN
            // 
            this.txtLN.Location = new System.Drawing.Point(121, 39);
            this.txtLN.MaxLength = 50;
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(100, 20);
            this.txtLN.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name";
            // 
            // txtFN
            // 
            this.txtFN.Location = new System.Drawing.Point(121, 65);
            this.txtFN.MaxLength = 80;
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(100, 20);
            this.txtFN.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "First Name";
            // 
            // txtDep
            // 
            this.txtDep.Location = new System.Drawing.Point(121, 91);
            this.txtDep.MaxLength = 50;
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(100, 20);
            this.txtDep.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Department";
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(121, 117);
            this.txtCell.MaxLength = 12;
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(100, 20);
            this.txtCell.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mobile Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Date Created";
            // 
            // dtpDC
            // 
            this.dtpDC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDC.Location = new System.Drawing.Point(121, 144);
            this.dtpDC.Name = "dtpDC";
            this.dtpDC.Size = new System.Drawing.Size(100, 20);
            this.dtpDC.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(121, 171);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 207);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpDC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCell);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.label1);
            this.Name = "Add";
            this.Text = "Add an Employee";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDC;
        private System.Windows.Forms.Button btnAdd;
    }
}