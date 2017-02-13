namespace Placements.src
{
    partial class frmEditDistrict
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDativeDistrict = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameDistrict = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGenitiveDistrict = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.pictureDistrict = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDistrict)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDativeDistrict);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNameDistrict);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGenitiveDistrict);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddImage);
            this.groupBox1.Controls.Add(this.pictureDistrict);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 260);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование района";
            // 
            // txtDativeDistrict
            // 
            this.txtDativeDistrict.Location = new System.Drawing.Point(9, 215);
            this.txtDativeDistrict.Name = "txtDativeDistrict";
            this.txtDativeDistrict.Size = new System.Drawing.Size(383, 20);
            this.txtDativeDistrict.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Наименование района в дательном падеже";
            // 
            // txtNameDistrict
            // 
            this.txtNameDistrict.Location = new System.Drawing.Point(9, 137);
            this.txtNameDistrict.Name = "txtNameDistrict";
            this.txtNameDistrict.Size = new System.Drawing.Size(383, 20);
            this.txtNameDistrict.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "Наименование района в именительном падеже";
            // 
            // txtGenitiveDistrict
            // 
            this.txtGenitiveDistrict.Location = new System.Drawing.Point(9, 176);
            this.txtGenitiveDistrict.Name = "txtGenitiveDistrict";
            this.txtGenitiveDistrict.Size = new System.Drawing.Size(383, 20);
            this.txtGenitiveDistrict.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Наименование района в родительном падеже";
            // 
            // btnAddImage
            // 
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddImage.Location = new System.Drawing.Point(6, 86);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(65, 22);
            this.btnAddImage.TabIndex = 5;
            this.btnAddImage.Text = "Добавить...";
            this.btnAddImage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // pictureDistrict
            // 
            this.pictureDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureDistrict.Location = new System.Drawing.Point(6, 19);
            this.pictureDistrict.Name = "pictureDistrict";
            this.pictureDistrict.Size = new System.Drawing.Size(64, 64);
            this.pictureDistrict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureDistrict.TabIndex = 116;
            this.pictureDistrict.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(261, 289);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(342, 289);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openDialog";
            this.openDialog.Filter = "Изображения|*.png";
            // 
            // frmEditDistrict
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(429, 332);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmEditDistrict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEditDistrict";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDistrict)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtDativeDistrict;
        public System.Windows.Forms.TextBox txtNameDistrict;
        public System.Windows.Forms.TextBox txtGenitiveDistrict;
        public System.Windows.Forms.PictureBox pictureDistrict;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}