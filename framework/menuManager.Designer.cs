namespace framework
{
	partial class menuManager
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.manageMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.addSibMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.addSubMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.moveUp = new System.Windows.Forms.ToolStripMenuItem();
			this.moveDown = new System.Windows.Forms.ToolStripMenuItem();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
			this.menuStrip1.Size = new System.Drawing.Size(908, 30);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 24);
			this.toolStripMenuItem1.Text = "保存";
			// 
			// treeView1
			// 
			this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(159, 30);
			this.treeView1.Margin = new System.Windows.Forms.Padding(4);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(749, 574);
			this.treeView1.TabIndex = 1;
			this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageMenu,
            this.addSibMenu,
            this.addSubMenu,
            this.toolStripSeparator1,
            this.moveUp,
            this.moveDown});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(176, 158);
			// 
			// manageMenu
			// 
			this.manageMenu.Name = "manageMenu";
			this.manageMenu.Size = new System.Drawing.Size(175, 24);
			this.manageMenu.Text = "菜单管理";
			this.manageMenu.Click += new System.EventHandler(this.addSibAndSubMenu_Click);
			// 
			// addSibMenu
			// 
			this.addSibMenu.Name = "addSibMenu";
			this.addSibMenu.Size = new System.Drawing.Size(175, 24);
			this.addSibMenu.Text = "增加同级菜单";
			this.addSibMenu.Click += new System.EventHandler(this.addSibAndSubMenu_Click);
			// 
			// addSubMenu
			// 
			this.addSubMenu.Name = "addSubMenu";
			this.addSubMenu.Size = new System.Drawing.Size(175, 24);
			this.addSubMenu.Text = "增加子菜单";
			this.addSubMenu.Click += new System.EventHandler(this.addSibAndSubMenu_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
			// 
			// moveUp
			// 
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(175, 24);
			this.moveUp.Text = "上移";
			// 
			// moveDown
			// 
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(175, 24);
			this.moveDown.Text = "下移";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(0, 30);
			this.listBox1.Margin = new System.Windows.Forms.Padding(4);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(159, 574);
			this.listBox1.TabIndex = 2;
			// 
			// menuManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 604);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "menuManager";
			this.Text = "菜单管理";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addSibMenu;
		private System.Windows.Forms.ToolStripMenuItem addSubMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem moveUp;
		private System.Windows.Forms.ToolStripMenuItem moveDown;
		private System.Windows.Forms.ToolStripMenuItem manageMenu;
	}
}