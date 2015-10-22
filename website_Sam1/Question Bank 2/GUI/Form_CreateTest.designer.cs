namespace GUI
{
    partial class Form_CreateTest
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
            this.cbbTopic = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbQuestion = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.btShow = new System.Windows.Forms.Button();
            this.btRandom = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Topic";
            // 
            // cbbTopic
            // 
            this.cbbTopic.FormattingEnabled = true;
            this.cbbTopic.Location = new System.Drawing.Point(96, 55);
            this.cbbTopic.Name = "cbbTopic";
            this.cbbTopic.Size = new System.Drawing.Size(171, 21);
            this.cbbTopic.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Questions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "No.Questions:";
            // 
            // lbQuestion
            // 
            this.lbQuestion.FormattingEnabled = true;
            this.lbQuestion.Location = new System.Drawing.Point(39, 151);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(392, 160);
            this.lbQuestion.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(123, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Create Test Questions";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(126, 90);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(58, 20);
            this.txtNo.TabIndex = 6;
            this.txtNo.TextChanged += new System.EventHandler(this.textchanged);
            // 
            // btShow
            // 
            this.btShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShow.Location = new System.Drawing.Point(336, 84);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(95, 28);
            this.btShow.TabIndex = 7;
            this.btShow.Text = "Show Question";
            this.btShow.UseVisualStyleBackColor = true;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // btRandom
            // 
            this.btRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRandom.Location = new System.Drawing.Point(208, 85);
            this.btRandom.Name = "btRandom";
            this.btRandom.Size = new System.Drawing.Size(105, 28);
            this.btRandom.TabIndex = 8;
            this.btRandom.Text = "Random Generate";
            this.btRandom.UseVisualStyleBackColor = true;
            this.btRandom.Click += new System.EventHandler(this.btRandom_Click);
            // 
            // btClose
            // 
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(298, 333);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(69, 28);
            this.btClose.TabIndex = 9;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btExport
            // 
            this.btExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExport.Location = new System.Drawing.Point(96, 333);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(69, 28);
            this.btExport.TabIndex = 10;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // Form_CreateTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 373);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btRandom);
            this.Controls.Add(this.btShow);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbTopic);
            this.Controls.Add(this.label1);
            this.Name = "Form_CreateTest";
            this.Text = "Create Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTopic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbQuestion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Button btShow;
        private System.Windows.Forms.Button btRandom;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btExport;
    }
}