using System.Windows.Forms;

namespace FormsAppZiekenhuis
{
    partial class FrmMainMenu
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemClienten = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClientListView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDragListBoxToListBox = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLanden = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLandenListBox = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemClienten,
            this.MenuItemLanden});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1484, 40);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // MenuItemClienten
            // 
            this.MenuItemClienten.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemClientListView,
            this.MenuItemDragListBoxToListBox});
            this.MenuItemClienten.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuItemClienten.Name = "MenuItemClienten";
            this.MenuItemClienten.Size = new System.Drawing.Size(117, 36);
            this.MenuItemClienten.Text = "Clienten";
            // 
            // MenuItemClientListView
            // 
            this.MenuItemClientListView.Name = "MenuItemClientListView";
            this.MenuItemClientListView.Size = new System.Drawing.Size(464, 36);
            this.MenuItemClientListView.Text = "Clienten in List View";
            this.MenuItemClientListView.Click += new System.EventHandler(this.MenuItemClientListView_Click);
            // 
            // MenuItemDragListBoxToListBox
            // 
            this.MenuItemDragListBoxToListBox.Name = "MenuItemDragListBoxToListBox";
            this.MenuItemDragListBoxToListBox.Size = new System.Drawing.Size(464, 36);
            this.MenuItemDragListBoxToListBox.Text = "Drag Clienten ListBox naar ListBox";
            this.MenuItemDragListBoxToListBox.Click += new System.EventHandler(this.MenuItemDragListBoxToListBox_Click);
            // 
            // MenuItemLanden
            // 
            this.MenuItemLanden.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLandenListBox});
            this.MenuItemLanden.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuItemLanden.Name = "MenuItemLanden";
            this.MenuItemLanden.Size = new System.Drawing.Size(106, 36);
            this.MenuItemLanden.Text = "Landen";
            // 
            // MenuItemLandenListBox
            // 
            this.MenuItemLandenListBox.Name = "MenuItemLandenListBox";
            this.MenuItemLandenListBox.Size = new System.Drawing.Size(268, 36);
            this.MenuItemLandenListBox.Text = "Landen List Box";
            this.MenuItemLandenListBox.Click += new System.EventHandler(this.MenuItemCountryListBox_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 761);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MaximumSize = new System.Drawing.Size(1500, 800);
            this.MinimumSize = new System.Drawing.Size(1500, 800);
            this.Name = "FrmMainMenu";
            this.Text = "Hoofdmenu";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem MenuItemClienten;
        private ToolStripMenuItem MenuItemClientListView;
        private ToolStripMenuItem MenuItemLanden;
        private ToolStripMenuItem MenuItemLandenListBox;
        private ToolStripMenuItem MenuItemDragListBoxToListBox;
    }
}

