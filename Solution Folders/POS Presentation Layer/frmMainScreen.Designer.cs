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
            this.btnMenuItems = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.SideParTransition = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.button2 = new System.Windows.Forms.Button();
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
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.guna2CircleButton1);
            this.panel1.Controls.Add(this.btnHam);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnHam
            // 
            resources.ApplyResources(this.btnHam, "btnHam");
            this.btnHam.Name = "btnHam";
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // Sidebar
            // 
            this.Sidebar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Sidebar.Controls.Add(this.pnCashScreen);
            this.Sidebar.Controls.Add(this.pnEmployees);
            this.Sidebar.Controls.Add(this.btnEmployees);
            this.Sidebar.Controls.Add(this.pnOrders);
            this.Sidebar.Controls.Add(this.btnOrders);
            this.Sidebar.Controls.Add(this.button1);
            this.Sidebar.Controls.Add(this.pnMenuItems);
            this.Sidebar.Controls.Add(this.pnUsers);
            this.Sidebar.Controls.Add(this.btnAccountSettings);
            resources.ApplyResources(this.Sidebar, "Sidebar");
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.Sidebar_Paint);
            // 
            // pnCashScreen
            // 
            this.pnCashScreen.Controls.Add(this.btnCashScreen);
            resources.ApplyResources(this.pnCashScreen, "pnCashScreen");
            this.pnCashScreen.Name = "pnCashScreen";
            // 
            // btnCashScreen
            // 
            this.btnCashScreen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnCashScreen, "btnCashScreen");
            this.btnCashScreen.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCashScreen.Name = "btnCashScreen";
            this.btnCashScreen.UseVisualStyleBackColor = false;
            this.btnCashScreen.Click += new System.EventHandler(this.btnCashScreen_Click);
            // 
            // pnEmployees
            // 
            this.pnEmployees.Controls.Add(this.btnUser);
            resources.ApplyResources(this.pnEmployees, "pnEmployees");
            this.pnEmployees.Name = "pnEmployees";
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnUser, "btnUser");
            this.btnUser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUser.Name = "btnUser";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // pnOrders
            // 
            this.pnOrders.Controls.Add(this.button2);
            resources.ApplyResources(this.pnOrders, "pnOrders");
            this.pnOrders.Name = "pnOrders";
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnEmployees, "btnEmployees");
            this.btnEmployees.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // pnMenuItems
            // 
            this.pnMenuItems.Controls.Add(this.btnMenuItems);
            resources.ApplyResources(this.pnMenuItems, "pnMenuItems");
            this.pnMenuItems.Name = "pnMenuItems";
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnOrders, "btnOrders");
            this.btnOrders.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnUsers
            // 
            this.pnUsers.Controls.Add(this.btnCategories);
            resources.ApplyResources(this.pnUsers, "pnUsers");
            this.pnUsers.Name = "pnUsers";
            // 
            // btnMenuItems
            // 
            this.btnMenuItems.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnMenuItems, "btnMenuItems");
            this.btnMenuItems.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMenuItems.Name = "btnMenuItems";
            this.btnMenuItems.UseVisualStyleBackColor = false;
            this.btnMenuItems.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnCategories, "btnCategories");
            this.btnCategories.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.button2_Click);
            // 
            // SideParTransition
            // 
            this.SideParTransition.Interval = 10;
            this.SideParTransition.Tick += new System.EventHandler(this.SideParTransition_Tick);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnAccountSettings, "btnAccountSettings");
            this.btnAccountSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.UseVisualStyleBackColor = false;
            // 
            // guna2CircleButton1
            // 
            resources.ApplyResources(this.guna2CircleButton1, "guna2CircleButton1");
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.FillColor = System.Drawing.SystemColors.Control;
            this.guna2CircleButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Image = global::Cash_System.Properties.Resources.CloseBlack;
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.UseTransparentBackground = true;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // frmMainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmMainScreen";
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
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
        private System.Windows.Forms.Button btnCategories;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAccountSettings;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Button button2;
    }
}