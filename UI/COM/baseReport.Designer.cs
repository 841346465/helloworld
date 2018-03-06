namespace UI.COM {
	partial class baseReport {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnNewRecord = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(812, 491);
			this.dataGridView1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnDelete);
			this.groupBox1.Controls.Add(this.btnNewRecord);
			this.groupBox1.Controls.Add(this.btnModify);
			this.groupBox1.Controls.Add(this.btnQuery);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(812, 97);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnQuery
			// 
			this.btnQuery.Location = new System.Drawing.Point(32, 47);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(75, 23);
			this.btnQuery.TabIndex = 0;
			this.btnQuery.Text = "查询";
			this.btnQuery.UseVisualStyleBackColor = true;
			// 
			// btnModify
			// 
			this.btnModify.Location = new System.Drawing.Point(294, 47);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(75, 23);
			this.btnModify.TabIndex = 0;
			this.btnModify.Text = "修改";
			this.btnModify.UseVisualStyleBackColor = true;
			// 
			// btnNewRecord
			// 
			this.btnNewRecord.Location = new System.Drawing.Point(165, 47);
			this.btnNewRecord.Name = "btnNewRecord";
			this.btnNewRecord.Size = new System.Drawing.Size(75, 23);
			this.btnNewRecord.TabIndex = 0;
			this.btnNewRecord.Text = "新增";
			this.btnNewRecord.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(430, 47);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 0;
			this.btnDelete.Text = "删除";
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// baseReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "baseReport";
			this.Size = new System.Drawing.Size(812, 491);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnNewRecord;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnQuery;
	}
}
