namespace Lab3_Group1.GUI
{
    partial class BorrowGUI
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
            this.dgvBorrowed = new System.Windows.Forms.DataGridView();
            this.btCheckBorrowCondition = new System.Windows.Forms.Button();
            this.btBorrow = new System.Windows.Forms.Button();
            this.btCheckMember = new System.Windows.Forms.Button();
            this.tbMemberCode = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCopyNumber = new System.Windows.Forms.TextBox();
            this.tbBorrowedDate = new System.Windows.Forms.TextBox();
            this.tbDueDate = new System.Windows.Forms.TextBox();
            this.labelBorrowMemberCode = new System.Windows.Forms.Label();
            this.labelBorrowName = new System.Windows.Forms.Label();
            this.labelBorrowCopyNumber = new System.Windows.Forms.Label();
            this.labelBorrowBorrowedDate = new System.Windows.Forms.Label();
            this.labelBorrowDueDate = new System.Windows.Forms.Label();
            this.lbNumberOfBorrowedBook = new System.Windows.Forms.Label();
            this.labelBorrowBorrowedBook = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowed)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBorrowed
            // 
            this.dgvBorrowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowed.Location = new System.Drawing.Point(337, 71);
            this.dgvBorrowed.Name = "dgvBorrowed";
            this.dgvBorrowed.Size = new System.Drawing.Size(566, 261);
            this.dgvBorrowed.TabIndex = 0;
            // 
            // btCheckBorrowCondition
            // 
            this.btCheckBorrowCondition.Enabled = false;
            this.btCheckBorrowCondition.Location = new System.Drawing.Point(371, 350);
            this.btCheckBorrowCondition.Name = "btCheckBorrowCondition";
            this.btCheckBorrowCondition.Size = new System.Drawing.Size(157, 23);
            this.btCheckBorrowCondition.TabIndex = 1;
            this.btCheckBorrowCondition.Text = "Check Borrow Condition";
            this.btCheckBorrowCondition.UseVisualStyleBackColor = true;
            this.btCheckBorrowCondition.Click += new System.EventHandler(this.btCheckBorrowCondition_Click);
            // 
            // btBorrow
            // 
            this.btBorrow.Enabled = false;
            this.btBorrow.Location = new System.Drawing.Point(371, 416);
            this.btBorrow.Name = "btBorrow";
            this.btBorrow.Size = new System.Drawing.Size(157, 23);
            this.btBorrow.TabIndex = 2;
            this.btBorrow.Text = "Borrow";
            this.btBorrow.UseVisualStyleBackColor = true;
            this.btBorrow.Click += new System.EventHandler(this.btBorrow_Click);
            // 
            // btCheckMember
            // 
            this.btCheckMember.Location = new System.Drawing.Point(131, 183);
            this.btCheckMember.Name = "btCheckMember";
            this.btCheckMember.Size = new System.Drawing.Size(181, 23);
            this.btCheckMember.TabIndex = 3;
            this.btCheckMember.Text = "Check Member";
            this.btCheckMember.UseVisualStyleBackColor = true;
            this.btCheckMember.Click += new System.EventHandler(this.btCheckMember_Click);
            // 
            // tbMemberCode
            // 
            this.tbMemberCode.Location = new System.Drawing.Point(134, 45);
            this.tbMemberCode.Name = "tbMemberCode";
            this.tbMemberCode.Size = new System.Drawing.Size(181, 20);
            this.tbMemberCode.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(134, 71);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(181, 20);
            this.tbName.TabIndex = 5;
            // 
            // tbCopyNumber
            // 
            this.tbCopyNumber.Enabled = false;
            this.tbCopyNumber.Location = new System.Drawing.Point(131, 352);
            this.tbCopyNumber.Name = "tbCopyNumber";
            this.tbCopyNumber.Size = new System.Drawing.Size(181, 20);
            this.tbCopyNumber.TabIndex = 6;
            // 
            // tbBorrowedDate
            // 
            this.tbBorrowedDate.Enabled = false;
            this.tbBorrowedDate.Location = new System.Drawing.Point(131, 404);
            this.tbBorrowedDate.Name = "tbBorrowedDate";
            this.tbBorrowedDate.Size = new System.Drawing.Size(181, 20);
            this.tbBorrowedDate.TabIndex = 7;
            // 
            // tbDueDate
            // 
            this.tbDueDate.Enabled = false;
            this.tbDueDate.Location = new System.Drawing.Point(131, 430);
            this.tbDueDate.Name = "tbDueDate";
            this.tbDueDate.Size = new System.Drawing.Size(181, 20);
            this.tbDueDate.TabIndex = 8;
            // 
            // labelBorrowMemberCode
            // 
            this.labelBorrowMemberCode.AutoSize = true;
            this.labelBorrowMemberCode.Location = new System.Drawing.Point(49, 48);
            this.labelBorrowMemberCode.Name = "labelBorrowMemberCode";
            this.labelBorrowMemberCode.Size = new System.Drawing.Size(79, 13);
            this.labelBorrowMemberCode.TabIndex = 9;
            this.labelBorrowMemberCode.Text = "Member Code: ";
            // 
            // labelBorrowName
            // 
            this.labelBorrowName.AutoSize = true;
            this.labelBorrowName.Location = new System.Drawing.Point(87, 74);
            this.labelBorrowName.Name = "labelBorrowName";
            this.labelBorrowName.Size = new System.Drawing.Size(41, 13);
            this.labelBorrowName.TabIndex = 10;
            this.labelBorrowName.Text = "Name :";
            // 
            // labelBorrowCopyNumber
            // 
            this.labelBorrowCopyNumber.AutoSize = true;
            this.labelBorrowCopyNumber.Location = new System.Drawing.Point(48, 355);
            this.labelBorrowCopyNumber.Name = "labelBorrowCopyNumber";
            this.labelBorrowCopyNumber.Size = new System.Drawing.Size(77, 13);
            this.labelBorrowCopyNumber.TabIndex = 11;
            this.labelBorrowCopyNumber.Text = "Copy Number :";
            // 
            // labelBorrowBorrowedDate
            // 
            this.labelBorrowBorrowedDate.AutoSize = true;
            this.labelBorrowBorrowedDate.Location = new System.Drawing.Point(41, 407);
            this.labelBorrowBorrowedDate.Name = "labelBorrowBorrowedDate";
            this.labelBorrowBorrowedDate.Size = new System.Drawing.Size(84, 13);
            this.labelBorrowBorrowedDate.TabIndex = 12;
            this.labelBorrowBorrowedDate.Text = "Borrowed Date :";
            // 
            // labelBorrowDueDate
            // 
            this.labelBorrowDueDate.AutoSize = true;
            this.labelBorrowDueDate.Location = new System.Drawing.Point(66, 433);
            this.labelBorrowDueDate.Name = "labelBorrowDueDate";
            this.labelBorrowDueDate.Size = new System.Drawing.Size(59, 13);
            this.labelBorrowDueDate.TabIndex = 13;
            this.labelBorrowDueDate.Text = "Due Date :";
            // 
            // lbNumberOfBorrowedBook
            // 
            this.lbNumberOfBorrowedBook.AutoSize = true;
            this.lbNumberOfBorrowedBook.Location = new System.Drawing.Point(493, 45);
            this.lbNumberOfBorrowedBook.Name = "lbNumberOfBorrowedBook";
            this.lbNumberOfBorrowedBook.Size = new System.Drawing.Size(164, 13);
            this.lbNumberOfBorrowedBook.TabIndex = 14;
            this.lbNumberOfBorrowedBook.Text = "The number of borrowed books : ";
            // 
            // labelBorrowBorrowedBook
            // 
            this.labelBorrowBorrowedBook.AutoSize = true;
            this.labelBorrowBorrowedBook.Location = new System.Drawing.Point(688, 45);
            this.labelBorrowBorrowedBook.Name = "labelBorrowBorrowedBook";
            this.labelBorrowBorrowedBook.Size = new System.Drawing.Size(13, 13);
            this.labelBorrowBorrowedBook.TabIndex = 15;
            this.labelBorrowBorrowedBook.Text = "0";
            // 
            // BorrowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(929, 478);
            this.Controls.Add(this.labelBorrowBorrowedBook);
            this.Controls.Add(this.lbNumberOfBorrowedBook);
            this.Controls.Add(this.labelBorrowDueDate);
            this.Controls.Add(this.labelBorrowBorrowedDate);
            this.Controls.Add(this.labelBorrowCopyNumber);
            this.Controls.Add(this.labelBorrowName);
            this.Controls.Add(this.labelBorrowMemberCode);
            this.Controls.Add(this.tbDueDate);
            this.Controls.Add(this.tbBorrowedDate);
            this.Controls.Add(this.tbCopyNumber);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbMemberCode);
            this.Controls.Add(this.btCheckMember);
            this.Controls.Add(this.btBorrow);
            this.Controls.Add(this.btCheckBorrowCondition);
            this.Controls.Add(this.dgvBorrowed);
            this.Name = "BorrowGUI";
            this.Text = "Borrow copies";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBorrowed;
        private System.Windows.Forms.Button btCheckBorrowCondition;
        private System.Windows.Forms.Button btBorrow;
        private System.Windows.Forms.Button btCheckMember;
        private System.Windows.Forms.TextBox tbMemberCode;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCopyNumber;
        private System.Windows.Forms.TextBox tbBorrowedDate;
        private System.Windows.Forms.TextBox tbDueDate;
        private System.Windows.Forms.Label labelBorrowMemberCode;
        private System.Windows.Forms.Label labelBorrowName;
        private System.Windows.Forms.Label labelBorrowCopyNumber;
        private System.Windows.Forms.Label labelBorrowBorrowedDate;
        private System.Windows.Forms.Label labelBorrowDueDate;
        private System.Windows.Forms.Label lbNumberOfBorrowedBook;
        private System.Windows.Forms.Label labelBorrowBorrowedBook;
    }
}