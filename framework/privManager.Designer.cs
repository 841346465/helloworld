namespace framework {
	partial class privManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.browse = new System.Windows.Forms.Button();
			this.tbxMenuName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblHint = new System.Windows.Forms.Label();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.canOpen = new System.Windows.Forms.RadioButton();
			this.cannotOpen = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// browse
			// 
			this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse.Location = new System.Drawing.Point(396, 17);
			this.browse.Margin = new System.Windows.Forms.Padding(4);
			this.browse.Name = "browse";
			this.browse.Size = new System.Drawing.Size(100, 37);
			this.browse.TabIndex = 0;
			this.browse.Text = "浏览";
			this.browse.UseVisualStyleBackColor = true;
			this.browse.Click += new System.EventHandler(this.browse_Click);
			// 
			// tbxMenuName
			// 
			this.tbxMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbxMenuName.Location = new System.Drawing.Point(108, 23);
			this.tbxMenuName.Margin = new System.Windows.Forms.Padding(4);
			this.tbxMenuName.MinimumSize = new System.Drawing.Size(132, 4);
			this.tbxMenuName.Name = "tbxMenuName";
			this.tbxMenuName.Size = new System.Drawing.Size(263, 22);
			this.tbxMenuName.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(328, 493);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(73, 33);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(421, 492);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 33);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "菜单名称：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 75);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "哪些用户可以使用";
			// 
			// lblHint
			// 
			this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHint.AutoSize = true;
			this.lblHint.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lblHint.Location = new System.Drawing.Point(16, 501);
			this.lblHint.Name = "lblHint";
			this.lblHint.Size = new System.Drawing.Size(78, 17);
			this.lblHint.TabIndex = 4;
			this.lblHint.Text = "未选择组件";
			this.lblHint.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(15, 108);
			this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(477, 361);
			this.checkedListBox1.TabIndex = 7;
			// 
			// canOpen
			// 
			this.canOpen.AutoSize = true;
			this.canOpen.Checked = true;
			this.canOpen.Location = new System.Drawing.Point(302, 73);
			this.canOpen.Name = "canOpen";
			this.canOpen.Size = new System.Drawing.Size(85, 21);
			this.canOpen.TabIndex = 8;
			this.canOpen.TabStop = true;
			this.canOpen.Text = "添加功能";
			this.canOpen.UseVisualStyleBackColor = true;
			this.canOpen.CheckedChanged += new System.EventHandler(this.canOpen_CheckedChanged);
			// 
			// cannotOpen
			// 
			this.cannotOpen.AutoSize = true;
			this.cannotOpen.Location = new System.Drawing.Point(407, 73);
			this.cannotOpen.Name = "cannotOpen";
			this.cannotOpen.Size = new System.Drawing.Size(85, 21);
			this.cannotOpen.TabIndex = 8;
			this.cannotOpen.Text = "添加目录";
			this.cannotOpen.UseVisualStyleBackColor = true;
			// 
			// privManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 541);
			this.Controls.Add(this.cannotOpen);
			this.Controls.Add(this.canOpen);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblHint);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tbxMenuName);
			this.Controls.Add(this.browse);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(526, 515);
			this.Name = "privManager";
			this.Text = "菜单权限";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.TextBox tbxMenuName;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblHint;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.RadioButton canOpen;
		private System.Windows.Forms.RadioButton cannotOpen;
	}
}