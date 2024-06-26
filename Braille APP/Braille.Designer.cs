namespace Braille_APP
{
    partial class Braille
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpbConnection = new System.Windows.Forms.GroupBox();
            this.cbbHandshake = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblHandShake = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbbParity = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cbbDataSize = new System.Windows.Forms.ComboBox();
            this.cbbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblDataSize = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.cbbComPorts = new System.Windows.Forms.ComboBox();
            this.gpbText = new System.Windows.Forms.GroupBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.errpCon = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_Traduzir = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gpbConnection.SuspendLayout();
            this.gpbText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpCon)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salvarComoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salvarComoToolStripMenuItem
            // 
            this.salvarComoToolStripMenuItem.Name = "salvarComoToolStripMenuItem";
            this.salvarComoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salvarComoToolStripMenuItem.Text = "Salvar Como";
            this.salvarComoToolStripMenuItem.Click += new System.EventHandler(this.salvarComoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // gpbConnection
            // 
            this.gpbConnection.Controls.Add(this.cbbHandshake);
            this.gpbConnection.Controls.Add(this.button1);
            this.gpbConnection.Controls.Add(this.cbbMode);
            this.gpbConnection.Controls.Add(this.lblMode);
            this.gpbConnection.Controls.Add(this.lblHandShake);
            this.gpbConnection.Controls.Add(this.btnConnect);
            this.gpbConnection.Controls.Add(this.cbbParity);
            this.gpbConnection.Controls.Add(this.lblParity);
            this.gpbConnection.Controls.Add(this.cbbDataSize);
            this.gpbConnection.Controls.Add(this.cbbBaudRate);
            this.gpbConnection.Controls.Add(this.lblDataSize);
            this.gpbConnection.Controls.Add(this.lblBaudRate);
            this.gpbConnection.Controls.Add(this.lblCom);
            this.gpbConnection.Controls.Add(this.cbbComPorts);
            this.gpbConnection.Location = new System.Drawing.Point(12, 41);
            this.gpbConnection.Name = "gpbConnection";
            this.gpbConnection.Size = new System.Drawing.Size(776, 92);
            this.gpbConnection.TabIndex = 3;
            this.gpbConnection.TabStop = false;
            this.gpbConnection.Text = "Conexão";
            // 
            // cbbHandshake
            // 
            this.cbbHandshake.BackColor = System.Drawing.SystemColors.Info;
            this.cbbHandshake.FormattingEnabled = true;
            this.cbbHandshake.Location = new System.Drawing.Point(505, 26);
            this.cbbHandshake.Name = "cbbHandshake";
            this.cbbHandshake.Size = new System.Drawing.Size(101, 21);
            this.cbbHandshake.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 22);
            this.button1.TabIndex = 15;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbbMode
            // 
            this.cbbMode.BackColor = System.Drawing.SystemColors.Info;
            this.cbbMode.FormattingEnabled = true;
            this.cbbMode.Location = new System.Drawing.Point(505, 55);
            this.cbbMode.Name = "cbbMode";
            this.cbbMode.Size = new System.Drawing.Size(101, 21);
            this.cbbMode.TabIndex = 13;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(434, 58);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(37, 13);
            this.lblMode.TabIndex = 12;
            this.lblMode.Text = "Mode:";
            // 
            // lblHandShake
            // 
            this.lblHandShake.AutoSize = true;
            this.lblHandShake.Location = new System.Drawing.Point(434, 29);
            this.lblHandShake.Name = "lblHandShake";
            this.lblHandShake.Size = new System.Drawing.Size(65, 13);
            this.lblHandShake.TabIndex = 10;
            this.lblHandShake.Text = "Handshake:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(635, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(124, 22);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbbParity
            // 
            this.cbbParity.BackColor = System.Drawing.SystemColors.Info;
            this.cbbParity.FormattingEnabled = true;
            this.cbbParity.Location = new System.Drawing.Point(286, 55);
            this.cbbParity.Name = "cbbParity";
            this.cbbParity.Size = new System.Drawing.Size(121, 21);
            this.cbbParity.TabIndex = 9;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(227, 58);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(36, 13);
            this.lblParity.TabIndex = 8;
            this.lblParity.Text = "Parity:";
            // 
            // cbbDataSize
            // 
            this.cbbDataSize.BackColor = System.Drawing.SystemColors.Info;
            this.cbbDataSize.FormattingEnabled = true;
            this.cbbDataSize.Location = new System.Drawing.Point(286, 26);
            this.cbbDataSize.Name = "cbbDataSize";
            this.cbbDataSize.Size = new System.Drawing.Size(121, 21);
            this.cbbDataSize.TabIndex = 7;
            // 
            // cbbBaudRate
            // 
            this.cbbBaudRate.BackColor = System.Drawing.SystemColors.Info;
            this.cbbBaudRate.FormattingEnabled = true;
            this.cbbBaudRate.Location = new System.Drawing.Point(49, 55);
            this.cbbBaudRate.Name = "cbbBaudRate";
            this.cbbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbbBaudRate.TabIndex = 6;
            // 
            // lblDataSize
            // 
            this.lblDataSize.AutoSize = true;
            this.lblDataSize.Location = new System.Drawing.Point(227, 29);
            this.lblDataSize.Name = "lblDataSize";
            this.lblDataSize.Size = new System.Drawing.Size(56, 13);
            this.lblDataSize.TabIndex = 3;
            this.lblDataSize.Text = "Data Size:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(11, 58);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(35, 13);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud:";
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(11, 29);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(34, 13);
            this.lblCom.TabIndex = 1;
            this.lblCom.Text = "COM:";
            // 
            // cbbComPorts
            // 
            this.cbbComPorts.BackColor = System.Drawing.SystemColors.Info;
            this.cbbComPorts.FormattingEnabled = true;
            this.cbbComPorts.Location = new System.Drawing.Point(49, 26);
            this.cbbComPorts.Name = "cbbComPorts";
            this.cbbComPorts.Size = new System.Drawing.Size(121, 21);
            this.cbbComPorts.TabIndex = 0;
            // 
            // gpbText
            // 
            this.gpbText.Controls.Add(this.txtValue);
            this.gpbText.Location = new System.Drawing.Point(12, 139);
            this.gpbText.Name = "gpbText";
            this.gpbText.Size = new System.Drawing.Size(776, 262);
            this.gpbText.TabIndex = 4;
            this.gpbText.TabStop = false;
            this.gpbText.Text = "Texto";
            // 
            // txtValue
            // 
            this.txtValue.AcceptsReturn = true;
            this.txtValue.AcceptsTab = true;
            this.txtValue.AllowDrop = true;
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(3, 16);
            this.txtValue.MaxLength = 675;
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(770, 243);
            this.txtValue.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(661, 407);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(124, 31);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // errpCon
            // 
            this.errpCon.ContainerControl = this;
            // 
            // btn_Traduzir
            // 
            this.btn_Traduzir.Location = new System.Drawing.Point(517, 408);
            this.btn_Traduzir.Name = "btn_Traduzir";
            this.btn_Traduzir.Size = new System.Drawing.Size(124, 30);
            this.btn_Traduzir.TabIndex = 6;
            this.btn_Traduzir.Text = "Traduzir";
            this.btn_Traduzir.UseVisualStyleBackColor = true;
            // 
            // Braille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Traduzir);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.gpbText);
            this.Controls.Add(this.gpbConnection);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Braille";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressora Braille";
            this.Load += new System.EventHandler(this.Braille_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpbConnection.ResumeLayout(false);
            this.gpbConnection.PerformLayout();
            this.gpbText.ResumeLayout(false);
            this.gpbText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpCon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpbConnection;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.ComboBox cbbComPorts;
        private System.Windows.Forms.GroupBox gpbText;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ErrorProvider errpCon;
        private System.Windows.Forms.Label lblDataSize;
        private System.Windows.Forms.Label lblBaudRate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbbDataSize;
        private System.Windows.Forms.ComboBox cbbBaudRate;
        private System.Windows.Forms.ComboBox cbbParity;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cbbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblHandShake;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbHandshake;
        private System.Windows.Forms.Button btn_Traduzir;
    }
}

