namespace Placements.src
{
    partial class frmAdressDepartament
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
            this.OkButton = new System.Windows.Forms.Button();
            this.District = new System.Windows.Forms.ComboBox();
            this.Region = new System.Windows.Forms.ComboBox();
            this.PostIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SettlementName = new System.Windows.Forms.TextBox();
            this.OfficeType = new System.Windows.Forms.ComboBox();
            this.ToponimType = new System.Windows.Forms.ComboBox();
            this.OfficeName = new System.Windows.Forms.TextBox();
            this.Corpus = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Building = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ToponimName = new System.Windows.Forms.TextBox();
            this.SettlementType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grbAdress = new System.Windows.Forms.GroupBox();
            this.btnCancelButton = new System.Windows.Forms.Button();
            this.grbAdress.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OkButton.Location = new System.Drawing.Point(408, 272);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 48;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // District
            // 
            this.District.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.District.FormattingEnabled = true;
            this.District.Location = new System.Drawing.Point(76, 80);
            this.District.Name = "District";
            this.District.Size = new System.Drawing.Size(441, 21);
            this.District.TabIndex = 3;
            // 
            // Region
            // 
            this.Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Region.FormattingEnabled = true;
            this.Region.Location = new System.Drawing.Point(76, 53);
            this.Region.Name = "Region";
            this.Region.Size = new System.Drawing.Size(441, 21);
            this.Region.TabIndex = 2;
            this.Region.SelectedIndexChanged += new System.EventHandler(this.Region_SelectedIndexChanged);
            // 
            // PostIndex
            // 
            this.PostIndex.Location = new System.Drawing.Point(76, 27);
            this.PostIndex.Name = "PostIndex";
            this.PostIndex.Size = new System.Drawing.Size(441, 20);
            this.PostIndex.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Индекс";
            // 
            // SettlementName
            // 
            this.SettlementName.Location = new System.Drawing.Point(76, 107);
            this.SettlementName.MaxLength = 100;
            this.SettlementName.Name = "SettlementName";
            this.SettlementName.Size = new System.Drawing.Size(441, 20);
            this.SettlementName.TabIndex = 5;
            // 
            // OfficeType
            // 
            this.OfficeType.FormattingEnabled = true;
            this.OfficeType.Items.AddRange(new object[] {
            "Офіс",
            "Кв.",
            "Кім."});
            this.OfficeType.Location = new System.Drawing.Point(5, 211);
            this.OfficeType.MaxLength = 50;
            this.OfficeType.Name = "OfficeType";
            this.OfficeType.Size = new System.Drawing.Size(64, 21);
            this.OfficeType.TabIndex = 10;
            // 
            // ToponimType
            // 
            this.ToponimType.FormattingEnabled = true;
            this.ToponimType.Items.AddRange(new object[] {
            "вулиця",
            "площа",
            "провулок",
            "проспект"});
            this.ToponimType.Location = new System.Drawing.Point(6, 133);
            this.ToponimType.MaxLength = 50;
            this.ToponimType.Name = "ToponimType";
            this.ToponimType.Size = new System.Drawing.Size(64, 21);
            this.ToponimType.TabIndex = 6;
            // 
            // OfficeName
            // 
            this.OfficeName.Location = new System.Drawing.Point(75, 211);
            this.OfficeName.MaxLength = 100;
            this.OfficeName.Name = "OfficeName";
            this.OfficeName.Size = new System.Drawing.Size(441, 20);
            this.OfficeName.TabIndex = 11;
            // 
            // Corpus
            // 
            this.Corpus.Location = new System.Drawing.Point(75, 185);
            this.Corpus.MaxLength = 100;
            this.Corpus.Name = "Corpus";
            this.Corpus.Size = new System.Drawing.Size(441, 20);
            this.Corpus.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(27, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Корпус";
            // 
            // Building
            // 
            this.Building.Location = new System.Drawing.Point(75, 159);
            this.Building.MaxLength = 100;
            this.Building.Name = "Building";
            this.Building.Size = new System.Drawing.Size(441, 20);
            this.Building.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(40, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Дом";
            // 
            // ToponimName
            // 
            this.ToponimName.Location = new System.Drawing.Point(75, 133);
            this.ToponimName.MaxLength = 100;
            this.ToponimName.Name = "ToponimName";
            this.ToponimName.Size = new System.Drawing.Size(441, 20);
            this.ToponimName.TabIndex = 7;
            // 
            // SettlementType
            // 
            this.SettlementType.FormattingEnabled = true;
            this.SettlementType.Items.AddRange(new object[] {
            "м.",
            "смт.",
            "с."});
            this.SettlementType.Location = new System.Drawing.Point(6, 106);
            this.SettlementType.MaxLength = 50;
            this.SettlementType.Name = "SettlementType";
            this.SettlementType.Size = new System.Drawing.Size(64, 21);
            this.SettlementType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(32, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Район";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(20, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Область";
            // 
            // grbAdress
            // 
            this.grbAdress.Controls.Add(this.District);
            this.grbAdress.Controls.Add(this.Region);
            this.grbAdress.Controls.Add(this.PostIndex);
            this.grbAdress.Controls.Add(this.label1);
            this.grbAdress.Controls.Add(this.SettlementName);
            this.grbAdress.Controls.Add(this.OfficeType);
            this.grbAdress.Controls.Add(this.ToponimType);
            this.grbAdress.Controls.Add(this.OfficeName);
            this.grbAdress.Controls.Add(this.Corpus);
            this.grbAdress.Controls.Add(this.label8);
            this.grbAdress.Controls.Add(this.Building);
            this.grbAdress.Controls.Add(this.label7);
            this.grbAdress.Controls.Add(this.ToponimName);
            this.grbAdress.Controls.Add(this.SettlementType);
            this.grbAdress.Controls.Add(this.label4);
            this.grbAdress.Controls.Add(this.label3);
            this.grbAdress.Location = new System.Drawing.Point(12, 12);
            this.grbAdress.Name = "grbAdress";
            this.grbAdress.Size = new System.Drawing.Size(552, 250);
            this.grbAdress.TabIndex = 50;
            this.grbAdress.TabStop = false;
            this.grbAdress.Text = "Адрес";
            // 
            // btnCancelButton
            // 
            this.btnCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelButton.Location = new System.Drawing.Point(489, 272);
            this.btnCancelButton.Name = "btnCancelButton";
            this.btnCancelButton.Size = new System.Drawing.Size(75, 23);
            this.btnCancelButton.TabIndex = 49;
            this.btnCancelButton.Text = "Отмена";
            this.btnCancelButton.UseVisualStyleBackColor = true;
            // 
            // frmAdressDepartament
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelButton;
            this.ClientSize = new System.Drawing.Size(576, 307);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.grbAdress);
            this.Controls.Add(this.btnCancelButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdressDepartament";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAdressDepartament";
            this.grbAdress.ResumeLayout(false);
            this.grbAdress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        public System.Windows.Forms.ComboBox District;
        public System.Windows.Forms.ComboBox Region;
        public System.Windows.Forms.TextBox PostIndex;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox SettlementName;
        public System.Windows.Forms.ComboBox OfficeType;
        public System.Windows.Forms.ComboBox ToponimType;
        public System.Windows.Forms.TextBox OfficeName;
        public System.Windows.Forms.TextBox Corpus;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox Building;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox ToponimName;
        public System.Windows.Forms.ComboBox SettlementType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbAdress;
        private System.Windows.Forms.Button btnCancelButton;
    }
}