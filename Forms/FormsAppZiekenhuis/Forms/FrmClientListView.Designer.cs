using System;
using System.Windows.Forms;

namespace FormsAppZiekenhuis
{
    partial class FrmClientListView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListViewClienten = new System.Windows.Forms.ListView();
            this.ColClientNumber = new System.Windows.Forms.ColumnHeader();
            this.ColIsInsured = new System.Windows.Forms.ColumnHeader();
            this.ColFirstName = new System.Windows.Forms.ColumnHeader();
            this.ColLastName = new System.Windows.Forms.ColumnHeader();
            this.ColNrOfInvoices = new System.Windows.Forms.ColumnHeader();
            this.ColNrOfCons = new System.Windows.Forms.ColumnHeader();
            this.ColFullAddress = new System.Windows.Forms.ColumnHeader();
            this.ColZodiacSign = new System.Windows.Forms.ColumnHeader();
            this.LabelClientNumber1 = new System.Windows.Forms.Label();
            this.LabelIsInsured = new System.Windows.Forms.Label();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.TextBoxLastName = new System.Windows.Forms.TextBox();
            this.TextBoxInsured = new System.Windows.Forms.TextBox();
            this.LabelClientNumber2 = new System.Windows.Forms.Label();
            this.ButtonUpdateClient = new System.Windows.Forms.Button();
            this.LabelErrMsg = new System.Windows.Forms.Label();
            this.LabelErrorCode = new System.Windows.Forms.Label();
            this.LblZodiac = new System.Windows.Forms.Label();
            this.TextBoxZodiac = new System.Windows.Forms.TextBox();
            this.ComboBoxSportType = new System.Windows.Forms.ComboBox();
            this.LabelSportType = new System.Windows.Forms.Label();
            this.ColSportType = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // ListViewClienten
            // 
            this.ListViewClienten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColClientNumber,
            this.ColIsInsured,
            this.ColFirstName,
            this.ColLastName,
            this.ColNrOfInvoices,
            this.ColNrOfCons,
            this.ColFullAddress,
            this.ColZodiacSign,
            this.ColSportType});
            this.ListViewClienten.HideSelection = false;
            this.ListViewClienten.Location = new System.Drawing.Point(58, 27);
            this.ListViewClienten.Name = "ListViewClienten";
            this.ListViewClienten.Size = new System.Drawing.Size(1388, 461);
            this.ListViewClienten.TabIndex = 0;
            this.ListViewClienten.UseCompatibleStateImageBehavior = false;
            this.ListViewClienten.View = System.Windows.Forms.View.Details;
            this.ListViewClienten.SelectedIndexChanged += new System.EventHandler(this.ListViewClienten_SelectedIndexChanged);
            // 
            // ColClientNumber
            // 
            this.ColClientNumber.Text = "Klant nr";
            this.ColClientNumber.Width = 100;
            // 
            // ColIsInsured
            // 
            this.ColIsInsured.Text = "Verzekerd?";
            this.ColIsInsured.Width = 100;
            // 
            // ColFirstName
            // 
            this.ColFirstName.Text = "Voornaam";
            this.ColFirstName.Width = 250;
            // 
            // ColLastName
            // 
            this.ColLastName.Text = "Achternaam";
            this.ColLastName.Width = 250;
            // 
            // ColNrOfInvoices
            // 
            this.ColNrOfInvoices.Text = "# Fact";
            // 
            // ColNrOfCons
            // 
            this.ColNrOfCons.Text = "# Cons";
            // 
            // ColFullAddress
            // 
            this.ColFullAddress.Text = "Adres";
            this.ColFullAddress.Width = 300;
            // 
            // ColZodiacSign
            // 
            this.ColZodiacSign.Text = "Sterrenbeeld";
            this.ColZodiacSign.Width = 100;
            // 
            // LabelClientNumber1
            // 
            this.LabelClientNumber1.AutoSize = true;
            this.LabelClientNumber1.Location = new System.Drawing.Point(57, 497);
            this.LabelClientNumber1.Name = "LabelClientNumber1";
            this.LabelClientNumber1.Size = new System.Drawing.Size(101, 20);
            this.LabelClientNumber1.TabIndex = 1;
            this.LabelClientNumber1.Text = "Klantnummer:";
            // 
            // LabelIsInsured
            // 
            this.LabelIsInsured.AutoSize = true;
            this.LabelIsInsured.Location = new System.Drawing.Point(272, 494);
            this.LabelIsInsured.Name = "LabelIsInsured";
            this.LabelIsInsured.Size = new System.Drawing.Size(81, 20);
            this.LabelIsInsured.TabIndex = 1;
            this.LabelIsInsured.Text = "Verzekerd: ";
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.AutoSize = true;
            this.LabelFirstName.Location = new System.Drawing.Point(58, 544);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(80, 20);
            this.LabelFirstName.TabIndex = 1;
            this.LabelFirstName.Text = "Voornaam:";
            // 
            // LabelLastName
            // 
            this.LabelLastName.AutoSize = true;
            this.LabelLastName.Location = new System.Drawing.Point(55, 580);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(96, 20);
            this.LabelLastName.TabIndex = 1;
            this.LabelLastName.Text = "Achternaam: ";
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.Location = new System.Drawing.Point(175, 544);
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(555, 27);
            this.TextBoxFirstName.TabIndex = 0;
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.Location = new System.Drawing.Point(175, 577);
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(555, 27);
            this.TextBoxLastName.TabIndex = 0;
            // 
            // TextBoxInsured
            // 
            this.TextBoxInsured.Location = new System.Drawing.Point(390, 494);
            this.TextBoxInsured.Name = "TextBoxInsured";
            this.TextBoxInsured.Size = new System.Drawing.Size(29, 27);
            this.TextBoxInsured.TabIndex = 2;
            // 
            // LabelClientNumber2
            // 
            this.LabelClientNumber2.AutoSize = true;
            this.LabelClientNumber2.Location = new System.Drawing.Point(175, 497);
            this.LabelClientNumber2.Name = "LabelClientNumber2";
            this.LabelClientNumber2.Size = new System.Drawing.Size(57, 20);
            this.LabelClientNumber2.TabIndex = 1;
            this.LabelClientNumber2.Text = "000000";
            // 
            // ButtonUpdateClient
            // 
            this.ButtonUpdateClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonUpdateClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpdateClient.Location = new System.Drawing.Point(869, 561);
            this.ButtonUpdateClient.Name = "ButtonUpdateClient";
            this.ButtonUpdateClient.Size = new System.Drawing.Size(94, 37);
            this.ButtonUpdateClient.TabIndex = 3;
            this.ButtonUpdateClient.Text = "Wijzig";
            this.ButtonUpdateClient.UseVisualStyleBackColor = false;
            this.ButtonUpdateClient.Click += new System.EventHandler(this.ButtonUpdateClient_Click);
            // 
            // LabelErrMsg
            // 
            this.LabelErrMsg.AutoSize = true;
            this.LabelErrMsg.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelErrMsg.ForeColor = System.Drawing.Color.Red;
            this.LabelErrMsg.Location = new System.Drawing.Point(58, 701);
            this.LabelErrMsg.Name = "LabelErrMsg";
            this.LabelErrMsg.Size = new System.Drawing.Size(104, 19);
            this.LabelErrMsg.TabIndex = 4;
            this.LabelErrMsg.Text = "Foutboodschap";
            // 
            // LabelErrorCode
            // 
            this.LabelErrorCode.AutoSize = true;
            this.LabelErrorCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelErrorCode.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorCode.Location = new System.Drawing.Point(58, 679);
            this.LabelErrorCode.Name = "LabelErrorCode";
            this.LabelErrorCode.Size = new System.Drawing.Size(66, 19);
            this.LabelErrorCode.TabIndex = 4;
            this.LabelErrorCode.Text = "Foutcode";
            // 
            // LblZodiac
            // 
            this.LblZodiac.AutoSize = true;
            this.LblZodiac.Location = new System.Drawing.Point(58, 621);
            this.LblZodiac.Name = "LblZodiac";
            this.LblZodiac.Size = new System.Drawing.Size(97, 20);
            this.LblZodiac.TabIndex = 1;
            this.LblZodiac.Text = "Sterrenbeeld:";
            // 
            // TextBoxZodiac
            // 
            this.TextBoxZodiac.Location = new System.Drawing.Point(175, 621);
            this.TextBoxZodiac.Name = "TextBoxZodiac";
            this.TextBoxZodiac.Size = new System.Drawing.Size(244, 27);
            this.TextBoxZodiac.TabIndex = 5;
            // 
            // ComboBoxSportType
            // 
            this.ComboBoxSportType.FormattingEnabled = true;
            this.ComboBoxSportType.Location = new System.Drawing.Point(662, 618);
            this.ComboBoxSportType.Name = "ComboBoxSportType";
            this.ComboBoxSportType.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxSportType.TabIndex = 6;
            // 
            // LabelSportType
            // 
            this.LabelSportType.AutoSize = true;
            this.LabelSportType.Location = new System.Drawing.Point(502, 621);
            this.LabelSportType.Name = "LabelSportType";
            this.LabelSportType.Size = new System.Drawing.Size(81, 20);
            this.LabelSportType.TabIndex = 1;
            this.LabelSportType.Text = "Sport type:";
            // 
            // ColSportType
            // 
            this.ColSportType.Text = "Sport Type";
            this.ColSportType.Width = 100;
            // 
            // FrmClientListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.ComboBoxSportType);
            this.Controls.Add(this.TextBoxZodiac);
            this.Controls.Add(this.LabelErrorCode);
            this.Controls.Add(this.LabelErrMsg);
            this.Controls.Add(this.ButtonUpdateClient);
            this.Controls.Add(this.TextBoxInsured);
            this.Controls.Add(this.TextBoxFirstName);
            this.Controls.Add(this.TextBoxLastName);
            this.Controls.Add(this.LabelLastName);
            this.Controls.Add(this.LabelSportType);
            this.Controls.Add(this.LblZodiac);
            this.Controls.Add(this.LabelFirstName);
            this.Controls.Add(this.LabelIsInsured);
            this.Controls.Add(this.LabelClientNumber2);
            this.Controls.Add(this.LabelClientNumber1);
            this.Controls.Add(this.ListViewClienten);
            this.MaximumSize = new System.Drawing.Size(1500, 800);
            this.MinimumSize = new System.Drawing.Size(1500, 800);
            this.Name = "FrmClientListView";
            this.Text = "Clienten in List View";
            this.Load += new System.EventHandler(this.FrmClientListView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private ListView ListViewClienten; 
        private ColumnHeader ColClientNumber;
        private ColumnHeader ColIsInsured;
        private ColumnHeader ColFirstName;
        private ColumnHeader ColLastName;
        private ColumnHeader ColNrOfInvoices;
        private ColumnHeader ColNrOfCons;
        private ColumnHeader ColFullAddress;
        private Label LabelClientNumber1;
        private Label LabelIsInsured;
        private Label LabelFirstName;
        private Label LabelLastName;
        private TextBox TextBoxInsured;
        private TextBox TextBoxFirstName;
        private TextBox TextBoxLastName;
        private Label LabelClientNumber2;
        private Button ButtonUpdateClient;
        private Label LabelErrMsg;
        private Label LabelErrorCode;
        private ColumnHeader ColZodiacSign;
        private Label LblZodiac;
        private TextBox TextBoxZodiac;
        private ComboBox ComboBoxSportType;
        private Label LabelSportType;
        private ColumnHeader ColSportType;
    }
}

