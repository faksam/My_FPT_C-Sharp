namespace Lab3_Group1.GUI
{
    partial class ReserveGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbMemberID = new System.Windows.Forms.TextBox();
            this.tbBookID = new System.Windows.Forms.TextBox();
            this.tbMembername = new System.Windows.Forms.TextBox();
            this.buttonReserveCheckMember = new System.Windows.Forms.Button();
            this.buttonReserveCondition = new System.Windows.Forms.Button();
            this.btReserve = new System.Windows.Forms.Button();
            this.labelReserveBook = new System.Windows.Forms.Label();
            this.labelReserveMemberCode = new System.Windows.Forms.Label();
            this.labelReserveBookNumber = new System.Windows.Forms.Label();
            this.labelReserveName = new System.Windows.Forms.Label();
            this.labelReserveDate = new System.Windows.Forms.Label();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(61, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 244);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "The number of reserved books :";
            // 
            // tbMemberID
            // 
            this.tbMemberID.Location = new System.Drawing.Point(181, 42);
            this.tbMemberID.Name = "tbMemberID";
            this.tbMemberID.Size = new System.Drawing.Size(161, 20);
            this.tbMemberID.TabIndex = 2;
            // 
            // tbBookID
            // 
            this.tbBookID.Enabled = false;
            this.tbBookID.Location = new System.Drawing.Point(181, 68);
            this.tbBookID.Name = "tbBookID";
            this.tbBookID.Size = new System.Drawing.Size(161, 20);
            this.tbBookID.TabIndex = 3;
            // 
            // tbMembername
            // 
            this.tbMembername.Enabled = false;
            this.tbMembername.Location = new System.Drawing.Point(457, 42);
            this.tbMembername.Name = "tbMembername";
            this.tbMembername.Size = new System.Drawing.Size(153, 20);
            this.tbMembername.TabIndex = 4;
            // 
            // buttonReserveCheckMember
            // 
            this.buttonReserveCheckMember.Location = new System.Drawing.Point(674, 42);
            this.buttonReserveCheckMember.Name = "buttonReserveCheckMember";
            this.buttonReserveCheckMember.Size = new System.Drawing.Size(211, 23);
            this.buttonReserveCheckMember.TabIndex = 5;
            this.buttonReserveCheckMember.Text = "Check Member";
            this.buttonReserveCheckMember.UseVisualStyleBackColor = true;
            this.buttonReserveCheckMember.Click += new System.EventHandler(this.buttonReserveCheckMember_Click);
            // 
            // buttonReserveCondition
            // 
            this.buttonReserveCondition.Enabled = false;
            this.buttonReserveCondition.Location = new System.Drawing.Point(588, 71);
            this.buttonReserveCondition.Name = "buttonReserveCondition";
            this.buttonReserveCondition.Size = new System.Drawing.Size(297, 23);
            this.buttonReserveCondition.TabIndex = 6;
            this.buttonReserveCondition.Text = "Check reservation condition";
            this.buttonReserveCondition.UseVisualStyleBackColor = true;
            this.buttonReserveCondition.Click += new System.EventHandler(this.buttonReserveCondition_Click);
            // 
            // btReserve
            // 
            this.btReserve.Enabled = false;
            this.btReserve.Location = new System.Drawing.Point(747, 419);
            this.btReserve.Name = "btReserve";
            this.btReserve.Size = new System.Drawing.Size(75, 23);
            this.btReserve.TabIndex = 7;
            this.btReserve.Text = "Reserve";
            this.btReserve.UseVisualStyleBackColor = true;
            this.btReserve.Click += new System.EventHandler(this.btReserve_Click);
            // 
            // labelReserveBook
            // 
            this.labelReserveBook.AutoSize = true;
            this.labelReserveBook.Location = new System.Drawing.Point(242, 125);
            this.labelReserveBook.Name = "labelReserveBook";
            this.labelReserveBook.Size = new System.Drawing.Size(0, 13);
            this.labelReserveBook.TabIndex = 8;
            // 
            // labelReserveMemberCode
            // 
            this.labelReserveMemberCode.AutoSize = true;
            this.labelReserveMemberCode.Location = new System.Drawing.Point(96, 45);
            this.labelReserveMemberCode.Name = "labelReserveMemberCode";
            this.labelReserveMemberCode.Size = new System.Drawing.Size(79, 13);
            this.labelReserveMemberCode.TabIndex = 9;
            this.labelReserveMemberCode.Text = "Member Code :";
            // 
            // labelReserveBookNumber
            // 
            this.labelReserveBookNumber.AutoSize = true;
            this.labelReserveBookNumber.Location = new System.Drawing.Point(97, 71);
            this.labelReserveBookNumber.Name = "labelReserveBookNumber";
            this.labelReserveBookNumber.Size = new System.Drawing.Size(78, 13);
            this.labelReserveBookNumber.TabIndex = 10;
            this.labelReserveBookNumber.Text = "Book Number :";
            // 
            // labelReserveName
            // 
            this.labelReserveName.AutoSize = true;
            this.labelReserveName.Location = new System.Drawing.Point(399, 45);
            this.labelReserveName.Name = "labelReserveName";
            this.labelReserveName.Size = new System.Drawing.Size(41, 13);
            this.labelReserveName.TabIndex = 11;
            this.labelReserveName.Text = "Name :";
            // 
            // labelReserveDate
            // 
            this.labelReserveDate.AutoSize = true;
            this.labelReserveDate.Location = new System.Drawing.Point(479, 429);
            this.labelReserveDate.Name = "labelReserveDate";
            this.labelReserveDate.Size = new System.Drawing.Size(36, 13);
            this.labelReserveDate.TabIndex = 12;
            this.labelReserveDate.Text = "Date :";
            // 
            // tbDate
            // 
            this.tbDate.Enabled = false;
            this.tbDate.Location = new System.Drawing.Point(556, 422);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(100, 20);
            this.tbDate.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "0";
            // 
            // ReserveGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(907, 478);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.labelReserveDate);
            this.Controls.Add(this.labelReserveName);
            this.Controls.Add(this.labelReserveBookNumber);
            this.Controls.Add(this.labelReserveMemberCode);
            this.Controls.Add(this.labelReserveBook);
            this.Controls.Add(this.btReserve);
            this.Controls.Add(this.buttonReserveCondition);
            this.Controls.Add(this.buttonReserveCheckMember);
            this.Controls.Add(this.tbMembername);
            this.Controls.Add(this.tbBookID);
            this.Controls.Add(this.tbMemberID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReserveGUI";
            this.Text = "ReserveGUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMemberID;
        private System.Windows.Forms.TextBox tbBookID;
        private System.Windows.Forms.TextBox tbMembername;
        private System.Windows.Forms.Button buttonReserveCheckMember;
        private System.Windows.Forms.Button buttonReserveCondition;
        private System.Windows.Forms.Button btReserve;
        private System.Windows.Forms.Label labelReserveBook;
        private System.Windows.Forms.Label labelReserveMemberCode;
        private System.Windows.Forms.Label labelReserveBookNumber;
        private System.Windows.Forms.Label labelReserveName;
        private System.Windows.Forms.Label labelReserveDate;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label label2;
    }
}