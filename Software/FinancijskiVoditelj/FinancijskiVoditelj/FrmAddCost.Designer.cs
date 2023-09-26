namespace FinancijskiVoditelj
{
    partial class FrmAddCost
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
            this.lblAddCategoryCost = new System.Windows.Forms.Label();
            this.btnAddSaveCost = new System.Windows.Forms.Button();
            this.cboAddCategoryCost = new System.Windows.Forms.ComboBox();
            this.lblAddTypeCost = new System.Windows.Forms.Label();
            this.lblAddDescriptionCost = new System.Windows.Forms.Label();
            this.lblAddPriceCost = new System.Windows.Forms.Label();
            this.cboAddTypeCost = new System.Windows.Forms.ComboBox();
            this.txtAddDescriptionCost = new System.Windows.Forms.TextBox();
            this.txtAddPriceCost = new System.Windows.Forms.TextBox();
            this.btnAddCancelCost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddCategoryCost
            // 
            this.lblAddCategoryCost.AutoSize = true;
            this.lblAddCategoryCost.Location = new System.Drawing.Point(12, 37);
            this.lblAddCategoryCost.Name = "lblAddCategoryCost";
            this.lblAddCategoryCost.Size = new System.Drawing.Size(111, 16);
            this.lblAddCategoryCost.TabIndex = 0;
            this.lblAddCategoryCost.Text = "Kategorija troška:";
            // 
            // btnAddSaveCost
            // 
            this.btnAddSaveCost.Location = new System.Drawing.Point(251, 480);
            this.btnAddSaveCost.Name = "btnAddSaveCost";
            this.btnAddSaveCost.Size = new System.Drawing.Size(81, 23);
            this.btnAddSaveCost.TabIndex = 1;
            this.btnAddSaveCost.Text = "Spremi";
            this.btnAddSaveCost.UseVisualStyleBackColor = true;
            this.btnAddSaveCost.Click += new System.EventHandler(this.btnAddSaveCost_Click);
            // 
            // cboAddCategoryCost
            // 
            this.cboAddCategoryCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAddCategoryCost.FormattingEnabled = true;
            this.cboAddCategoryCost.Location = new System.Drawing.Point(147, 34);
            this.cboAddCategoryCost.Name = "cboAddCategoryCost";
            this.cboAddCategoryCost.Size = new System.Drawing.Size(231, 24);
            this.cboAddCategoryCost.TabIndex = 2;
            this.cboAddCategoryCost.SelectedIndexChanged += new System.EventHandler(this.cboAddCategoryCost_SelectedIndexChanged);
            // 
            // lblAddTypeCost
            // 
            this.lblAddTypeCost.AutoSize = true;
            this.lblAddTypeCost.Location = new System.Drawing.Point(12, 104);
            this.lblAddTypeCost.Name = "lblAddTypeCost";
            this.lblAddTypeCost.Size = new System.Drawing.Size(81, 16);
            this.lblAddTypeCost.TabIndex = 3;
            this.lblAddTypeCost.Text = "Vrsta troška:";
            // 
            // lblAddDescriptionCost
            // 
            this.lblAddDescriptionCost.AutoSize = true;
            this.lblAddDescriptionCost.Location = new System.Drawing.Point(12, 179);
            this.lblAddDescriptionCost.Name = "lblAddDescriptionCost";
            this.lblAddDescriptionCost.Size = new System.Drawing.Size(35, 16);
            this.lblAddDescriptionCost.TabIndex = 4;
            this.lblAddDescriptionCost.Text = "Opis";
            // 
            // lblAddPriceCost
            // 
            this.lblAddPriceCost.AutoSize = true;
            this.lblAddPriceCost.Location = new System.Drawing.Point(12, 349);
            this.lblAddPriceCost.Name = "lblAddPriceCost";
            this.lblAddPriceCost.Size = new System.Drawing.Size(41, 16);
            this.lblAddPriceCost.TabIndex = 5;
            this.lblAddPriceCost.Text = "Iznos:";
            // 
            // cboAddTypeCost
            // 
            this.cboAddTypeCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAddTypeCost.FormattingEnabled = true;
            this.cboAddTypeCost.Location = new System.Drawing.Point(147, 101);
            this.cboAddTypeCost.Name = "cboAddTypeCost";
            this.cboAddTypeCost.Size = new System.Drawing.Size(231, 24);
            this.cboAddTypeCost.TabIndex = 7;
            // 
            // txtAddDescriptionCost
            // 
            this.txtAddDescriptionCost.Location = new System.Drawing.Point(147, 179);
            this.txtAddDescriptionCost.Multiline = true;
            this.txtAddDescriptionCost.Name = "txtAddDescriptionCost";
            this.txtAddDescriptionCost.Size = new System.Drawing.Size(231, 132);
            this.txtAddDescriptionCost.TabIndex = 8;
            // 
            // txtAddPriceCost
            // 
            this.txtAddPriceCost.Location = new System.Drawing.Point(147, 346);
            this.txtAddPriceCost.Multiline = true;
            this.txtAddPriceCost.Name = "txtAddPriceCost";
            this.txtAddPriceCost.Size = new System.Drawing.Size(231, 26);
            this.txtAddPriceCost.TabIndex = 9;
            this.txtAddPriceCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAddCancelCost
            // 
            this.btnAddCancelCost.Location = new System.Drawing.Point(394, 480);
            this.btnAddCancelCost.Name = "btnAddCancelCost";
            this.btnAddCancelCost.Size = new System.Drawing.Size(84, 23);
            this.btnAddCancelCost.TabIndex = 11;
            this.btnAddCancelCost.Text = "Odustani";
            this.btnAddCancelCost.UseVisualStyleBackColor = true;
            this.btnAddCancelCost.Click += new System.EventHandler(this.btnAddCancelCost_Click);
            // 
            // FrmAddCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 551);
            this.Controls.Add(this.btnAddCancelCost);
            this.Controls.Add(this.txtAddPriceCost);
            this.Controls.Add(this.txtAddDescriptionCost);
            this.Controls.Add(this.cboAddTypeCost);
            this.Controls.Add(this.lblAddPriceCost);
            this.Controls.Add(this.lblAddDescriptionCost);
            this.Controls.Add(this.lblAddTypeCost);
            this.Controls.Add(this.cboAddCategoryCost);
            this.Controls.Add(this.btnAddSaveCost);
            this.Controls.Add(this.lblAddCategoryCost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje troška";
            this.Load += new System.EventHandler(this.FrmAddCost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddCategoryCost;
        private System.Windows.Forms.Button btnAddSaveCost;
        private System.Windows.Forms.ComboBox cboAddCategoryCost;
        private System.Windows.Forms.Label lblAddTypeCost;
        private System.Windows.Forms.Label lblAddDescriptionCost;
        private System.Windows.Forms.Label lblAddPriceCost;
        private System.Windows.Forms.ComboBox cboAddTypeCost;
        private System.Windows.Forms.TextBox txtAddDescriptionCost;
        private System.Windows.Forms.TextBox txtAddPriceCost;
        private System.Windows.Forms.Button btnAddCancelCost;
    }
}