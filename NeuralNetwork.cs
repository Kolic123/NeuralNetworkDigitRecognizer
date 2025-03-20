using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkDigitRecognizer
{
    public class NeuralNetwork
    {
        public int input_nodes, hidden1_nodes, hidden2_nodes, output_nodes;

        public static double Learning_Rate = 0.001D;

        

        public Matrix weights_ih, weights_hh , weights_ho, bias_h1, bias_h2, bias_o;

        public NeuralNetwork(int input_nodes_, int hidden1_nodes_, int hidden2_nodes_, int output_nodes_)
        {
            input_nodes = input_nodes_;
            hidden1_nodes = hidden1_nodes_;
            hidden2_nodes = hidden2_nodes_;
            output_nodes = output_nodes_;


            weights_ih = new Matrix(hidden1_nodes, input_nodes);

            weights_hh = new Matrix(hidden2_nodes, hidden1_nodes);

            weights_ho = new Matrix(output_nodes, hidden2_nodes);

            weights_ho.Randomize();
            weights_hh.Randomize();
            weights_ih.Randomize();


            bias_h1 = new Matrix(hidden1_nodes, 1);
            bias_h1.Randomize();

            bias_h2 = new Matrix(hidden2_nodes, 1);
            bias_h2.Randomize();


            bias_o = new Matrix(output_nodes, 1);
            bias_o.Randomize();

        }

        public double Sigmoid(double x) => (1 / (1 + Math.Exp(-x)));

        public double DSigmoid(double x) => (x * (1 - x));

        public double Square(double x) => (x * x);


        public double LearningRFunc(double x) => (x * Learning_Rate);


        public void SetLR(double Lr)
        {
            Learning_Rate = Lr;
        }
        public double[] FeedForward(double[] input_arr)
        {
            Matrix input = new Matrix(input_arr);
            
            var hidden1out = Matrix.Dot(input, weights_ih); 
            hidden1out.AddMatrixByElement(bias_h1);
            hidden1out.map(Sigmoid);

            var hidden2Out = Matrix.Dot(hidden1out, weights_hh);
            hidden2Out.AddMatrixByElement(bias_h2);
            hidden2Out.map(Sigmoid);

            var output = Matrix.Dot(hidden2Out, weights_ho);
            output.AddMatrixByElement(bias_o);
            output.map(Sigmoid);

            

            return output.ToFloatArray();
        }

        public double Train(double[] input_arr, double[] ans)
        {

            Matrix error, hidden2_error, hidden1_error, input_error, dWho, dWhh, dWih, WhoT, WhhT, WihT;


            Matrix input = new Matrix(input_arr);
            
            var hidden1out = Matrix.Dot(input, weights_ih);
            hidden1out.AddMatrixByElementBia(bias_h1);
            hidden1out.map(Sigmoid);

            
            var hidden2Out = Matrix.Dot(hidden1out, weights_hh);
            hidden2Out.AddMatrixByElementBia(bias_h2);
            hidden2Out.map(Sigmoid);

            
            var output = Matrix.Dot(hidden2Out, weights_ho);
            output.AddMatrixByElementBia(bias_o);
            output.map(Sigmoid);

            error = Matrix.Subtract(ans, output);

            WhoT = weights_ho.Transpose();
            WhhT = weights_hh.Transpose();
            WihT = weights_ih.Transpose();


            hidden2_error = Matrix.Dot(error, WhoT);

            hidden1_error = Matrix.Dot(hidden2_error, WhhT);

            
            input_error = Matrix.Dot(hidden1_error, WihT);

            //Calculating deltas for backpropagation

            var doutput = Matrix.Map(output, DSigmoid);
            doutput.ScaleMatrixByElement(error);
            doutput.map(LearningRFunc);

            bias_o.AddMatrixByElementBia(doutput);


            var hidden2T = hidden2Out.Transpose();


            
            dWho = Matrix.Dot(hidden2T, doutput);


            
            var dHidden2output = Matrix.Map(hidden2Out, DSigmoid);
            dHidden2output.ScaleMatrixByElement(hidden2_error);
            dHidden2output.map(LearningRFunc);


            bias_h2.AddMatrixByElementBia(dHidden2output);

            var hidden1T = hidden1out.Transpose();


            
            dWhh = Matrix.Dot(hidden1T, dHidden2output);

            var dHidden1output = Matrix.Map(hidden1out, DSigmoid);
            dHidden1output.ScaleMatrixByElement(hidden1_error);
            dHidden1output.map(LearningRFunc);


            bias_h1.AddMatrixByElementBia(dHidden1output);

            var inputT = input.Transpose();

           
            dWih = Matrix.Dot(inputT, dHidden1output);

            weights_ho.AddMatrixByElement(dWho);
            weights_hh.AddMatrixByElement(dWhh);
            weights_ih.AddMatrixByElement(dWih);


            //for loss function

            error.map(Square);

            double[] iz = error.ToFloatArray();
            double sum = 0.0D;

            for(int i = 0; i < iz.Length; i++)
            {
                sum += iz[i];
            }

            return sum/10.0D;

        }
    }
}
