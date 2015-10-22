namespace Lab3_Group1.GUI
{
    partial class BookGUI
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
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthors = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtBookNumber = new System.Windows.Forms.TextBox();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelAuthors = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelBookNumber = new System.Windows.Forms.Label();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonBDelete = new System.Windows.Forms.Button();
            this.buttonBEdit = new System.Windows.Forms.Button();
            this.buttonBAdd = new System.Windows.Forms.Button();
            this.dataGridViewBook = new System.Windows.Forms.DataGridView();
            this.groupBoxCopy = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtSequenceNumber = new System.Windows.Forms.TextBox();
            this.txtCopyNumber = new System.Windows.Forms.TextBox();
            this.txtBookNumber1 = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelSequenceNumber = new System.Windows.Forms.Label();
            this.labelCopyNumber = new System.Windows.Forms.Label();
            this.labelCBookNumber = new System.Windows.Forms.Label();
            this.buttonCDelete = new System.Windows.Forms.Button();
            this.buttonCEdit = new System.Windows.Forms.Button();
            this.buttonCAdd = new System.Windows.Forms.Button();
            this.dataGridViewCopy = new System.Windows.Forms.DataGridView();
            this.groupBoxBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).BeginInit();
            this.groupBoxCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCopy)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxBook.Controls.Add(this.txtPublisher);
            this.groupBoxBook.Controls.Add(this.txtAuthors);
            this.groupBoxBook.Controls.Add(this.txtTitle);
            this.groupBoxBook.Controls.Add(this.txtBookNumber);
            this.groupBoxBook.Controls.Add(this.labelPublisher);
            this.groupBoxBook.Controls.Add(this.labelAuthors);
            this.groupBoxBook.Controls.Add(this.labelTitle);
            this.groupBoxBook.Controls.Add(this.labelBookNumber);
            this.groupBoxBook.Controls.Add(this.buttonFilter);
            this.groupBoxBook.Controls.Add(this.buttonBDelete);
            this.groupBoxBook.Controls.Add(this.buttonBEdit);
            this.groupBoxBook.Controls.Add(this.buttonBAdd);
            this.groupBoxBook.Controls.Add(this.dataGridViewBook);
            this.groupBoxBook.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(930, 225);
            this.groupBoxBook.TabIndex = 0;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "Book";
            // 
            // txtPublisher
            // 
            this.txtPublisher.Enabled = false;
            this.txtPublisher.Location = new System.Drawing.Point(124, 109);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(151, 20);
            this.txtPublisher.TabIndex = 15;
            // 
            // txtAuthors
            // 
            this.txtAuthors.Enabled = false;
            this.txtAuthors.Location = new System.Drawing.Point(124, 83);
            this.txtAuthors.Name = "txtAuthors";
            this.txtAuthors.Size = new System.Drawing.Size(151, 20);
            this.txtAuthors.TabIndex = 14;
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(124, 57);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(151, 20);
            this.txtTitle.TabIndex = 13;
            // 
            // txtBookNumber
            // 
            this.txtBookNumber.Location = new System.Drawing.Point(124, 31);
            this.txtBookNumber.Name = "txtBookNumber";
            this.txtBookNumber.Size = new System.Drawing.Size(151, 20);
            this.txtBookNumber.TabIndex = 12;
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(62, 112);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(56, 13);
            this.labelPublisher.TabIndex = 11;
            this.labelPublisher.Text = "Publisher :";
            // 
            // labelAuthors
            // 
            this.labelAuthors.AutoSize = true;
            this.labelAuthors.Location = new System.Drawing.Point(69, 86);
            this.labelAuthors.Name = "labelAuthors";
            this.labelAuthors.Size = new System.Drawing.Size(49, 13);
            this.labelAuthors.TabIndex = 10;
            this.labelAuthors.Text = "Authors :";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(85, 60);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(33, 13);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Text = "Title :";
            // 
            // labelBookNumber
            // 
            this.labelBookNumber.AutoSize = true;
            this.labelBookNumber.Location = new System.Drawing.Point(40, 34);
            this.labelBookNumber.Name = "labelBookNumber";
            this.labelBookNumber.Size = new System.Drawing.Size(78, 13);
            this.labelBookNumber.TabIndex = 8;
            this.labelBookNumber.Text = "Book Number :";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(57, 189);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 7;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonBDelete
            // 
            this.buttonBDelete.Location = new System.Drawing.Point(670, 189);
            this.buttonBDelete.Name = "buttonBDelete";
            this.buttonBDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonBDelete.TabIndex = 3;
            this.buttonBDelete.Text = "Delete";
            this.buttonBDelete.UseVisualStyleBackColor = true;
            this.buttonBDelete.Click += new System.EventHandler(this.buttonBDelete_Click);
            // 
            // buttonBEdit
            // 
            this.buttonBEdit.Location = new System.Drawing.Point(563, 189);
            this.buttonBEdit.Name = "buttonBEdit";
            this.buttonBEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonBEdit.TabIndex = 2;
            this.buttonBEdit.Text = "Edit";
            this.buttonBEdit.UseVisualStyleBackColor = true;
            this.buttonBEdit.Click += new System.EventHandler(this.buttonBEdit_Click);
            // 
            // buttonBAdd
            // 
            this.buttonBAdd.Location = new System.Drawing.Point(460, 189);
            this.buttonBAdd.Name = "buttonBAdd";
            this.buttonBAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonBAdd.TabIndex = 1;
            this.buttonBAdd.Text = "Add";
            this.buttonBAdd.UseVisualStyleBackColor = true;
            this.buttonBAdd.Click += new System.EventHandler(this.buttonBAdd_Click);
            // 
            // dataGridViewBook
            // 
            this.dataGridViewBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBook.Location = new System.Drawing.Point(339, 19);
            this.dataGridViewBook.Name = "dataGridViewBook";
            this.dataGridViewBook.Size = new System.Drawing.Size(456, 155);
            this.dataGridViewBook.TabIndex = 0;
            this.dataGridViewBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBook_CellClick);
            // 
            // groupBoxCopy
            // 
            this.groupBoxCopy.Controls.Add(this.txtPrice);
            this.groupBoxCopy.Controls.Add(this.txtType);
            this.groupBoxCopy.Controls.Add(this.txtSequenceNumber);
            this.groupBoxCopy.Controls.Add(this.txtCopyNumber);
            this.groupBoxCopy.Controls.Add(this.txtBookNumber1);
            this.groupBoxCopy.Controls.Add(this.labelPrice);
            this.groupBoxCopy.Controls.Add(this.labelType);
            this.groupBoxCopy.Controls.Add(this.labelSequenceNumber);
            this.groupBoxCopy.Controls.Add(this.labelCopyNumber);
            this.groupBoxCopy.Controls.Add(this.labelCBookNumber);
            this.groupBoxCopy.Controls.Add(this.buttonCDelete);
            this.groupBoxCopy.Controls.Add(this.buttonCEdit);
            this.groupBoxCopy.Controls.Add(this.buttonCAdd);
            this.groupBoxCopy.Controls.Add(this.dataGridViewCopy);
            this.groupBoxCopy.Location = new System.Drawing.Point(12, 243);
            this.groupBoxCopy.Name = "groupBoxCopy";
            this.groupBoxCopy.Size = new System.Drawing.Size(930, 225);
            this.groupBoxCopy.TabIndex = 1;
            this.groupBoxCopy.TabStop = false;
            this.groupBoxCopy.Text = "Copy";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(124, 133);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(151, 20);
            this.txtPrice.TabIndex = 20;
            // 
            // txtType
            // 
            this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(124, 107);
            this.txtType.MaxLength = 1;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(151, 20);
            this.txtType.TabIndex = 19;
            // 
            // txtSequenceNumber
            // 
            this.txtSequenceNumber.Enabled = false;
            this.txtSequenceNumber.Location = new System.Drawing.Point(124, 81);
            this.txtSequenceNumber.Name = "txtSequenceNumber";
            this.txtSequenceNumber.Size = new System.Drawing.Size(151, 20);
            this.txtSequenceNumber.TabIndex = 18;
            // 
            // txtCopyNumber
            // 
            this.txtCopyNumber.Enabled = false;
            this.txtCopyNumber.Location = new System.Drawing.Point(124, 55);
            this.txtCopyNumber.Name = "txtCopyNumber";
            this.txtCopyNumber.Size = new System.Drawing.Size(151, 20);
            this.txtCopyNumber.TabIndex = 17;
            // 
            // txtBookNumber1
            // 
            this.txtBookNumber1.Enabled = false;
            this.txtBookNumber1.Location = new System.Drawing.Point(124, 29);
            this.txtBookNumber1.Name = "txtBookNumber1";
            this.txtBookNumber1.Size = new System.Drawing.Size(151, 20);
            this.txtBookNumber1.TabIndex = 16;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(81, 136);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(37, 13);
            this.labelPrice.TabIndex = 16;
            this.labelPrice.Text = "Price :";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(81, 110);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(37, 13);
            this.labelType.TabIndex = 15;
            this.labelType.Text = "Type :";
            // 
            // labelSequenceNumber
            // 
            this.labelSequenceNumber.AutoSize = true;
            this.labelSequenceNumber.Location = new System.Drawing.Point(16, 84);
            this.labelSequenceNumber.Name = "labelSequenceNumber";
            this.labelSequenceNumber.Size = new System.Drawing.Size(102, 13);
            this.labelSequenceNumber.TabIndex = 14;
            this.labelSequenceNumber.Text = "Sequence Number :";
            // 
            // labelCopyNumber
            // 
            this.labelCopyNumber.AutoSize = true;
            this.labelCopyNumber.Location = new System.Drawing.Point(41, 58);
            this.labelCopyNumber.Name = "labelCopyNumber";
            this.labelCopyNumber.Size = new System.Drawing.Size(77, 13);
            this.labelCopyNumber.TabIndex = 13;
            this.labelCopyNumber.Text = "Copy Number :";
            // 
            // labelCBookNumber
            // 
            this.labelCBookNumber.AutoSize = true;
            this.labelCBookNumber.Location = new System.Drawing.Point(40, 32);
            this.labelCBookNumber.Name = "labelCBookNumber";
            this.labelCBookNumber.Size = new System.Drawing.Size(78, 13);
            this.labelCBookNumber.TabIndex = 12;
            this.labelCBookNumber.Text = "Book Number :";
            // 
            // buttonCDelete
            // 
            this.buttonCDelete.Location = new System.Drawing.Point(670, 187);
            this.buttonCDelete.Name = "buttonCDelete";
            this.buttonCDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonCDelete.TabIndex = 6;
            this.buttonCDelete.Text = "Delete";
            this.buttonCDelete.UseVisualStyleBackColor = true;
            this.buttonCDelete.Click += new System.EventHandler(this.buttonCDelete_Click);
            // 
            // buttonCEdit
            // 
            this.buttonCEdit.Location = new System.Drawing.Point(563, 187);
            this.buttonCEdit.Name = "buttonCEdit";
            this.buttonCEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonCEdit.TabIndex = 5;
            this.buttonCEdit.Text = "Edit";
            this.buttonCEdit.UseVisualStyleBackColor = true;
            this.buttonCEdit.Click += new System.EventHandler(this.buttonCEdit_Click);
            // 
            // buttonCAdd
            // 
            this.buttonCAdd.Location = new System.Drawing.Point(460, 187);
            this.buttonCAdd.Name = "buttonCAdd";
            this.buttonCAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonCAdd.TabIndex = 4;
            this.buttonCAdd.Text = "Add";
            this.buttonCAdd.UseVisualStyleBackColor = true;
            this.buttonCAdd.Click += new System.EventHandler(this.buttonCAdd_Click);
            // 
            // dataGridViewCopy
            // 
            this.dataGridViewCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCopy.Location = new System.Drawing.Point(339, 19);
            this.dataGridViewCopy.Name = "dataGridViewCopy";
            this.dataGridViewCopy.Size = new System.Drawing.Size(557, 151);
            this.dataGridViewCopy.TabIndex = 0;
            this.dataGridViewCopy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCopy_CellClick);
            // 
            // BookGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(948, 478);
            this.Controls.Add(this.groupBoxCopy);
            this.Controls.Add(this.groupBoxBook);
            this.Name = "BookGUI";
            this.Text = "Books";
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).EndInit();
            this.groupBoxCopy.ResumeLayout(false);
            this.groupBoxCopy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCopy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.DataGridView dataGridViewBook;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonBDelete;
        private System.Windows.Forms.Button buttonBEdit;
        private System.Windows.Forms.Button buttonBAdd;
        private System.Windows.Forms.GroupBox groupBoxCopy;
        private System.Windows.Forms.Button buttonCDelete;
        private System.Windows.Forms.Button buttonCEdit;
        private System.Windows.Forms.Button buttonCAdd;
        private System.Windows.Forms.DataGridView dataGridViewCopy;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthors;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtBookNumber;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelAuthors;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBookNumber;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtSequenceNumber;
        private System.Windows.Forms.TextBox txtCopyNumber;
        private System.Windows.Forms.TextBox txtBookNumber1;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelSequenceNumber;
        private System.Windows.Forms.Label labelCopyNumber;
        private System.Windows.Forms.Label labelCBookNumber;

    }
}