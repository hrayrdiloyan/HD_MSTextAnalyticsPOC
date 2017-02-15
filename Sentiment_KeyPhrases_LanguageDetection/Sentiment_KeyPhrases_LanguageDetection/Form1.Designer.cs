namespace Sentiment_KeyPhrases_LanguageDetection
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSentiment = new System.Windows.Forms.Button();
            this.btnKeyPhrases = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCognitiveServicesAPIKey = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the file(s):";
            // 
            // dlgFileOpen
            // 
            this.dlgFileOpen.Filter = "Text|*.txt";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(197, 84);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 36);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSentiment
            // 
            this.btnSentiment.Location = new System.Drawing.Point(197, 141);
            this.btnSentiment.Name = "btnSentiment";
            this.btnSentiment.Size = new System.Drawing.Size(120, 36);
            this.btnSentiment.TabIndex = 2;
            this.btnSentiment.Text = "Get Sentiment";
            this.btnSentiment.UseVisualStyleBackColor = true;
            this.btnSentiment.Click += new System.EventHandler(this.btnSentiment_Click);
            // 
            // btnKeyPhrases
            // 
            this.btnKeyPhrases.Location = new System.Drawing.Point(380, 141);
            this.btnKeyPhrases.Name = "btnKeyPhrases";
            this.btnKeyPhrases.Size = new System.Drawing.Size(153, 36);
            this.btnKeyPhrases.TabIndex = 3;
            this.btnKeyPhrases.Text = "Get Key Phrases";
            this.btnKeyPhrases.UseVisualStyleBackColor = true;
            this.btnKeyPhrases.Click += new System.EventHandler(this.btnKeyPhrases_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(16, 183);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(690, 420);
            this.rtbOutput.TabIndex = 5;
            this.rtbOutput.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cognitive Services API Key";
            // 
            // txtCognitiveServicesAPIKey
            // 
            this.txtCognitiveServicesAPIKey.Location = new System.Drawing.Point(197, 36);
            this.txtCognitiveServicesAPIKey.Name = "txtCognitiveServicesAPIKey";
            this.txtCognitiveServicesAPIKey.Size = new System.Drawing.Size(336, 22);
            this.txtCognitiveServicesAPIKey.TabIndex = 7;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(288, 94);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(245, 22);
            this.txtFilePath.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 610);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtCognitiveServicesAPIKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnKeyPhrases);
            this.Controls.Add(this.btnSentiment);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Text Analytics API Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgFileOpen;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSentiment;
        private System.Windows.Forms.Button btnKeyPhrases;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCognitiveServicesAPIKey;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}

