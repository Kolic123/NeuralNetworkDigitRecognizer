using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace NeuralNetworkDigitRecognizer
{
    public partial class Form1 : Form
    {
        private List<double> epochs;
        private List<double> losses;
        private NeuralNetwork neuralNetwork = new NeuralNetwork(28 * 28, 128, 64, 10);
        private string trainImagesPath = "";
        private string trainLabelsPath = "";
        private int Epochs = 1;


        private Bitmap drawingBitmap;
        private bool isDrawing = false;
        private Point lastPoint;


        public Form1()
        {
            InitializeComponent();
            epochs = new List<double>();
            losses = new List<double>();
            pbCanvas.BackColor = System.Drawing.Color.Black;
            drawingBitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            pbCanvas.Image = drawingBitmap;


        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (trainImagesPath == "" || trainLabelsPath == "")
            {
                MessageBox.Show("Please provide full path to the files or choose them graphicaly by clicking on load buttons", "Loading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Epochs = Convert.ToInt32(NumUpDownEpochs.Value);

            neuralNetwork.SetLR(Convert.ToDouble(numericUpDown1.Value));


            var (trainImagesbyte, trainLabelsbyte, NumberOfTrainImages) = MnistLoader.LoadData(trainImagesPath, trainLabelsPath);


            double[,] trainImages = new double[NumberOfTrainImages, 28 * 28];
            double[,] trainLabels = new double[NumberOfTrainImages, 10];



            for (int i = 0; i < NumberOfTrainImages; i++)
            {
                double lab = Convert.ToDouble(trainLabelsbyte[i]);
                int pos = Convert.ToInt32(lab);
                for (int k = 0; k < 10; k++)
                {
                    trainLabels[i, k] = 0.0D;
                }
                trainLabels[i, pos] = 1.0D;
                for (int j = 0; j < 28 * 28; j++)
                {
                    trainImages[i, j] = Convert.ToDouble(trainImagesbyte[i, j]) / 255.0;
                }
            }








            for (int epoch = 1; epoch <= Epochs; epoch++)
            {
                double totalLoss = 0;


                for (int i = 0; i < NumberOfTrainImages; i++)
                {
                    double[] input = GetRow(trainImages, i, 28 * 28);
                    double[] label = GetRow(trainLabels, i, 10);


                    double loss = neuralNetwork.Train(input, label);
                    totalLoss += loss;

                    if (i % 1000 == 0 && i != 0)
                    {
                        double avgLoss = totalLoss / i;


                        UpdateChart((i / 1000) + ((epoch - 1) * 60), avgLoss * 10000, 1.0D);


                    }
                }


            }

        }



        private void UpdateChart(int epoch, double loss, double b)
        {
            double e = Convert.ToDouble(epoch);
            epochs.Add(e);
            losses.Add(loss);
            formsPlot1.Plot.Clear();


            formsPlot1.Plot.Add.Scatter(epochs.ToArray(), losses.ToArray());


            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();

        }

        private double[] GetRow(double[,] In, int index, int num)
        {
            double[] retVal = new double[num];
            for (int i = 0; i < num; i++)
            {

                retVal[i] = In[index, i];
            }

            return retVal;
        }

        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;


            trainImagesPath = dlg.FileName;

            tbTrainImages.Text = trainImagesPath;

        }

        private void btnLoadLabels_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            trainLabelsPath = dlg.FileName;

            tbTrainLabels.Text = trainLabelsPath;

        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDrawing && e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    Pen pen = new Pen(System.Drawing.Color.White, 18);
                    g.DrawLine(pen, lastPoint, e.Location);
                    lastPoint = e.Location;
                }

                pbCanvas.Refresh();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        public double[] GetDrawingAsInput()
        {

            Bitmap resizedBitmap = new Bitmap(drawingBitmap, new Size(28, 28));

           
            double[] inputArray = new double[28 * 28];

            for (int y = 0; y < 28; y++)
            {
                for (int x = 0; x < 28; x++)
                {
                    System.Drawing.Color pixel = resizedBitmap.GetPixel(x, y);
                    double grayscale = 1.0 - (pixel.R + pixel.G + pixel.B) / (3.0 * 255);
                    inputArray[y * 28 + x] = grayscale;
                }
            }

            return inputArray;
        }


        private void btnClearDrawing_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.Clear(System.Drawing.Color.Black);
            }
            pbCanvas.Invalidate();
        }

        private void btnRecognizeImage_Click(object sender, EventArgs e)
        {
            double[] input = GetDrawingAsInput();
            double[] output = neuralNetwork.FeedForward(input);


            double maxV = -1.0D;
            int posM = 0;

            for (int i = 0; i < output.Length; i++)
            {

                if (output[i] > maxV)
                {
                    maxV = output[i];
                    posM = i;
                }
            }

            tbAnswer.Text = "";

            tbAnswer.Text = "Computer Thinks that digit drawn is: " + (posM);

        }
    }
}