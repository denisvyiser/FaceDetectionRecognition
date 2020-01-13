namespace FaceDetectionRecognition
{
    partial class Form1
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
            this.webCamImageBox = new Emgu.CV.UI.ImageBox();
            this.Trainbottom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OutPutBox = new System.Windows.Forms.TextBox();
            this.FaceButton = new System.Windows.Forms.Button();
            this.EyeButton = new System.Windows.Forms.Button();
            this.PredictButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webCamImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // webCamImageBox
            // 
            this.webCamImageBox.Location = new System.Drawing.Point(12, 12);
            this.webCamImageBox.Name = "webCamImageBox";
            this.webCamImageBox.Size = new System.Drawing.Size(722, 394);
            this.webCamImageBox.TabIndex = 2;
            this.webCamImageBox.TabStop = false;
            // 
            // Trainbottom
            // 
            this.Trainbottom.Location = new System.Drawing.Point(834, 97);
            this.Trainbottom.Name = "Trainbottom";
            this.Trainbottom.Size = new System.Drawing.Size(264, 34);
            this.Trainbottom.TabIndex = 3;
            this.Trainbottom.Text = "Begin Training";
            this.Trainbottom.UseVisualStyleBackColor = true;
            this.Trainbottom.Click += new System.EventHandler(this.Trainbottom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(831, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter your ID:";
            // 
            // IdBox
            // 
            this.IdBox.Location = new System.Drawing.Point(834, 53);
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(264, 22);
            this.IdBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(834, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "OutPut:";
            // 
            // OutPutBox
            // 
            this.OutPutBox.Location = new System.Drawing.Point(834, 210);
            this.OutPutBox.Multiline = true;
            this.OutPutBox.Name = "OutPutBox";
            this.OutPutBox.Size = new System.Drawing.Size(264, 98);
            this.OutPutBox.TabIndex = 7;
            // 
            // FaceButton
            // 
            this.FaceButton.Location = new System.Drawing.Point(834, 338);
            this.FaceButton.Name = "FaceButton";
            this.FaceButton.Size = new System.Drawing.Size(129, 23);
            this.FaceButton.TabIndex = 8;
            this.FaceButton.Text = "Face Square: Off";
            this.FaceButton.UseVisualStyleBackColor = true;
            this.FaceButton.Click += new System.EventHandler(this.FaceButton_Click);
            // 
            // EyeButton
            // 
            this.EyeButton.Location = new System.Drawing.Point(969, 338);
            this.EyeButton.Name = "EyeButton";
            this.EyeButton.Size = new System.Drawing.Size(129, 23);
            this.EyeButton.TabIndex = 9;
            this.EyeButton.Text = "Eye Square: Off";
            this.EyeButton.UseVisualStyleBackColor = true;
            this.EyeButton.Click += new System.EventHandler(this.EyeButton_Click);
            // 
            // PredictButton
            // 
            this.PredictButton.Location = new System.Drawing.Point(833, 379);
            this.PredictButton.Name = "PredictButton";
            this.PredictButton.Size = new System.Drawing.Size(265, 23);
            this.PredictButton.TabIndex = 10;
            this.PredictButton.Text = "Predict Face";
            this.PredictButton.UseVisualStyleBackColor = true;
            this.PredictButton.Click += new System.EventHandler(this.PredictButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 450);
            this.Controls.Add(this.PredictButton);
            this.Controls.Add(this.EyeButton);
            this.Controls.Add(this.FaceButton);
            this.Controls.Add(this.OutPutBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Trainbottom);
            this.Controls.Add(this.webCamImageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webCamImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox webCamImageBox;
        private System.Windows.Forms.Button Trainbottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IdBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutPutBox;
        private System.Windows.Forms.Button FaceButton;
        private System.Windows.Forms.Button EyeButton;
        private System.Windows.Forms.Button PredictButton;
    }
}

