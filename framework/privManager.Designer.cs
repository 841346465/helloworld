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
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
			this.browse = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// browse
			// 
			this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse.Location = new System.Drawing.Point(294, 12);
			this.browse.Name = "browse";
			this.browse.Size = new System.Drawing.Size(75, 28);
			this.browse.TabIndex = 0;
			this.browse.Text = "浏览";
			this.browse.UseVisualStyleBackColor = true;
			this.browse.Click += new System.EventHandler(this.browse_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
			this.listView1.Location = new System.Drawing.Point(2, 106);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(381, 254);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.SmallIcon;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(12, 17);
			this.textBox1.MinimumSize = new System.Drawing.Size(100, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(260, 21);
			this.textBox1.TabIndex = 2;
			// 
			// privManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 361);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.browse);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "privManager";
			this.Text = "privManager";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.TextBox textBox1;
	}
}