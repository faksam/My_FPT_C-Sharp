using System;
namespace Lab3_Group1.GUI
{
    partial class ReturnGUI
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
            this.txtMemCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtReturnedDate = new System.Windows.Forms.TextBox();
            this.txtFineAmount = new System.Windows.Forms.TextBox();
            this.lableReserveMemberCode = new System.Windows.Forms.Label();
            this.labelReserveName = new System.Windows.Forms.Label();
            this.labelReserveReturnedDate = new System.Windows.Forms.Label();
            this.labelFineAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelBorrowedBookNumber = new System.Windows.Forms.Label();
            this.buttonConfirmFine = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.btChkMember = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(749, 218);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtMemCode
            // 
            this.txtMemCode.Location = new System.Drawing.Point(241, 36);
            this.txtMemCode.Name = "txtMemCode";
            this.txtMemCode.Size = new System.Drawing.Size(178, 20);
            this.txtMemCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(241, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtReturnedDate
            // 
            this.txtReturnedDate.Enabled = false;
            this.txtReturnedDate.Location = new System.Drawing.Point(241, 393);
            this.txtReturnedDate.Name = "txtReturnedDate";
            this.txtReturnedDate.Size = new System.Drawing.Size(178, 20);
            this.txtReturnedDate.TabIndex = 3;
            this.txtReturnedDate.Text = "18-10-2013";
            // 
            // txtFineAmount
            // 
            this.txtFineAmount.Enabled = false;
            this.txtFineAmount.Location = new System.Drawing.Point(712, 393);
            this.txtFineAmount.Name = "txtFineAmount";
            this.txtFineAmount.Size = new System.Drawing.Size(96, 20);
            this.txtFineAmount.TabIndex = 4;
            // 
            // lableReserveMemberCode
            // 
            this.lableReserveMemberCode.AutoSize = true;
            this.lableReserveMemberCode.Location = new System.Drawing.Point(128, 39);
            this.lableReserveMemberCode.Name = "lableReserveMemberCode";
            this.lableReserveMemberCode.Size = new System.Drawing.Size(79, 13);
            this.lableReserveMemberCode.TabIndex = 5;
            this.lableReserveMemberCode.Text = "Member Code :";
            // 
            // labelReserveName
            // 
            this.labelReserveName.AutoSize = true;
            this.labelReserveName.Location = new System.Drawing.Point(166, 65);
            this.labelReserveName.Name = "labelReserveName";
            this.labelReserveName.Size = new System.Drawing.Size(41, 13);
            this.labelReserveName.TabIndex = 6;
            this.labelReserveName.Text = "Name :";
            // 
            // labelReserveReturnedDate
            // 
            this.labelReserveReturnedDate.AutoSize = true;
            this.labelReserveReturnedDate.Location = new System.Drawing.Point(128, 396);
            this.labelReserveReturnedDate.Name = "labelReserveReturnedDate";
            this.labelReserveReturnedDate.Size = new System.Drawing.Size(83, 13);
            this.labelReserveReturnedDate.TabIndex = 7;
            this.labelReserveReturnedDate.Text = "Returned Date :";
            // 
            // labelFineAmount
            // 
            this.labelFineAmount.AutoSize = true;
            this.labelFineAmount.Location = new System.Drawing.Point(634, 396);
            this.labelFineAmount.Name = "labelFineAmount";
            this.labelFineAmount.Size = new System.Drawing.Size(72, 13);
            this.labelFineAmount.TabIndex = 8;
            this.labelFineAmount.Text = "Fine Amount :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "The number of borrowed books : ";
            // 
            // labelBorrowedBookNumber
            // 
            this.labelBorrowedBookNumber.AutoSize = true;
            this.labelBorrowedBookNumber.Location = new System.Drawing.Point(241, 109);
            this.labelBorrowedBookNumber.Name = "labelBorrowedBookNumber";
            this.labelBorrowedBookNumber.Size = new System.Drawing.Size(13, 13);
            this.labelBorrowedBookNumber.TabIndex = 10;
            this.labelBorrowedBookNumber.Text = "0";
            // 
            // buttonConfirmFine
            // 
            this.buttonConfirmFine.Enabled = false;
            this.buttonConfirmFine.Location = new System.Drawing.Point(131, 432);
            this.buttonConfirmFine.Name = "buttonConfirmFine";
            this.buttonConfirmFine.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmFine.TabIndex = 11;
            this.buttonConfirmFine.Text = "Confirm Fine";
            this.buttonConfirmFine.UseVisualStyleBackColor = true;
            this.buttonConfirmFine.Click += new System.EventHandler(this.buttonConfirmFine_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Enabled = false;
            this.buttonReturn.Location = new System.Drawing.Point(241, 432);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 23);
            this.buttonReturn.TabIndex = 12;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            // 
            // btChkMember
            // 
            this.btChkMember.Location = new System.Drawing.Point(549, 32);
            this.btChkMember.Name = "btChkMember";
            this.btChkMember.Size = new System.Drawing.Size(134, 23);
            this.btChkMember.TabIndex = 13;
            this.btChkMember.Text = "Check Member";
            this.btChkMember.UseVisualStyleBackColor = true;
            this.btChkMember.Click += new System.EventHandler(this.btChkMember_Click);
            // 
            // ReturnGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(833, 478);
            this.Controls.Add(this.btChkMember);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonConfirmFine);
            this.Controls.Add(this.labelBorrowedBookNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelFineAmount);
            this.Controls.Add(this.labelReserveReturnedDate);
            this.Controls.Add(this.labelReserveName);
            this.Controls.Add(this.lableReserveMemberCode);
            this.Controls.Add(this.txtFineAmount);
            this.Controls.Add(this.txtReturnedDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtMemCode);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReturnGUI";
            this.Text = "Reserve a book";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMemCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtReturnedDate;
        private System.Windows.Forms.TextBox txtFineAmount;
        private System.Windows.Forms.Label lableReserveMemberCode;
        private System.Windows.Forms.Label labelReserveName;
        private System.Windows.Forms.Label labelReserveReturnedDate;
        private System.Windows.Forms.Label labelFineAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelBorrowedBookNumber;
        private System.Windows.Forms.Button buttonConfirmFine;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button btChkMember;

        public System.Windows.Forms.DataGridViewCellEventHandler dataGridView1_CellContentClick { get; set; }
    }
}