namespace Driving_License_Management.People
{
    partial class frmListPeople
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
            this.lblManage = new System.Windows.Forms.Label();
            this.dgvListpeople = new System.Windows.Forms.DataGridView();
            this.pbPeople = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListpeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManage
            // 
            this.lblManage.AutoSize = true;
            this.lblManage.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManage.Location = new System.Drawing.Point(560, 205);
            this.lblManage.Name = "lblManage";
            this.lblManage.Size = new System.Drawing.Size(250, 40);
            this.lblManage.TabIndex = 1;
            this.lblManage.Text = "Manage People";
            // 
            // dgvListpeople
            // 
            this.dgvListpeople.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListpeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListpeople.Location = new System.Drawing.Point(12, 289);
            this.dgvListpeople.Name = "dgvListpeople";
            this.dgvListpeople.RowHeadersWidth = 51;
            this.dgvListpeople.RowTemplate.Height = 24;
            this.dgvListpeople.Size = new System.Drawing.Size(1347, 358);
            this.dgvListpeople.TabIndex = 2;
            // 
            // pbPeople
            // 
            this.pbPeople.Image = global::Driving_License_Management.Properties.Resources.People_400;
            this.pbPeople.Location = new System.Drawing.Point(585, 12);
            this.pbPeople.Name = "pbPeople";
            this.pbPeople.Size = new System.Drawing.Size(200, 176);
            this.pbPeople.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPeople.TabIndex = 0;
            this.pbPeople.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Nachlieli CLM", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Image = global::Driving_License_Management.Properties.Resources.Add_Person_40;
            this.button1.Location = new System.Drawing.Point(1260, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 61);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Nachlieli CLM", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClose.Image = global::Driving_License_Management.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1213, 665);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 61);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 738);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvListpeople);
            this.Controls.Add(this.lblManage);
            this.Controls.Add(this.pbPeople);
            this.Name = "frmListPeople";
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmListPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListpeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPeople;
        private System.Windows.Forms.Label lblManage;
        private System.Windows.Forms.DataGridView dgvListpeople;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
    }
}