namespace DataAccess1
{
    partial class ACADEMY
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displaySemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStudentStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStudentStatusToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClassToolStripMenuItem,
            this.addStudentClassToolStripMenuItem,
            this.displaySemesterToolStripMenuItem,
            this.updateStudentStatusToolStripMenuItem,
            this.updateStudentStatusToolStripMenuItem1,
            this.dataFilterToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // addClassToolStripMenuItem
            // 
            this.addClassToolStripMenuItem.Name = "addClassToolStripMenuItem";
            this.addClassToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addClassToolStripMenuItem.Text = "Add Class";
            this.addClassToolStripMenuItem.Click += new System.EventHandler(this.addClassToolStripMenuItem_Click);
            // 
            // addStudentClassToolStripMenuItem
            // 
            this.addStudentClassToolStripMenuItem.Name = "addStudentClassToolStripMenuItem";
            this.addStudentClassToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addStudentClassToolStripMenuItem.Text = "Add Student Class";
            this.addStudentClassToolStripMenuItem.Click += new System.EventHandler(this.addStudentClassToolStripMenuItem_Click);
            // 
            // displaySemesterToolStripMenuItem
            // 
            this.displaySemesterToolStripMenuItem.Name = "displaySemesterToolStripMenuItem";
            this.displaySemesterToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.displaySemesterToolStripMenuItem.Text = "Add Student";
            this.displaySemesterToolStripMenuItem.Click += new System.EventHandler(this.displaySemesterToolStripMenuItem_Click);
            // 
            // updateStudentStatusToolStripMenuItem
            // 
            this.updateStudentStatusToolStripMenuItem.Name = "updateStudentStatusToolStripMenuItem";
            this.updateStudentStatusToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.updateStudentStatusToolStripMenuItem.Text = "Display Semester";
            this.updateStudentStatusToolStripMenuItem.Click += new System.EventHandler(this.updateStudentStatusToolStripMenuItem_Click);
            // 
            // updateStudentStatusToolStripMenuItem1
            // 
            this.updateStudentStatusToolStripMenuItem1.Name = "updateStudentStatusToolStripMenuItem1";
            this.updateStudentStatusToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.updateStudentStatusToolStripMenuItem1.Text = "Update Student Status";
            this.updateStudentStatusToolStripMenuItem1.Click += new System.EventHandler(this.updateStudentStatusToolStripMenuItem1_Click);
            // 
            // dataFilterToolStripMenuItem
            // 
            this.dataFilterToolStripMenuItem.Name = "dataFilterToolStripMenuItem";
            this.dataFilterToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.dataFilterToolStripMenuItem.Text = "Data Filter";
            this.dataFilterToolStripMenuItem.Click += new System.EventHandler(this.dataFilterToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // ACADEMY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 261);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ACADEMY";
            this.Text = "ACADEMY";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displaySemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStudentStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStudentStatusToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dataFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}