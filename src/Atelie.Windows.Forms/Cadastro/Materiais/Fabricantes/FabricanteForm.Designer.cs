namespace Atelie.Cadastro.Materiais.Fabricantes
{
    partial class FabricanteForm
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
            System.Windows.Forms.Label fabricanteIdLabel;
            System.Windows.Forms.Label fabricanteMarcaLabel;
            System.Windows.Forms.Label fabricanteNomeLabel;
            System.Windows.Forms.Label fabricanteSiteLabel;
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fabricanteNomeTextBox = new System.Windows.Forms.TextBox();
            this.fabricanteMarcaTextBox = new System.Windows.Forms.TextBox();
            this.fabricanteIdTextBox = new System.Windows.Forms.TextBox();
            this.fabricanteSiteTextBox = new System.Windows.Forms.TextBox();
            fabricanteIdLabel = new System.Windows.Forms.Label();
            fabricanteMarcaLabel = new System.Windows.Forms.Label();
            fabricanteNomeLabel = new System.Windows.Forms.Label();
            fabricanteSiteLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fabricanteNomeTextBox);
            this.groupBox2.Controls.Add(this.fabricanteMarcaTextBox);
            this.groupBox2.Controls.Add(this.fabricanteIdTextBox);
            this.groupBox2.Controls.Add(fabricanteIdLabel);
            this.groupBox2.Controls.Add(fabricanteMarcaLabel);
            this.groupBox2.Controls.Add(fabricanteNomeLabel);
            this.groupBox2.Controls.Add(fabricanteSiteLabel);
            this.groupBox2.Controls.Add(this.fabricanteSiteTextBox);
            this.groupBox2.Location = new System.Drawing.Point(297, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 205);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fabricante";
            // 
            // fabricanteNomeTextBox
            // 
            this.fabricanteNomeTextBox.Location = new System.Drawing.Point(13, 77);
            this.fabricanteNomeTextBox.Name = "fabricanteNomeTextBox";
            this.fabricanteNomeTextBox.Size = new System.Drawing.Size(168, 20);
            this.fabricanteNomeTextBox.TabIndex = 41;
            // 
            // fabricanteMarcaTextBox
            // 
            this.fabricanteMarcaTextBox.Location = new System.Drawing.Point(13, 120);
            this.fabricanteMarcaTextBox.Name = "fabricanteMarcaTextBox";
            this.fabricanteMarcaTextBox.Size = new System.Drawing.Size(168, 20);
            this.fabricanteMarcaTextBox.TabIndex = 39;
            // 
            // fabricanteIdTextBox
            // 
            this.fabricanteIdTextBox.Location = new System.Drawing.Point(81, 32);
            this.fabricanteIdTextBox.Name = "fabricanteIdTextBox";
            this.fabricanteIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.fabricanteIdTextBox.TabIndex = 37;
            // 
            // fabricanteIdLabel
            // 
            fabricanteIdLabel.AutoSize = true;
            fabricanteIdLabel.Location = new System.Drawing.Point(10, 35);
            fabricanteIdLabel.Name = "fabricanteIdLabel";
            fabricanteIdLabel.Size = new System.Drawing.Size(72, 13);
            fabricanteIdLabel.TabIndex = 36;
            fabricanteIdLabel.Text = "Fabricante Id:";
            // 
            // fabricanteMarcaLabel
            // 
            fabricanteMarcaLabel.AutoSize = true;
            fabricanteMarcaLabel.Location = new System.Drawing.Point(10, 104);
            fabricanteMarcaLabel.Name = "fabricanteMarcaLabel";
            fabricanteMarcaLabel.Size = new System.Drawing.Size(93, 13);
            fabricanteMarcaLabel.TabIndex = 38;
            fabricanteMarcaLabel.Text = "Fabricante Marca:";
            // 
            // fabricanteNomeLabel
            // 
            fabricanteNomeLabel.AutoSize = true;
            fabricanteNomeLabel.Location = new System.Drawing.Point(12, 61);
            fabricanteNomeLabel.Name = "fabricanteNomeLabel";
            fabricanteNomeLabel.Size = new System.Drawing.Size(91, 13);
            fabricanteNomeLabel.TabIndex = 40;
            fabricanteNomeLabel.Text = "Fabricante Nome:";
            // 
            // fabricanteSiteLabel
            // 
            fabricanteSiteLabel.AutoSize = true;
            fabricanteSiteLabel.Location = new System.Drawing.Point(10, 146);
            fabricanteSiteLabel.Name = "fabricanteSiteLabel";
            fabricanteSiteLabel.Size = new System.Drawing.Size(81, 13);
            fabricanteSiteLabel.TabIndex = 42;
            fabricanteSiteLabel.Text = "Fabricante Site:";
            // 
            // fabricanteSiteTextBox
            // 
            this.fabricanteSiteTextBox.Location = new System.Drawing.Point(13, 162);
            this.fabricanteSiteTextBox.Name = "fabricanteSiteTextBox";
            this.fabricanteSiteTextBox.Size = new System.Drawing.Size(168, 20);
            this.fabricanteSiteTextBox.TabIndex = 43;
            // 
            // FabricanteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Name = "FabricanteForm";
            this.Text = "FabricanteForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox fabricanteNomeTextBox;
        private System.Windows.Forms.TextBox fabricanteMarcaTextBox;
        private System.Windows.Forms.TextBox fabricanteIdTextBox;
        private System.Windows.Forms.TextBox fabricanteSiteTextBox;
    }
}