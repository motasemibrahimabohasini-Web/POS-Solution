namespace Cash_System
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.Sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnCashScreen = new System.Windows.Forms.Panel();
            this.btnCashScreen = new System.Windows.Forms.Button();
            this.pnEmployees = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.pnOrders = new System.Windows.Forms.Panel();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.pnMenuItems = new System.Windows.Forms.Panel();
            this.btnOrders = new System.Windows.Forms.Button();
            this.pnUsers = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMenuItems = new System.Windows.Forms.Button();
            this.SideParTransition = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.Sidebar.SuspendLayout();
            this.pnCashScreen.SuspendLayout();
            this.pnEmployees.SuspendLayout();
            this.pnOrders.SuspendLayout();
            this.pnMenuItems.SuspendLayout();
            this.pnUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnHam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 33);
            this.panel1.TabIndex = 0;
            // 
            // btnHam
            // 
            this.btnHam.Image = ((System.Drawing.Image)(resources.GetObject("btnHam.Image")));
            this.btnHam.Location = new System.Drawing.Point(12, 2);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(46, 31);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHam.TabIndex = 1;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // Sidebar
            // 
            this.Sidebar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Sidebar.Controls.Add(this.pnCashScreen);
            this.Sidebar.Controls.Add(this.pnEmployees);
            this.Sidebar.Controls.Add(this.pnOrders);
            this.Sidebar.Controls.Add(this.pnMenuItems);
            this.Sidebar.Controls.Add(this.pnUsers);
            this.Sidebar.Controls.Add(this.button2);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Sidebar.Location = new System.Drawing.Point(0, 33);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.Sidebar.Size = new System.Drawing.Size(262, 594);
            this.Sidebar.TabIndex = 1;
            this.Sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.Sidebar_Paint);
            // 
            // pnCashScreen
            // 
            this.pnCashScreen.Controls.Add(this.btnCashScreen);
            this.pnCashScreen.Location = new System.Drawing.Point(3, 33);
            this.pnCashScreen.Name = "pnCashScreen";
            this.pnCashScreen.Size = new System.Drawing.Size(257, 61);
            this.pnCashScreen.TabIndex = 6;
            // 
            // btnCashScreen
            // 
            this.btnCashScreen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCashScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCashScreen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashScreen.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCashScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnCashScreen.Image")));
            this.btnCashScreen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashScreen.Location = new System.Drawing.Point(4, 0);
            this.btnCashScreen.Name = "btnCashScreen";
            this.btnCashScreen.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCashScreen.Size = new System.Drawing.Size(253, 61);
            this.btnCashScreen.TabIndex = 2;
            this.btnCashScreen.Text = "              POS Item Selector";
            this.btnCashScreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashScreen.UseVisualStyleBackColor = false;
            this.btnCashScreen.Click += new System.EventHandler(this.btnCashScreen_Click);
            // 
            // pnEmployees
            // 
            this.pnEmployees.Controls.Add(this.btnUser);
            this.pnEmployees.Location = new System.Drawing.Point(3, 100);
            this.pnEmployees.Name = "pnEmployees";
            this.pnEmployees.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnEmployees.Size = new System.Drawing.Size(257, 61);
            this.pnEmployees.TabIndex = 6;
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(1, 3);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(253, 61);
            this.btnUser.TabIndex = 2;
            this.btnUser.Text = "               Users";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // pnOrders
            // 
            this.pnOrders.Controls.Add(this.btnEmployees);
            this.pnOrders.Location = new System.Drawing.Point(3, 167);
            this.pnOrders.Name = "pnOrders";
            this.pnOrders.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnOrders.Size = new System.Drawing.Size(257, 61);
            this.pnOrders.TabIndex = 5;
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployees.Image")));
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(1, 3);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(253, 61);
            this.btnEmployees.TabIndex = 2;
            this.btnEmployees.Text = "               Employees";
            this.btnEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // pnMenuItems
            // 
            this.pnMenuItems.Controls.Add(this.btnOrders);
            this.pnMenuItems.Location = new System.Drawing.Point(3, 234);
            this.pnMenuItems.Name = "pnMenuItems";
            this.pnMenuItems.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnMenuItems.Size = new System.Drawing.Size(257, 61);
            this.pnMenuItems.TabIndex = 3;
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnOrders.Image")));
            this.btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.Location = new System.Drawing.Point(0, -3);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnOrders.Size = new System.Drawing.Size(253, 61);
            this.btnOrders.TabIndex = 2;
            this.btnOrders.Text = "               Orders";
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnUsers
            // 
            this.pnUsers.Controls.Add(this.btnMenuItems);
            this.pnUsers.Location = new System.Drawing.Point(3, 301);
            this.pnUsers.Name = "pnUsers";
            this.pnUsers.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnUsers.Size = new System.Drawing.Size(257, 61);
            this.pnUsers.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 368);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(253, 61);
            this.button2.TabIndex = 4;
            this.button2.Text = "               Categories";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMenuItems
            // 
            this.btnMenuItems.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMenuItems.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenuItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuItems.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMenuItems.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuItems.Image")));
            this.btnMenuItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuItems.Location = new System.Drawing.Point(6, 0);
            this.btnMenuItems.Name = "btnMenuItems";
            this.btnMenuItems.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMenuItems.Size = new System.Drawing.Size(253, 61);
            this.btnMenuItems.TabIndex = 2;
            this.btnMenuItems.Text = "               Items";
            this.btnMenuItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuItems.UseVisualStyleBackColor = false;
            this.btnMenuItems.Click += new System.EventHandler(this.button1_Click);
            // 
            // SideParTransition
            // 
            this.SideParTransition.Interval = 10;
            this.SideParTransition.Tick += new System.EventHandler(this.SideParTransition_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1273, 627);
            this.Controls.Add(this.Sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.Sidebar.ResumeLayout(false);
            this.pnCashScreen.ResumeLayout(false);
            this.pnEmployees.ResumeLayout(false);
            this.pnOrders.ResumeLayout(false);
            this.pnMenuItems.ResumeLayout(false);
            this.pnUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnHam;
        private System.Windows.Forms.FlowLayoutPanel Sidebar;
        private System.Windows.Forms.Button btnMenuItems;
        private System.Windows.Forms.Panel pnMenuItems;
        private System.Windows.Forms.Panel pnUsers;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel pnOrders;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Panel pnEmployees;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Panel pnCashScreen;
        private System.Windows.Forms.Button btnCashScreen;
        private System.Windows.Forms.Timer SideParTransition;
        private System.Windows.Forms.Button button2;
    }
}