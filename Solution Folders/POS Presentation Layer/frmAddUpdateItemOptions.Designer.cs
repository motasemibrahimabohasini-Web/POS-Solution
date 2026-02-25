namespace Cash_System
{
    partial class frmAddUpdateItemOptions
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
            this.dgvItemOptions = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.OptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsItemOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemOptions)).BeginInit();
            this.cmsItemOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvItemOptions
            // 
            this.dgvItemOptions.AllowUserToResizeColumns = false;
            this.dgvItemOptions.AllowUserToResizeRows = false;
            this.dgvItemOptions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvItemOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OptionID,
            this.ItemID,
            this.OptionName,
            this.Price});
            this.dgvItemOptions.ContextMenuStrip = this.cmsItemOptions;
            this.dgvItemOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvItemOptions.Location = new System.Drawing.Point(0, 0);
            this.dgvItemOptions.Name = "dgvItemOptions";
            this.dgvItemOptions.RowHeadersWidth = 51;
            this.dgvItemOptions.RowTemplate.Height = 24;
            this.dgvItemOptions.Size = new System.Drawing.Size(658, 405);
            this.dgvItemOptions.TabIndex = 0;
            this.dgvItemOptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemOptions_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::Cash_System.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(305, 413);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OptionID
            // 
            this.OptionID.DataPropertyName = "OptionID";
            this.OptionID.HeaderText = "OptionID";
            this.OptionID.MinimumWidth = 6;
            this.OptionID.Name = "OptionID";
            this.OptionID.Visible = false;
            this.OptionID.Width = 125;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.MinimumWidth = 6;
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            this.ItemID.Width = 125;
            // 
            // OptionName
            // 
            this.OptionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OptionName.DataPropertyName = "OptionName";
            this.OptionName.HeaderText = "Option Name";
            this.OptionName.MinimumWidth = 6;
            this.OptionName.Name = "OptionName";
            this.OptionName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // cmsItemOptions
            // 
            this.cmsItemOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsItemOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsItemOptions.Name = "cmsItemOptions";
            this.cmsItemOptions.Size = new System.Drawing.Size(127, 30);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Cash_System.Properties.Resources.Delete_32;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.toolStripMenuItem1.Text = "Delete";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // frmAddUpdateItemOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvItemOptions);
            this.Name = "frmAddUpdateItemOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateItemOptions";
            this.Load += new System.EventHandler(this.frmAddUpdateItemOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemOptions)).EndInit();
            this.cmsItemOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.ContextMenuStrip cmsItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}