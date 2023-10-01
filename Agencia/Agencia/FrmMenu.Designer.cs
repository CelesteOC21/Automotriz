namespace Agencia
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTaller = new System.Windows.Forms.ToolStripLabel();
            this.btnTaller = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btnAdministrador = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleName = "BarraHerramientas";
            this.toolStrip1.BackColor = System.Drawing.Color.SeaGreen;
            this.toolStrip1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTaller,
            this.btnTaller,
            this.toolStripLabel2,
            this.toolStripButton2,
            this.toolStripLabel3,
            this.btnAdministrador});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // lblTaller
            // 
            this.lblTaller.AccessibleName = "btnTaller";
            this.lblTaller.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTaller.LinkColor = System.Drawing.Color.Yellow;
            this.lblTaller.Name = "lblTaller";
            this.lblTaller.Size = new System.Drawing.Size(53, 24);
            this.lblTaller.Text = "Taller";
            // 
            // btnTaller
            // 
            this.btnTaller.AccessibleName = "";
            this.btnTaller.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTaller.Image = ((System.Drawing.Image)(resources.GetObject("btnTaller.Image")));
            this.btnTaller.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaller.Name = "btnTaller";
            this.btnTaller.Size = new System.Drawing.Size(29, 24);
            this.btnTaller.Text = "btnTaller";
            this.btnTaller.Click += new System.EventHandler(this.btnTaller_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AccessibleName = "btnHerramienta";
            this.toolStripLabel2.ActiveLinkColor = System.Drawing.Color.White;
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel2.LinkColor = System.Drawing.Color.Yellow;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(118, 24);
            this.toolStripLabel2.Text = "Herramienta";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AccessibleName = "brnHerramientas";
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "btnHerramienta";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel3.LinkColor = System.Drawing.Color.Yellow;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(131, 24);
            this.toolStripLabel3.Text = "Administrador";
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.AccessibleName = "btnAdministrador";
            this.btnAdministrador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministrador.Image")));
            this.btnAdministrador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(29, 24);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblTaller;
        private System.Windows.Forms.ToolStripButton btnTaller;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnAdministrador;
    }
}