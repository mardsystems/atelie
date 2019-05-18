namespace Atelie.Cadastro.Materiais.Componentes
{
    partial class ComponenteForm
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
            System.Windows.Forms.Label componenteIdLabel;
            System.Windows.Forms.Label componentePaiNomeLabel;
            System.Windows.Forms.Label componentePaiIdLabel;
            System.Windows.Forms.Label componenteNomeLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.componenteNomeTextBox = new System.Windows.Forms.TextBox();
            this.componentePaiNomeTextBox = new System.Windows.Forms.TextBox();
            this.componentePaiIdTextBox = new System.Windows.Forms.TextBox();
            this.componenteIdTextBox = new System.Windows.Forms.TextBox();
            componenteIdLabel = new System.Windows.Forms.Label();
            componentePaiNomeLabel = new System.Windows.Forms.Label();
            componentePaiIdLabel = new System.Windows.Forms.Label();
            componenteNomeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.componenteNomeTextBox);
            this.groupBox1.Controls.Add(componenteIdLabel);
            this.groupBox1.Controls.Add(componentePaiNomeLabel);
            this.groupBox1.Controls.Add(this.componentePaiNomeTextBox);
            this.groupBox1.Controls.Add(this.componentePaiIdTextBox);
            this.groupBox1.Controls.Add(this.componenteIdTextBox);
            this.groupBox1.Controls.Add(componentePaiIdLabel);
            this.groupBox1.Controls.Add(componenteNomeLabel);
            this.groupBox1.Location = new System.Drawing.Point(297, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 159);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Componente";
            // 
            // componenteNomeTextBox
            // 
            this.componenteNomeTextBox.Location = new System.Drawing.Point(9, 61);
            this.componenteNomeTextBox.Name = "componenteNomeTextBox";
            this.componenteNomeTextBox.Size = new System.Drawing.Size(175, 20);
            this.componenteNomeTextBox.TabIndex = 48;
            // 
            // componenteIdLabel
            // 
            componenteIdLabel.AutoSize = true;
            componenteIdLabel.Location = new System.Drawing.Point(6, 25);
            componenteIdLabel.Name = "componenteIdLabel";
            componenteIdLabel.Size = new System.Drawing.Size(82, 13);
            componenteIdLabel.TabIndex = 24;
            componenteIdLabel.Text = "Componente Id:";
            // 
            // componentePaiNomeLabel
            // 
            componentePaiNomeLabel.AutoSize = true;
            componentePaiNomeLabel.Location = new System.Drawing.Point(6, 110);
            componentePaiNomeLabel.Name = "componentePaiNomeLabel";
            componentePaiNomeLabel.Size = new System.Drawing.Size(119, 13);
            componentePaiNomeLabel.TabIndex = 30;
            componentePaiNomeLabel.Text = "Componente Pai Nome:";
            // 
            // componentePaiNomeTextBox
            // 
            this.componentePaiNomeTextBox.Location = new System.Drawing.Point(9, 126);
            this.componentePaiNomeTextBox.Name = "componentePaiNomeTextBox";
            this.componentePaiNomeTextBox.Size = new System.Drawing.Size(175, 20);
            this.componentePaiNomeTextBox.TabIndex = 31;
            // 
            // componentePaiIdTextBox
            // 
            this.componentePaiIdTextBox.Location = new System.Drawing.Point(112, 87);
            this.componentePaiIdTextBox.Name = "componentePaiIdTextBox";
            this.componentePaiIdTextBox.Size = new System.Drawing.Size(72, 20);
            this.componentePaiIdTextBox.TabIndex = 29;
            // 
            // componenteIdTextBox
            // 
            this.componenteIdTextBox.Location = new System.Drawing.Point(111, 22);
            this.componenteIdTextBox.Name = "componenteIdTextBox";
            this.componenteIdTextBox.Size = new System.Drawing.Size(73, 20);
            this.componenteIdTextBox.TabIndex = 25;
            // 
            // componentePaiIdLabel
            // 
            componentePaiIdLabel.AutoSize = true;
            componentePaiIdLabel.Location = new System.Drawing.Point(6, 84);
            componentePaiIdLabel.Name = "componentePaiIdLabel";
            componentePaiIdLabel.Size = new System.Drawing.Size(100, 13);
            componentePaiIdLabel.TabIndex = 28;
            componentePaiIdLabel.Text = "Componente Pai Id:";
            // 
            // componenteNomeLabel
            // 
            componenteNomeLabel.AutoSize = true;
            componenteNomeLabel.Location = new System.Drawing.Point(6, 45);
            componenteNomeLabel.Name = "componenteNomeLabel";
            componenteNomeLabel.Size = new System.Drawing.Size(101, 13);
            componenteNomeLabel.TabIndex = 26;
            componenteNomeLabel.Text = "Componente Nome:";
            // 
            // ComponenteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "ComponenteForm";
            this.Text = "ComponenteForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox componenteNomeTextBox;
        private System.Windows.Forms.TextBox componentePaiNomeTextBox;
        private System.Windows.Forms.TextBox componentePaiIdTextBox;
        private System.Windows.Forms.TextBox componenteIdTextBox;
    }
}