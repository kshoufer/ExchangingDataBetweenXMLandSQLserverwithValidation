namespace XMLtoDatabaseWithValidation
{
    partial class Form1
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
            this.btnWriteToXML = new System.Windows.Forms.Button();
            this.lblDataWrittenToXML = new System.Windows.Forms.Label();
            this.lblXMLtoDatabase = new System.Windows.Forms.Label();
            this.btnWriteXMLtoDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWriteToXML
            // 
            this.btnWriteToXML.Location = new System.Drawing.Point(37, 115);
            this.btnWriteToXML.Name = "btnWriteToXML";
            this.btnWriteToXML.Size = new System.Drawing.Size(143, 23);
            this.btnWriteToXML.TabIndex = 0;
            this.btnWriteToXML.Text = "Write Database to XML";
            this.btnWriteToXML.UseVisualStyleBackColor = true;
            this.btnWriteToXML.Click += new System.EventHandler(this.btnWriteToXML_Click);
            // 
            // lblDataWrittenToXML
            // 
            this.lblDataWrittenToXML.AutoSize = true;
            this.lblDataWrittenToXML.Location = new System.Drawing.Point(241, 118);
            this.lblDataWrittenToXML.Name = "lblDataWrittenToXML";
            this.lblDataWrittenToXML.Size = new System.Drawing.Size(136, 13);
            this.lblDataWrittenToXML.TabIndex = 1;
            this.lblDataWrittenToXML.Text = "Data Written to Books1.xml";
            this.lblDataWrittenToXML.Visible = false;
            // 
            // lblXMLtoDatabase
            // 
            this.lblXMLtoDatabase.AutoSize = true;
            this.lblXMLtoDatabase.Location = new System.Drawing.Point(238, 56);
            this.lblXMLtoDatabase.Name = "lblXMLtoDatabase";
            this.lblXMLtoDatabase.Size = new System.Drawing.Size(142, 13);
            this.lblXMLtoDatabase.TabIndex = 2;
            this.lblXMLtoDatabase.Text = "Data Written to Books Table";
            this.lblXMLtoDatabase.Visible = false;
            // 
            // btnWriteXMLtoDatabase
            // 
            this.btnWriteXMLtoDatabase.Location = new System.Drawing.Point(37, 51);
            this.btnWriteXMLtoDatabase.Name = "btnWriteXMLtoDatabase";
            this.btnWriteXMLtoDatabase.Size = new System.Drawing.Size(169, 23);
            this.btnWriteXMLtoDatabase.TabIndex = 3;
            this.btnWriteXMLtoDatabase.Text = "Write XML to Database";
            this.btnWriteXMLtoDatabase.UseVisualStyleBackColor = true;
            this.btnWriteXMLtoDatabase.Click += new System.EventHandler(this.btnWriteXMLtoDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 205);
            this.Controls.Add(this.btnWriteXMLtoDatabase);
            this.Controls.Add(this.lblXMLtoDatabase);
            this.Controls.Add(this.lblDataWrittenToXML);
            this.Controls.Add(this.btnWriteToXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteToXML;
        private System.Windows.Forms.Label lblDataWrittenToXML;
        private System.Windows.Forms.Label lblXMLtoDatabase;
        private System.Windows.Forms.Button btnWriteXMLtoDatabase;
    }
}

