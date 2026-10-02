namespace telasSCAI
{
    partial class fmPesquisar
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
            this.checkData = new System.Windows.Forms.RadioButton();
            this.checknome = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.BoxNome = new System.Windows.Forms.TextBox();
            this.NEvento = new System.Windows.Forms.Label();
            this.dateEvento = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBoxPesq = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimeMes = new System.Windows.Forms.DateTimePicker();
            this.radiomes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radiotipo = new System.Windows.Forms.RadioButton();
            this.combotipo = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkData
            // 
            this.checkData.AutoSize = true;
            this.checkData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkData.Location = new System.Drawing.Point(301, 95);
            this.checkData.Margin = new System.Windows.Forms.Padding(4);
            this.checkData.Name = "checkData";
            this.checkData.Size = new System.Drawing.Size(134, 19);
            this.checkData.TabIndex = 15;
            this.checkData.Text = "Pesquisar por Data";
            this.checkData.UseVisualStyleBackColor = false;
            this.checkData.CheckedChanged += new System.EventHandler(this.checkData_CheckedChanged);
            // 
            // checknome
            // 
            this.checknome.AutoSize = true;
            this.checknome.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checknome.Checked = true;
            this.checknome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checknome.Location = new System.Drawing.Point(146, 95);
            this.checknome.Margin = new System.Windows.Forms.Padding(4);
            this.checknome.Name = "checknome";
            this.checknome.Size = new System.Drawing.Size(141, 19);
            this.checknome.TabIndex = 14;
            this.checknome.TabStop = true;
            this.checknome.Text = "Pesquisar por Nome";
            this.checknome.UseVisualStyleBackColor = false;
            this.checknome.CheckedChanged += new System.EventHandler(this.checknome_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(819, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BoxNome
            // 
            this.BoxNome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxNome.Location = new System.Drawing.Point(147, 59);
            this.BoxNome.Margin = new System.Windows.Forms.Padding(4);
            this.BoxNome.Name = "BoxNome";
            this.BoxNome.Size = new System.Drawing.Size(669, 22);
            this.BoxNome.TabIndex = 12;
            // 
            // NEvento
            // 
            this.NEvento.AutoSize = true;
            this.NEvento.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NEvento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEvento.Location = new System.Drawing.Point(24, 62);
            this.NEvento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NEvento.Name = "NEvento";
            this.NEvento.Size = new System.Drawing.Size(115, 16);
            this.NEvento.TabIndex = 11;
            this.NEvento.Text = "Nome do Evento:";
            // 
            // dateEvento
            // 
            this.dateEvento.Checked = false;
            this.dateEvento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEvento.Location = new System.Drawing.Point(163, 59);
            this.dateEvento.Margin = new System.Windows.Forms.Padding(4);
            this.dateEvento.MinDate = new System.DateTime(2000, 12, 31, 0, 0, 0, 0);
            this.dateEvento.Name = "dateEvento";
            this.dateEvento.Size = new System.Drawing.Size(135, 22);
            this.dateEvento.TabIndex = 10;
            this.dateEvento.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar1.Location = new System.Drawing.Point(15, 47);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(928, 82);
            this.progressBar1.TabIndex = 8;
            // 
            // listBoxPesq
            // 
            this.listBoxPesq.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxPesq.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPesq.FormattingEnabled = true;
            this.listBoxPesq.IntegralHeight = false;
            this.listBoxPesq.ItemHeight = 19;
            this.listBoxPesq.Location = new System.Drawing.Point(16, 140);
            this.listBoxPesq.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.listBoxPesq.Name = "listBoxPesq";
            this.listBoxPesq.ScrollAlwaysVisible = true;
            this.listBoxPesq.Size = new System.Drawing.Size(927, 315);
            this.listBoxPesq.TabIndex = 16;
            this.listBoxPesq.DoubleClick += new System.EventHandler(this.listBoxPesq_DoubleClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Crimson;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(16, 467);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 48);
            this.button4.TabIndex = 110;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimeMes
            // 
            this.dateTimeMes.CustomFormat = "M/yyyy";
            this.dateTimeMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeMes.Location = new System.Drawing.Point(163, 59);
            this.dateTimeMes.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeMes.Name = "dateTimeMes";
            this.dateTimeMes.Size = new System.Drawing.Size(123, 22);
            this.dateTimeMes.TabIndex = 116;
            // 
            // radiomes
            // 
            this.radiomes.AutoSize = true;
            this.radiomes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radiomes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiomes.Location = new System.Drawing.Point(452, 95);
            this.radiomes.Margin = new System.Windows.Forms.Padding(4);
            this.radiomes.Name = "radiomes";
            this.radiomes.Size = new System.Drawing.Size(132, 19);
            this.radiomes.TabIndex = 117;
            this.radiomes.Text = "Pesquisar por Mês";
            this.radiomes.UseVisualStyleBackColor = false;
            this.radiomes.CheckedChanged += new System.EventHandler(this.radiomes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(322, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 24);
            this.label1.TabIndex = 118;
            this.label1.Text = "◤ PESQUISAR EVENTOS◢";
            // 
            // radiotipo
            // 
            this.radiotipo.AutoSize = true;
            this.radiotipo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radiotipo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiotipo.Location = new System.Drawing.Point(595, 95);
            this.radiotipo.Margin = new System.Windows.Forms.Padding(4);
            this.radiotipo.Name = "radiotipo";
            this.radiotipo.Size = new System.Drawing.Size(132, 19);
            this.radiotipo.TabIndex = 119;
            this.radiotipo.Text = "Pesquisar por Tipo";
            this.radiotipo.UseVisualStyleBackColor = false;
            this.radiotipo.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // combotipo
            // 
            this.combotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotipo.FormattingEnabled = true;
            this.combotipo.Items.AddRange(new object[] {
            "Social",
            "Lazer",
            "Show",
            "Festa ",
            "Cultural",
            "Entretenimento   ",
            "Palestra",
            "Workshops",
            "Cursos",
            "Acadêmico",
            "Científico  ",
            "Reunião ",
            "Teatro",
            "Stand-up",
            "Esporte  ",
            "Feira",
            "Exposição",
            "Casamento",
            "Formatura   ",
            "Religioso",
            "Culto",
            "Outro"});
            this.combotipo.Location = new System.Drawing.Point(147, 58);
            this.combotipo.Name = "combotipo";
            this.combotipo.Size = new System.Drawing.Size(121, 24);
            this.combotipo.TabIndex = 205;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(739, 465);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 47);
            this.button2.TabIndex = 206;
            this.button2.Text = "Eventos Passados";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fmPesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(960, 528);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BoxNome);
            this.Controls.Add(this.combotipo);
            this.Controls.Add(this.radiotipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPesq);
            this.Controls.Add(this.radiomes);
            this.Controls.Add(this.dateTimeMes);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkData);
            this.Controls.Add(this.checknome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NEvento);
            this.Controls.Add(this.dateEvento);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmPesquisar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton checkData;
        private System.Windows.Forms.RadioButton checknome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox BoxNome;
        private System.Windows.Forms.Label NEvento;
        private System.Windows.Forms.DateTimePicker dateEvento;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBoxPesq;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimeMes;
        private System.Windows.Forms.RadioButton radiomes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radiotipo;
        private System.Windows.Forms.ComboBox combotipo;
        private System.Windows.Forms.Button button2;
    }
}