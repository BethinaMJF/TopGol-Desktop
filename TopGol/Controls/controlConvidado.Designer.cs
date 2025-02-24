namespace TopGol.Controls
{
    partial class controlConvidado
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.circular1 = new TopGol.Controls.circular();
            ((System.ComponentModel.ISupportInitialize)(this.circular1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(511, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(149, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // circular1
            // 
            this.circular1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circular1.Location = new System.Drawing.Point(20, 19);
            this.circular1.Name = "circular1";
            this.circular1.Size = new System.Drawing.Size(106, 84);
            this.circular1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circular1.TabIndex = 2;
            this.circular1.TabStop = false;
            // 
            // controlConvidado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.circular1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "controlConvidado";
            this.Size = new System.Drawing.Size(673, 132);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.controlConvidado_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.circular1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private circular circular1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
    }
}
