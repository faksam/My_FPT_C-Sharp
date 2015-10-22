namespace Lab3_Group1.GUI
{
    partial class BorrowerGUI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelMemberCode = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSex = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtMemberCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.buttonMFilter = new System.Windows.Forms.Button();
            this.buttonMAdd = new System.Windows.Forms.Button();
            this.buttonMEdit = new System.Windows.Forms.Button();
            this.buttonMDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(266, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 347);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // labelMemberCode
            // 
            this.labelMemberCode.AutoSize = true;
            this.labelMemberCode.Location = new System.Drawing.Point(19, 37);
            this.labelMemberCode.Name = "labelMemberCode";
            this.labelMemberCode.Size = new System.Drawing.Size(79, 13);
            this.labelMemberCode.TabIndex = 1;
            this.labelMemberCode.Text = "Member Code :";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(57, 63);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name :";
            // 
            // labelSex
            // 
            this.labelSex.AutoSize = true;
            this.labelSex.Location = new System.Drawing.Point(67, 89);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(31, 13);
            this.labelSex.TabIndex = 3;
            this.labelSex.Text = "Sex :";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(47, 115);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(51, 13);
            this.labelAddress.TabIndex = 4;
            this.labelAddress.Text = "Address :";
            // 
            // labelTelephone
            // 
            this.labelTelephone.AutoSize = true;
            this.labelTelephone.Location = new System.Drawing.Point(34, 141);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(64, 13);
            this.labelTelephone.TabIndex = 5;
            this.labelTelephone.Text = "Telephone :";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(60, 167);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 13);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email :";
            // 
            // txtMemberCode
            // 
            this.txtMemberCode.Location = new System.Drawing.Point(104, 34);
            this.txtMemberCode.Name = "txtMemberCode";
            this.txtMemberCode.Size = new System.Drawing.Size(138, 20);
            this.txtMemberCode.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(104, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(138, 20);
            this.txtName.TabIndex = 8;
            // 
            // txtSex
            // 
            this.txtSex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSex.Enabled = false;
            this.txtSex.Location = new System.Drawing.Point(104, 86);
            this.txtSex.MaxLength = 1;
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(138, 20);
            this.txtSex.TabIndex = 9;
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(104, 112);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(138, 20);
            this.txtAddress.TabIndex = 10;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Enabled = false;
            this.txtTelephone.Location = new System.Drawing.Point(104, 138);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(138, 20);
            this.txtTelephone.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(104, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(138, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // buttonMFilter
            // 
            this.buttonMFilter.Location = new System.Drawing.Point(167, 211);
            this.buttonMFilter.Name = "buttonMFilter";
            this.buttonMFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonMFilter.TabIndex = 13;
            this.buttonMFilter.Text = "Filter";
            this.buttonMFilter.UseVisualStyleBackColor = true;
            this.buttonMFilter.Click += new System.EventHandler(this.buttonMFilter_Click);
            // 
            // buttonMAdd
            // 
            this.buttonMAdd.Location = new System.Drawing.Point(401, 416);
            this.buttonMAdd.Name = "buttonMAdd";
            this.buttonMAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonMAdd.TabIndex = 14;
            this.buttonMAdd.Text = "Add";
            this.buttonMAdd.UseVisualStyleBackColor = true;
            this.buttonMAdd.Click += new System.EventHandler(this.buttonMAdd_Click);
            // 
            // buttonMEdit
            // 
            this.buttonMEdit.Location = new System.Drawing.Point(539, 416);
            this.buttonMEdit.Name = "buttonMEdit";
            this.buttonMEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonMEdit.TabIndex = 15;
            this.buttonMEdit.Text = "Edit";
            this.buttonMEdit.UseVisualStyleBackColor = true;
            this.buttonMEdit.Click += new System.EventHandler(this.buttonMEdit_Click);
            // 
            // buttonMDelete
            // 
            this.buttonMDelete.Location = new System.Drawing.Point(678, 416);
            this.buttonMDelete.Name = "buttonMDelete";
            this.buttonMDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonMDelete.TabIndex = 16;
            this.buttonMDelete.Text = "Delete";
            this.buttonMDelete.UseVisualStyleBackColor = true;
            this.buttonMDelete.Click += new System.EventHandler(this.buttonMDelete_Click);
            // 
            // BorrowerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(938, 478);
            this.Controls.Add(this.buttonMDelete);
            this.Controls.Add(this.buttonMEdit);
            this.Controls.Add(this.buttonMAdd);
            this.Controls.Add(this.buttonMFilter);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMemberCode);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelTelephone);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelSex);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelMemberCode);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BorrowerGUI";
            this.Text = "Members";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelMemberCode;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtMemberCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button buttonMFilter;
        private System.Windows.Forms.Button buttonMAdd;
        private System.Windows.Forms.Button buttonMEdit;
        private System.Windows.Forms.Button buttonMDelete;

    }
}