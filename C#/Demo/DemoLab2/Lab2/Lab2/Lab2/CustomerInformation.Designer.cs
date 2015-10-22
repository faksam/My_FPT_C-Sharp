namespace Lab2
{
    partial class CustomerInformation
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
            this.components = new System.ComponentModel.Container();
            this.lbl_CustomerID = new System.Windows.Forms.Label();
            this.lbl_CustomerName = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_PhoneNo = new System.Windows.Forms.Label();
            this.lbl_Extension = new System.Windows.Forms.Label();
            this.mtb_PhoneNo = new System.Windows.Forms.MaskedTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lbl_Country = new System.Windows.Forms.Label();
            this.lbl_PostalCode = new System.Windows.Forms.Label();
            this.cbb_Country = new System.Windows.Forms.ComboBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.txt_CustomerID = new System.Windows.Forms.TextBox();
            this.txt_CustomerName = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Extension = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_PostalCode = new System.Windows.Forms.TextBox();
            this.err_CustomerID = new System.Windows.Forms.ErrorProvider(this.components);
            this.err_Email = new System.Windows.Forms.ErrorProvider(this.components);
            this.err_Extension = new System.Windows.Forms.ErrorProvider(this.components);
            this.err_PostalCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.err_Country = new System.Windows.Forms.ErrorProvider(this.components);
            this.err_PhoneNo = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err_CustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_Extension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_PostalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_Country)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_PhoneNo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_CustomerID
            // 
            this.lbl_CustomerID.AutoSize = true;
            this.lbl_CustomerID.Location = new System.Drawing.Point(15, 16);
            this.lbl_CustomerID.Name = "lbl_CustomerID";
            this.lbl_CustomerID.Size = new System.Drawing.Size(65, 13);
            this.lbl_CustomerID.TabIndex = 0;
            this.lbl_CustomerID.Text = "Customer ID";
            // 
            // lbl_CustomerName
            // 
            this.lbl_CustomerName.AutoSize = true;
            this.lbl_CustomerName.Location = new System.Drawing.Point(15, 61);
            this.lbl_CustomerName.Name = "lbl_CustomerName";
            this.lbl_CustomerName.Size = new System.Drawing.Size(82, 13);
            this.lbl_CustomerName.TabIndex = 1;
            this.lbl_CustomerName.Text = "Customer Name";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(15, 108);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 2;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_PhoneNo
            // 
            this.lbl_PhoneNo.AutoSize = true;
            this.lbl_PhoneNo.Location = new System.Drawing.Point(15, 156);
            this.lbl_PhoneNo.Name = "lbl_PhoneNo";
            this.lbl_PhoneNo.Size = new System.Drawing.Size(58, 13);
            this.lbl_PhoneNo.TabIndex = 3;
            this.lbl_PhoneNo.Text = "Phone No.";
            // 
            // lbl_Extension
            // 
            this.lbl_Extension.AutoSize = true;
            this.lbl_Extension.Location = new System.Drawing.Point(15, 203);
            this.lbl_Extension.Name = "lbl_Extension";
            this.lbl_Extension.Size = new System.Drawing.Size(53, 13);
            this.lbl_Extension.TabIndex = 4;
            this.lbl_Extension.Text = "Extension";
            // 
            // mtb_PhoneNo
            // 
            this.mtb_PhoneNo.Location = new System.Drawing.Point(126, 153);
            this.mtb_PhoneNo.Mask = "(000)-000-0000";
            this.mtb_PhoneNo.Name = "mtb_PhoneNo";
            this.mtb_PhoneNo.Size = new System.Drawing.Size(154, 20);
            this.mtb_PhoneNo.TabIndex = 8;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(345, 16);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Location = new System.Drawing.Point(345, 61);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(43, 13);
            this.lbl_Country.TabIndex = 11;
            this.lbl_Country.Text = "Country";
            // 
            // lbl_PostalCode
            // 
            this.lbl_PostalCode.AutoSize = true;
            this.lbl_PostalCode.Location = new System.Drawing.Point(347, 108);
            this.lbl_PostalCode.Name = "lbl_PostalCode";
            this.lbl_PostalCode.Size = new System.Drawing.Size(61, 13);
            this.lbl_PostalCode.TabIndex = 12;
            this.lbl_PostalCode.Text = "PostalCode";
            // 
            // cbb_Country
            // 
            this.cbb_Country.FormattingEnabled = true;
            this.cbb_Country.Items.AddRange(new object[] {
            "Viet Nam",
            "Malaysia",
            "Thailand",
            "Philippines",
            "Brunei",
            "Indonesia",
            "Myanmar",
            "Laos",
            "Cambodia"});
            this.cbb_Country.Location = new System.Drawing.Point(446, 58);
            this.cbb_Country.Name = "cbb_Country";
            this.cbb_Country.Size = new System.Drawing.Size(154, 21);
            this.cbb_Country.TabIndex = 15;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(399, 194);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(106, 31);
            this.btn_Save.TabIndex = 16;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(534, 194);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(106, 31);
            this.btn_Close.TabIndex = 17;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // txt_CustomerID
            // 
            this.txt_CustomerID.Location = new System.Drawing.Point(126, 13);
            this.txt_CustomerID.Name = "txt_CustomerID";
            this.txt_CustomerID.Size = new System.Drawing.Size(154, 20);
            this.txt_CustomerID.TabIndex = 18;
            // 
            // txt_CustomerName
            // 
            this.txt_CustomerName.Location = new System.Drawing.Point(126, 58);
            this.txt_CustomerName.Name = "txt_CustomerName";
            this.txt_CustomerName.Size = new System.Drawing.Size(154, 20);
            this.txt_CustomerName.TabIndex = 19;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(126, 105);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(154, 20);
            this.txt_Email.TabIndex = 20;
            // 
            // txt_Extension
            // 
            this.txt_Extension.Location = new System.Drawing.Point(126, 200);
            this.txt_Extension.Name = "txt_Extension";
            this.txt_Extension.Size = new System.Drawing.Size(154, 20);
            this.txt_Extension.TabIndex = 21;
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(446, 13);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(154, 20);
            this.txt_Address.TabIndex = 22;
            // 
            // txt_PostalCode
            // 
            this.txt_PostalCode.Location = new System.Drawing.Point(446, 105);
            this.txt_PostalCode.Name = "txt_PostalCode";
            this.txt_PostalCode.Size = new System.Drawing.Size(154, 20);
            this.txt_PostalCode.TabIndex = 23;
            // 
            // err_CustomerID
            // 
            this.err_CustomerID.ContainerControl = this;
            // 
            // err_Email
            // 
            this.err_Email.ContainerControl = this;
            // 
            // err_Extension
            // 
            this.err_Extension.ContainerControl = this;
            // 
            // err_PostalCode
            // 
            this.err_PostalCode.ContainerControl = this;
            // 
            // err_Country
            // 
            this.err_Country.ContainerControl = this;
            // 
            // err_PhoneNo
            // 
            this.err_PhoneNo.ContainerControl = this;
            // 
            // CustomerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 358);
            this.Controls.Add(this.txt_PostalCode);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.txt_Extension);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_CustomerName);
            this.Controls.Add(this.txt_CustomerID);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cbb_Country);
            this.Controls.Add(this.lbl_PostalCode);
            this.Controls.Add(this.lbl_Country);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.mtb_PhoneNo);
            this.Controls.Add(this.lbl_Extension);
            this.Controls.Add(this.lbl_PhoneNo);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_CustomerName);
            this.Controls.Add(this.lbl_CustomerID);
            this.Name = "CustomerInformation";
            this.Text = "Customer Information";
            ((System.ComponentModel.ISupportInitialize)(this.err_CustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_Extension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_PostalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_Country)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err_PhoneNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CustomerID;
        private System.Windows.Forms.Label lbl_CustomerName;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_PhoneNo;
        private System.Windows.Forms.Label lbl_Extension;
        private System.Windows.Forms.MaskedTextBox mtb_PhoneNo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lbl_Country;
        private System.Windows.Forms.Label lbl_PostalCode;
        private System.Windows.Forms.ComboBox cbb_Country;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox txt_CustomerID;
        private System.Windows.Forms.TextBox txt_CustomerName;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Extension;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_PostalCode;
        private System.Windows.Forms.ErrorProvider err_CustomerID;
        private System.Windows.Forms.ErrorProvider err_Email;
        private System.Windows.Forms.ErrorProvider err_Extension;
        private System.Windows.Forms.ErrorProvider err_PostalCode;
        private System.Windows.Forms.ErrorProvider err_Country;
        private System.Windows.Forms.ErrorProvider err_PhoneNo;
    }
}

