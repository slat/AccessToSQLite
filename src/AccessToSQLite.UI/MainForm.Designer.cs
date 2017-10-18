namespace AccessToSQLite.UI
{
    partial class MainForm
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
            this._grpImport = new System.Windows.Forms.GroupBox();
            this._txtAccessPassword = new System.Windows.Forms.TextBox();
            this._btnAccessSelect = new System.Windows.Forms.Button();
            this._txtAccessFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._btnExport = new System.Windows.Forms.Button();
            this._rtxLogs = new System.Windows.Forms.RichTextBox();
            this._grpExport = new System.Windows.Forms.GroupBox();
            this._txtSQLiteFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btnSQLiteSelect = new System.Windows.Forms.Button();
            this._grpImport.SuspendLayout();
            this._grpExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpImport
            // 
            this._grpImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpImport.Controls.Add(this._txtAccessPassword);
            this._grpImport.Controls.Add(this._btnAccessSelect);
            this._grpImport.Controls.Add(this._txtAccessFileName);
            this._grpImport.Controls.Add(this.label2);
            this._grpImport.Controls.Add(this.label1);
            this._grpImport.Location = new System.Drawing.Point(13, 13);
            this._grpImport.Name = "_grpImport";
            this._grpImport.Size = new System.Drawing.Size(375, 85);
            this._grpImport.TabIndex = 0;
            this._grpImport.TabStop = false;
            this._grpImport.Text = "Access Import";
            // 
            // _txtAccessPassword
            // 
            this._txtAccessPassword.Location = new System.Drawing.Point(67, 51);
            this._txtAccessPassword.Name = "_txtAccessPassword";
            this._txtAccessPassword.Size = new System.Drawing.Size(176, 22);
            this._txtAccessPassword.TabIndex = 3;
            // 
            // _btnAccessSelect
            // 
            this._btnAccessSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAccessSelect.Location = new System.Drawing.Point(341, 21);
            this._btnAccessSelect.Name = "_btnAccessSelect";
            this._btnAccessSelect.Size = new System.Drawing.Size(28, 23);
            this._btnAccessSelect.TabIndex = 2;
            this._btnAccessSelect.Text = "...";
            this._btnAccessSelect.UseVisualStyleBackColor = true;
            this._btnAccessSelect.Click += new System.EventHandler(this._btnAccessSelect_Click);
            // 
            // _txtAccessFileName
            // 
            this._txtAccessFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAccessFileName.Location = new System.Drawing.Point(67, 23);
            this._txtAccessFileName.Name = "_txtAccessFileName";
            this._txtAccessFileName.ReadOnly = true;
            this._txtAccessFileName.Size = new System.Drawing.Size(268, 22);
            this._txtAccessFileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FileName";
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExport.Location = new System.Drawing.Point(331, 162);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(57, 23);
            this._btnExport.TabIndex = 2;
            this._btnExport.Text = "Export";
            this._btnExport.UseVisualStyleBackColor = true;
            this._btnExport.Click += new System.EventHandler(this._btnExport_Click);
            // 
            // _rtxLogs
            // 
            this._rtxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._rtxLogs.BackColor = System.Drawing.SystemColors.Info;
            this._rtxLogs.Location = new System.Drawing.Point(13, 191);
            this._rtxLogs.Name = "_rtxLogs";
            this._rtxLogs.ReadOnly = true;
            this._rtxLogs.Size = new System.Drawing.Size(375, 205);
            this._rtxLogs.TabIndex = 3;
            this._rtxLogs.Text = "";
            // 
            // _grpExport
            // 
            this._grpExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpExport.Controls.Add(this._txtSQLiteFileName);
            this._grpExport.Controls.Add(this.label3);
            this._grpExport.Controls.Add(this._btnSQLiteSelect);
            this._grpExport.Location = new System.Drawing.Point(13, 105);
            this._grpExport.Name = "_grpExport";
            this._grpExport.Size = new System.Drawing.Size(375, 51);
            this._grpExport.TabIndex = 1;
            this._grpExport.TabStop = false;
            this._grpExport.Text = "SQLite Export";
            // 
            // _txtSQLiteFileName
            // 
            this._txtSQLiteFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSQLiteFileName.Location = new System.Drawing.Point(67, 21);
            this._txtSQLiteFileName.Name = "_txtSQLiteFileName";
            this._txtSQLiteFileName.ReadOnly = true;
            this._txtSQLiteFileName.Size = new System.Drawing.Size(268, 22);
            this._txtSQLiteFileName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "FileName";
            // 
            // _btnSQLiteSelect
            // 
            this._btnSQLiteSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSQLiteSelect.Location = new System.Drawing.Point(341, 19);
            this._btnSQLiteSelect.Name = "_btnSQLiteSelect";
            this._btnSQLiteSelect.Size = new System.Drawing.Size(28, 23);
            this._btnSQLiteSelect.TabIndex = 2;
            this._btnSQLiteSelect.Text = "...";
            this._btnSQLiteSelect.UseVisualStyleBackColor = true;
            this._btnSQLiteSelect.Click += new System.EventHandler(this._btnSQLiteSelect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 408);
            this.Controls.Add(this._grpExport);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._rtxLogs);
            this.Controls.Add(this._grpImport);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccessToSQLite";
            this._grpImport.ResumeLayout(false);
            this._grpImport.PerformLayout();
            this._grpExport.ResumeLayout(false);
            this._grpExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpImport;
        private System.Windows.Forms.Button _btnAccessSelect;
        private System.Windows.Forms.TextBox _txtAccessFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnExport;
        private System.Windows.Forms.RichTextBox _rtxLogs;
        private System.Windows.Forms.TextBox _txtAccessPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox _grpExport;
        private System.Windows.Forms.TextBox _txtSQLiteFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btnSQLiteSelect;
    }
}

