namespace GUI
{
    partial class Form_QuestionManagement
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtAnswerA = new System.Windows.Forms.TextBox();
            this.txtAnswerB = new System.Windows.Forms.TextBox();
            this.txtAnswerC = new System.Windows.Forms.TextBox();
            this.txtAnswerD = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.bt_Add = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ckbAnswerA = new System.Windows.Forms.CheckBox();
            this.ckbAnswerB = new System.Windows.Forms.CheckBox();
            this.ckbAnswerC = new System.Windows.Forms.CheckBox();
            this.ckbAnswerD = new System.Windows.Forms.CheckBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.lbQuestion = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.ckbAnswerE = new System.Windows.Forms.CheckBox();
            this.txtAnswerE = new System.Windows.Forms.TextBox();
            this.ckbAnswerF = new System.Windows.Forms.CheckBox();
            this.txtAnswerF = new System.Windows.Forms.TextBox();
            this.btUpdate = new System.Windows.Forms.Button();
            this.cbbTopic = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btClearImage = new System.Windows.Forms.Button();
            this.btShowTopic = new System.Windows.Forms.Button();
            this.btShowAll = new System.Windows.Forms.Button();
            this.errmes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(420, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question Detail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mark";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Question";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(321, 124);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(500, 82);
            this.txtQuestion.TabIndex = 3;
            this.txtQuestion.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtAnswerA
            // 
            this.txtAnswerA.Location = new System.Drawing.Point(321, 217);
            this.txtAnswerA.Multiline = true;
            this.txtAnswerA.Name = "txtAnswerA";
            this.txtAnswerA.Size = new System.Drawing.Size(500, 20);
            this.txtAnswerA.TabIndex = 4;
            this.txtAnswerA.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtAnswerB
            // 
            this.txtAnswerB.Location = new System.Drawing.Point(321, 247);
            this.txtAnswerB.Multiline = true;
            this.txtAnswerB.Name = "txtAnswerB";
            this.txtAnswerB.Size = new System.Drawing.Size(500, 20);
            this.txtAnswerB.TabIndex = 5;
            this.txtAnswerB.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtAnswerC
            // 
            this.txtAnswerC.Location = new System.Drawing.Point(321, 276);
            this.txtAnswerC.Multiline = true;
            this.txtAnswerC.Name = "txtAnswerC";
            this.txtAnswerC.Size = new System.Drawing.Size(500, 20);
            this.txtAnswerC.TabIndex = 6;
            this.txtAnswerC.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtAnswerD
            // 
            this.txtAnswerD.Location = new System.Drawing.Point(321, 304);
            this.txtAnswerD.Multiline = true;
            this.txtAnswerD.Name = "txtAnswerD";
            this.txtAnswerD.Size = new System.Drawing.Size(500, 20);
            this.txtAnswerD.TabIndex = 7;
            this.txtAnswerD.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(321, 90);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(67, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(456, 90);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(59, 20);
            this.txtMark.TabIndex = 1;
            this.txtMark.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // bt_Add
            // 
            this.bt_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Add.Location = new System.Drawing.Point(321, 430);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(94, 29);
            this.bt_Add.TabIndex = 8;
            this.bt_Add.Text = "Add";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // btClose
            // 
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(1038, 430);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(94, 29);
            this.btClose.TabIndex = 13;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(281, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Topic";
            // 
            // ckbAnswerA
            // 
            this.ckbAnswerA.AutoSize = true;
            this.ckbAnswerA.Location = new System.Drawing.Point(280, 220);
            this.ckbAnswerA.Name = "ckbAnswerA";
            this.ckbAnswerA.Size = new System.Drawing.Size(33, 17);
            this.ckbAnswerA.TabIndex = 8;
            this.ckbAnswerA.Text = "A";
            this.ckbAnswerA.UseVisualStyleBackColor = true;
            this.ckbAnswerA.CheckedChanged += new System.EventHandler(this.TextChanged);
            // 
            // ckbAnswerB
            // 
            this.ckbAnswerB.AutoSize = true;
            this.ckbAnswerB.Location = new System.Drawing.Point(280, 250);
            this.ckbAnswerB.Name = "ckbAnswerB";
            this.ckbAnswerB.Size = new System.Drawing.Size(33, 17);
            this.ckbAnswerB.TabIndex = 9;
            this.ckbAnswerB.Text = "B";
            this.ckbAnswerB.UseVisualStyleBackColor = true;
            this.ckbAnswerB.CheckedChanged += new System.EventHandler(this.TextChanged);
            // 
            // ckbAnswerC
            // 
            this.ckbAnswerC.AutoSize = true;
            this.ckbAnswerC.Location = new System.Drawing.Point(280, 279);
            this.ckbAnswerC.Name = "ckbAnswerC";
            this.ckbAnswerC.Size = new System.Drawing.Size(33, 17);
            this.ckbAnswerC.TabIndex = 10;
            this.ckbAnswerC.Text = "C";
            this.ckbAnswerC.UseVisualStyleBackColor = true;
            this.ckbAnswerC.CheckedChanged += new System.EventHandler(this.TextChanged);
            // 
            // ckbAnswerD
            // 
            this.ckbAnswerD.AutoSize = true;
            this.ckbAnswerD.Location = new System.Drawing.Point(279, 307);
            this.ckbAnswerD.Name = "ckbAnswerD";
            this.ckbAnswerD.Size = new System.Drawing.Size(34, 17);
            this.ckbAnswerD.TabIndex = 11;
            this.ckbAnswerD.Text = "D";
            this.ckbAnswerD.UseVisualStyleBackColor = true;
            this.ckbAnswerD.CheckedChanged += new System.EventHandler(this.TextChanged);
            // 
            // btDelete
            // 
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Location = new System.Drawing.Point(595, 429);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(94, 29);
            this.btDelete.TabIndex = 9;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btClear
            // 
            this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClear.Location = new System.Drawing.Point(727, 429);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(94, 29);
            this.btClear.TabIndex = 10;
            this.btClear.Text = "Clear all";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // lbQuestion
            // 
            this.lbQuestion.FormattingEnabled = true;
            this.lbQuestion.Location = new System.Drawing.Point(13, 46);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(225, 329);
            this.lbQuestion.TabIndex = 25;
            this.lbQuestion.SelectedIndexChanged += new System.EventHandler(this.IndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(70, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "List All Question";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(50, 435);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(59, 20);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Code";
            // 
            // btSearch
            // 
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Location = new System.Drawing.Point(144, 430);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(94, 29);
            this.btSearch.TabIndex = 12;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // ckbAnswerE
            // 
            this.ckbAnswerE.AutoSize = true;
            this.ckbAnswerE.Location = new System.Drawing.Point(279, 334);
            this.ckbAnswerE.Name = "ckbAnswerE";
            this.ckbAnswerE.Size = new System.Drawing.Size(33, 17);
            this.ckbAnswerE.TabIndex = 30;
            this.ckbAnswerE.Text = "E";
            this.ckbAnswerE.UseVisualStyleBackColor = true;
            this.ckbAnswerE.CheckedChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtAnswerE
            // 
            this.txtAnswerE.Location = new System.Drawing.Point(321, 331);
            this.txtAnswerE.Multiline = true;
            this.txtAnswerE.Name = "txtAnswerE";
            this.txtAnswerE.Size = new System.Drawing.Size(500, 20);
            this.txtAnswerE.TabIndex = 29;
            this.txtAnswerE.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // ckbAnswerF
            // 
            this.ckbAnswerF.AutoSize = true;
            this.ckbAnswerF.Location = new System.Drawing.Point(279, 361);
            this.ckbAnswerF.Name = "ckbAnswerF";
            this.ckbAnswerF.Size = new System.Drawing.Size(32, 17);
            this.ckbAnswerF.TabIndex = 32;
            this.ckbAnswerF.Text = "F";
            this.ckbAnswerF.UseVisualStyleBackColor = true;
            this.ckbAnswerF.CheckedChanged += new System.EventHandler(this.TextChanged);
            // 
            // txtAnswerF
            // 
            this.txtAnswerF.Location = new System.Drawing.Point(321, 358);
            this.txtAnswerF.Multiline = true;
            this.txtAnswerF.Name = "txtAnswerF";
            this.txtAnswerF.Size = new System.Drawing.Size(500, 20);
            this.txtAnswerF.TabIndex = 31;
            this.txtAnswerF.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // btUpdate
            // 
            this.btUpdate.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUpdate.Location = new System.Drawing.Point(456, 430);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(94, 29);
            this.btUpdate.TabIndex = 33;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.UseWaitCursor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // cbbTopic
            // 
            this.cbbTopic.FormattingEnabled = true;
            this.cbbTopic.Location = new System.Drawing.Point(321, 53);
            this.cbbTopic.Name = "cbbTopic";
            this.cbbTopic.Size = new System.Drawing.Size(146, 21);
            this.cbbTopic.TabIndex = 34;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(851, 90);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(281, 285);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 36;
            this.pictureBox.TabStop = false;
            // 
            // btBrowse
            // 
            this.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrowse.Location = new System.Drawing.Point(1045, 46);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(87, 31);
            this.btBrowse.TabIndex = 37;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // btClearImage
            // 
            this.btClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClearImage.Location = new System.Drawing.Point(902, 48);
            this.btClearImage.Name = "btClearImage";
            this.btClearImage.Size = new System.Drawing.Size(87, 29);
            this.btClearImage.TabIndex = 38;
            this.btClearImage.Text = "Clear Image";
            this.btClearImage.UseVisualStyleBackColor = true;
            this.btClearImage.Click += new System.EventHandler(this.btClearImage_Click);
            // 
            // btShowTopic
            // 
            this.btShowTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowTopic.Location = new System.Drawing.Point(500, 48);
            this.btShowTopic.Name = "btShowTopic";
            this.btShowTopic.Size = new System.Drawing.Size(87, 29);
            this.btShowTopic.TabIndex = 39;
            this.btShowTopic.Text = "Show Topic";
            this.btShowTopic.UseVisualStyleBackColor = true;
            this.btShowTopic.Visible = false;
            this.btShowTopic.Click += new System.EventHandler(this.btShowTopic_Click);
            // 
            // btShowAll
            // 
            this.btShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowAll.Location = new System.Drawing.Point(621, 48);
            this.btShowAll.Name = "btShowAll";
            this.btShowAll.Size = new System.Drawing.Size(87, 29);
            this.btShowAll.TabIndex = 40;
            this.btShowAll.Text = "Show All";
            this.btShowAll.UseVisualStyleBackColor = true;
            this.btShowAll.Visible = false;
            this.btShowAll.Click += new System.EventHandler(this.btShowAll_Click);
            // 
            // errmes
            // 
            this.errmes.AutoSize = true;
            this.errmes.Location = new System.Drawing.Point(321, 395);
            this.errmes.Name = "errmes";
            this.errmes.Size = new System.Drawing.Size(75, 13);
            this.errmes.TabIndex = 41;
            this.errmes.Text = "Error Message";
            // 
            // Form_QuestionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 478);
            this.Controls.Add(this.errmes);
            this.Controls.Add(this.btShowAll);
            this.Controls.Add(this.btShowTopic);
            this.Controls.Add(this.btClearImage);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.cbbTopic);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.ckbAnswerF);
            this.Controls.Add(this.txtAnswerF);
            this.Controls.Add(this.ckbAnswerE);
            this.Controls.Add(this.txtAnswerE);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.ckbAnswerD);
            this.Controls.Add(this.ckbAnswerC);
            this.Controls.Add(this.ckbAnswerB);
            this.Controls.Add(this.ckbAnswerA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.txtAnswerD);
            this.Controls.Add(this.txtAnswerC);
            this.Controls.Add(this.txtAnswerB);
            this.Controls.Add(this.txtAnswerA);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.txtMark);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_QuestionManagement";
            this.Text = "Question Management";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtAnswerA;
        private System.Windows.Forms.TextBox txtAnswerB;
        private System.Windows.Forms.TextBox txtAnswerC;
        private System.Windows.Forms.TextBox txtAnswerD;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckbAnswerA;
        private System.Windows.Forms.CheckBox ckbAnswerB;
        private System.Windows.Forms.CheckBox ckbAnswerC;
        private System.Windows.Forms.CheckBox ckbAnswerD;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.ListBox lbQuestion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.CheckBox ckbAnswerE;
        private System.Windows.Forms.TextBox txtAnswerE;
        private System.Windows.Forms.CheckBox ckbAnswerF;
        private System.Windows.Forms.TextBox txtAnswerF;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ComboBox cbbTopic;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btClearImage;
        private System.Windows.Forms.Button btShowTopic;
        private System.Windows.Forms.Button btShowAll;
        private System.Windows.Forms.Label errmes;

    }
}

