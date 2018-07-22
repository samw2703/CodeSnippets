namespace CodeSnippets
{
    partial class FormMain
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
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.buttonNewLanguage = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonNewSnippet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(12, 12);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(198, 21);
            this.comboBoxLanguage.TabIndex = 0;
            this.comboBoxLanguage.Text = "Language...";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // buttonNewLanguage
            // 
            this.buttonNewLanguage.Location = new System.Drawing.Point(216, 12);
            this.buttonNewLanguage.Name = "buttonNewLanguage";
            this.buttonNewLanguage.Size = new System.Drawing.Size(116, 23);
            this.buttonNewLanguage.TabIndex = 1;
            this.buttonNewLanguage.Text = "Manage Languages";
            this.buttonNewLanguage.UseVisualStyleBackColor = true;
            this.buttonNewLanguage.Click += new System.EventHandler(this.buttonNewLanguage_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 39);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(442, 287);
            this.textBox.TabIndex = 2;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // buttonNewSnippet
            // 
            this.buttonNewSnippet.Location = new System.Drawing.Point(338, 12);
            this.buttonNewSnippet.Name = "buttonNewSnippet";
            this.buttonNewSnippet.Size = new System.Drawing.Size(116, 23);
            this.buttonNewSnippet.TabIndex = 3;
            this.buttonNewSnippet.Text = "Manage Snippets";
            this.buttonNewSnippet.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 334);
            this.Controls.Add(this.buttonNewSnippet);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonNewLanguage);
            this.Controls.Add(this.comboBoxLanguage);
            this.Name = "FormMain";
            this.Text = "Snippets";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button buttonNewLanguage;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonNewSnippet;
    }
}

