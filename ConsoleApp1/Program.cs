using NoiseProcedures;
using System;
using System.Drawing;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int imageWidth = 512;
            int imageHeight = 512;
            float[] noiseMap = new float[imageWidth * imageHeight];

            // generate value noise
            ValueNoise2D noise = new ValueNoise2D();
            float frequency = 0.05f;
            for (int j = 0; j < imageHeight; ++j)
            {
                for (int i = 0; i < imageWidth; ++i)
                {
                    // generate a float in the range [0:1]
                    noiseMap[j * imageWidth + i] = noise.Evaluate(new Vector2D(i, j) * frequency);
                }
            }

            //Use a streamwriter to write the text part of the encoding
            var writer = new StreamWriter("./valuenoise.ppm"); 

            writer.Write("P6" + "\n");
            writer.Write(imageWidth + " " + imageHeight + "\n");
            writer.Write("255" + "\n");
            writer.Close();
            //Switch to a binary writer to write the data
            var writerB = new BinaryWriter(new FileStream("./valuenoise.ppm", FileMode.Append));
            for (int k = 0; k < imageWidth * imageHeight; ++k)
 
            {
                byte n = (byte)(noiseMap[k] * 255);
                writerB.Write(n);
                writerB.Write(n);
                writerB.Write(n);
            }
            writerB.Close();

            return;
        }


    }
}
