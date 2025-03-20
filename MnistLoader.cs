using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkDigitRecognizer
{
    internal class MnistLoader
    {
        public static (byte[,], byte[], int) LoadData(string imagesFilePath, string labelsFilePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagesFilePath);
            byte[] labelBytes = File.ReadAllBytes(labelsFilePath);

            Console.WriteLine(imageBytes);

            int imageIndex = 0;
            int labelIndex = 0;

            // Read header info for images and labels
            int magicNumberImages = BitConverter.ToInt32(new byte[] { imageBytes[0], imageBytes[1], imageBytes[2], imageBytes[3] }, 0);
            int magicNumberLabels = BitConverter.ToInt32(new byte[] { labelBytes[0], labelBytes[1], labelBytes[2], labelBytes[3] }, 0);

            int imageCount = BitConverter.ToInt32(new byte[] { imageBytes[7], imageBytes[6], imageBytes[5], imageBytes[4] }, 0);
            int labelCount = BitConverter.ToInt32(new byte[] { labelBytes[7], labelBytes[6], labelBytes[5], labelBytes[4] }, 0);

            if (imageCount != labelCount)
            {
                throw new Exception("The number of images does not match the number of labels.");
            }

            // Read image data
            int imageHeight = BitConverter.ToInt32(new byte[] { imageBytes[11], imageBytes[10], imageBytes[9], imageBytes[8] }, 0);
            int imageWidth = BitConverter.ToInt32(new byte[] { imageBytes[15], imageBytes[14], imageBytes[13], imageBytes[12] }, 0);

            byte[,] images = new byte[imageCount, imageHeight * imageWidth];
            for (int i = 0; i < imageCount; i++)
            {
                for (int j = 0; j < imageHeight * imageWidth; j++)
                {
                    images[i, j] = imageBytes[16 + imageIndex];
                    imageIndex++;
                }
            }

            // Read label data
            byte[] labels = new byte[labelCount];
            Console.WriteLine("Label count is " + labelCount);
            for (int i = 0; i < labelCount ; i++)
            {
                if (labelIndex + 8 > labelBytes.Length)  // Ensure that we're reading after the 8-byte header
                {
                    throw new IndexOutOfRangeException("Label data exceeded file length. " );
                }
                labels[i] = labelBytes[8 + i];  // Read label byte by byte
                labelIndex++;
            }

            return (images, labels, labelCount);
        }
    }
}
