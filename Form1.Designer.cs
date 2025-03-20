namespace NeuralNetworkDigitRecognizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            tbTrainImages = new TextBox();
            tbTrainLabels = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            btnLoadImages = new Button();
            btnLoadLabels = new Button();
            NumUpDownEpochs = new NumericUpDown();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            textBox1 = new TextBox();
            pbCanvas = new PictureBox();
            btnRecognizeImage = new Button();
            tbAnswer = new TextBox();
            btnClearDrawing = new Button();
            ((System.ComponentModel.ISupportInitialize)NumUpDownEpochs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(43, 226);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Train Network";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbTrainImages
            // 
            tbTrainImages.Location = new Point(43, 65);
            tbTrainImages.Name = "tbTrainImages";
            tbTrainImages.Size = new Size(251, 27);
            tbTrainImages.TabIndex = 2;
            // 
            // tbTrainLabels
            // 
            tbTrainLabels.Location = new Point(43, 126);
            tbTrainLabels.Name = "tbTrainLabels";
            tbTrainLabels.Size = new Size(251, 27);
            tbTrainLabels.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 9);
            label1.Name = "label1";
            label1.Size = new Size(197, 20);
            label1.TabIndex = 6;
            label1.Text = "Input full paths to mnist files";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 42);
            label2.Name = "label2";
            label2.Size = new Size(167, 20);
            label2.TabIndex = 7;
            label2.Text = "train-images.idx3-ubyte";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 103);
            label3.Name = "label3";
            label3.Size = new Size(158, 20);
            label3.TabIndex = 8;
            label3.Text = "train-labels.idx1-ubyte";
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(43, 267);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(556, 308);
            formsPlot1.TabIndex = 12;
            // 
            // btnLoadImages
            // 
            btnLoadImages.Location = new Point(325, 68);
            btnLoadImages.Name = "btnLoadImages";
            btnLoadImages.Size = new Size(94, 29);
            btnLoadImages.TabIndex = 15;
            btnLoadImages.Text = "Load";
            btnLoadImages.UseVisualStyleBackColor = true;
            btnLoadImages.Click += btnLoadImages_Click;
            // 
            // btnLoadLabels
            // 
            btnLoadLabels.Location = new Point(325, 126);
            btnLoadLabels.Name = "btnLoadLabels";
            btnLoadLabels.Size = new Size(94, 29);
            btnLoadLabels.TabIndex = 16;
            btnLoadLabels.Text = "Load";
            btnLoadLabels.UseVisualStyleBackColor = true;
            btnLoadLabels.Click += btnLoadLabels_Click;
            // 
            // NumUpDownEpochs
            // 
            NumUpDownEpochs.Location = new Point(43, 188);
            NumUpDownEpochs.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumUpDownEpochs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumUpDownEpochs.Name = "NumUpDownEpochs";
            NumUpDownEpochs.Size = new Size(90, 27);
            NumUpDownEpochs.TabIndex = 17;
            NumUpDownEpochs.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 165);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 18;
            label4.Text = "Epochs:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 4;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown1.Location = new Point(185, 188);
            numericUpDown1.Maximum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(109, 27);
            numericUpDown1.TabIndex = 19;
            numericUpDown1.ThousandsSeparator = true;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(184, 166);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 20;
            label5.Text = "Learning Rate:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(432, 9);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(167, 265);
            textBox1.TabIndex = 21;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // pbCanvas
            // 
            pbCanvas.Location = new Point(666, 23);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(638, 329);
            pbCanvas.TabIndex = 22;
            pbCanvas.TabStop = false;
            pbCanvas.MouseDown += Canvas_MouseDown;
            pbCanvas.MouseMove += Canvas_MouseMove;
            pbCanvas.MouseUp += Canvas_MouseUp;
            // 
            // btnRecognizeImage
            // 
            btnRecognizeImage.Location = new Point(666, 383);
            btnRecognizeImage.Name = "btnRecognizeImage";
            btnRecognizeImage.Size = new Size(206, 29);
            btnRecognizeImage.TabIndex = 23;
            btnRecognizeImage.Text = "Recognize The Digit";
            btnRecognizeImage.UseVisualStyleBackColor = true;
            btnRecognizeImage.Click += btnRecognizeImage_Click;
            // 
            // tbAnswer
            // 
            tbAnswer.Location = new Point(670, 447);
            tbAnswer.Name = "tbAnswer";
            tbAnswer.Size = new Size(284, 27);
            tbAnswer.TabIndex = 24;
            // 
            // btnClearDrawing
            // 
            btnClearDrawing.Location = new Point(1021, 383);
            btnClearDrawing.Name = "btnClearDrawing";
            btnClearDrawing.Size = new Size(230, 29);
            btnClearDrawing.TabIndex = 25;
            btnClearDrawing.Text = "Clear the Canvas";
            btnClearDrawing.UseVisualStyleBackColor = true;
            btnClearDrawing.Click += btnClearDrawing_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1351, 587);
            Controls.Add(btnClearDrawing);
            Controls.Add(tbAnswer);
            Controls.Add(btnRecognizeImage);
            Controls.Add(pbCanvas);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(label4);
            Controls.Add(NumUpDownEpochs);
            Controls.Add(btnLoadLabels);
            Controls.Add(btnLoadImages);
            Controls.Add(formsPlot1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbTrainLabels);
            Controls.Add(tbTrainImages);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)NumUpDownEpochs).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox tbTrainImages;
        private TextBox tbTrainLabels;
        private Label label1;
        private Label label2;
        private Label label3;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private OpenFileDialog openFileDialog1;
        private Button btnLoadImages;
        private Button btnLoadLabels;
        private NumericUpDown NumUpDownEpochs;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private TextBox textBox1;
        private PictureBox pbCanvas;
        private Button btnRecognizeImage;
        private TextBox tbAnswer;
        private Button btnClearDrawing;
    }
}