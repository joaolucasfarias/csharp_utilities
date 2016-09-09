namespace UTIL
{
    partial class frmSplash
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
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblAtual = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.Location = new System.Drawing.Point(0, -1);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(356, 67);
            this.lblMensagem.TabIndex = 2;
            this.lblMensagem.Text = "Operações em andamento. Por favor, aguarde...";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAtual
            // 
            this.lblAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtual.Location = new System.Drawing.Point(-2, 66);
            this.lblAtual.Name = "lblAtual";
            this.lblAtual.Size = new System.Drawing.Size(358, 33);
            this.lblAtual.TabIndex = 4;
            this.lblAtual.Text = "Atualizando...";
            this.lblAtual.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbProgresso.Location = new System.Drawing.Point(0, 102);
            this.pgbProgresso.MarqueeAnimationSpeed = 25;
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(356, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 3;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 125);
            this.ControlBox = false;
            this.Controls.Add(this.lblAtual);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.lblMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label lblAtual;
        private System.Windows.Forms.ProgressBar pgbProgresso;
    }
}