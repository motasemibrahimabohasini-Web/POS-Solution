namespace Cash_System
{
    partial class frmRefundOrder
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
            this.btnRefund = new System.Windows.Forms.Button();
            this.ctrlOrderDetails1 = new Cash_System.ctrlOrderDetails();
            this.SuspendLayout();
            // 
            // btnRefund
            // 
            this.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefund.Image = global::Cash_System.Properties.Resources.Save_32;
            this.btnRefund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefund.Location = new System.Drawing.Point(786, 429);
            this.btnRefund.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(111, 37);
            this.btnRefund.TabIndex = 154;
            this.btnRefund.Text = "Refund";
            this.btnRefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // ctrlOrderDetails1
            // 
            this.ctrlOrderDetails1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlOrderDetails1.Location = new System.Drawing.Point(0, 0);
            this.ctrlOrderDetails1.Name = "ctrlOrderDetails1";
            this.ctrlOrderDetails1.Size = new System.Drawing.Size(953, 421);
            this.ctrlOrderDetails1.TabIndex = 0;
            // 
            // frmRefundOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 536);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.ctrlOrderDetails1);
            this.Name = "frmRefundOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRefundOrder";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlOrderDetails ctrlOrderDetails1;
        private System.Windows.Forms.Button btnRefund;
    }
}