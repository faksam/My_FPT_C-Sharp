namespace GUI
{
    partial class Form_MainMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTopicManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuestionManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuFunction,
            this.menuWindows});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.menuWindows;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1266, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(92, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuFunction
            // 
            this.menuFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTopicManagement,
            this.menuQuestionManagement,
            this.menuCreateTest});
            this.menuFunction.Name = "menuFunction";
            this.menuFunction.Size = new System.Drawing.Size(66, 20);
            this.menuFunction.Text = "F&unction";
            // 
            // menuTopicManagement
            // 
            this.menuTopicManagement.Name = "menuTopicManagement";
            this.menuTopicManagement.Size = new System.Drawing.Size(193, 22);
            this.menuTopicManagement.Text = "&Topic Management";
            this.menuTopicManagement.Click += new System.EventHandler(this.topicManagementToolStripMenuItem_Click);
            // 
            // menuQuestionManagement
            // 
            this.menuQuestionManagement.Name = "menuQuestionManagement";
            this.menuQuestionManagement.Size = new System.Drawing.Size(193, 22);
            this.menuQuestionManagement.Text = "&QuestionManagement";
            this.menuQuestionManagement.Click += new System.EventHandler(this.menuQuestionManagement_Click);
            // 
            // menuCreateTest
            // 
            this.menuCreateTest.Name = "menuCreateTest";
            this.menuCreateTest.Size = new System.Drawing.Size(193, 22);
            this.menuCreateTest.Text = "&Create Test";
            this.menuCreateTest.Click += new System.EventHandler(this.menuCreateTest_Click);
            // 
            // menuWindows
            // 
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(68, 20);
            this.menuWindows.Text = "&Windows";
            // 
            // Form_MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 657);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_MainMDI";
            this.Text = "Question Bank 2.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuFunction;
        private System.Windows.Forms.ToolStripMenuItem menuWindows;
        private System.Windows.Forms.ToolStripMenuItem menuTopicManagement;
        private System.Windows.Forms.ToolStripMenuItem menuQuestionManagement;
        private System.Windows.Forms.ToolStripMenuItem menuCreateTest;
    }
}