namespace GraphSimulation
{
    partial class NuevoGrafo
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
            this.rbtnNoDigrafo = new System.Windows.Forms.RadioButton();
            this.rbtnDigrafo = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnNoDigrafo);
            this.groupBox1.Controls.Add(this.rbtnDigrafo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elija un tipo:";
            // 
            // rbtnNoDigrafo
            // 
            this.rbtnNoDigrafo.AutoSize = true;
            this.rbtnNoDigrafo.Location = new System.Drawing.Point(6, 65);
            this.rbtnNoDigrafo.Name = "rbtnNoDigrafo";
            this.rbtnNoDigrafo.Size = new System.Drawing.Size(195, 29);
            this.rbtnNoDigrafo.TabIndex = 1;
            this.rbtnNoDigrafo.Text = "Grafo No Dirigido";
            this.rbtnNoDigrafo.UseVisualStyleBackColor = true;
            // 
            // rbtnDigrafo
            // 
            this.rbtnDigrafo.AutoSize = true;
            this.rbtnDigrafo.Checked = true;
            this.rbtnDigrafo.Location = new System.Drawing.Point(6, 30);
            this.rbtnDigrafo.Name = "rbtnDigrafo";
            this.rbtnDigrafo.Size = new System.Drawing.Size(162, 29);
            this.rbtnDigrafo.TabIndex = 0;
            this.rbtnDigrafo.TabStop = true;
            this.rbtnDigrafo.Text = "Grafo Dirigido";
            this.rbtnDigrafo.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Location = new System.Drawing.Point(12, 132);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Location = new System.Drawing.Point(197, 132);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // NuevoGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "NuevoGrafo";
            this.Text = "Elija el tipo de grafo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAceptar;
        public System.Windows.Forms.RadioButton rbtnNoDigrafo;
        public System.Windows.Forms.RadioButton rbtnDigrafo;
        public System.Windows.Forms.Button btnCancelar;
    }
}