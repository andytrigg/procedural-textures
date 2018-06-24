using NoiseProcedures;
using System.IO;
using Mono.Options;
using System;

namespace TestHarness
{
    public delegate float NoiseFunction(Vector2D point);
    class NoiseBitMap
    {
        private float[] map;
        private readonly int width;
        private readonly int height;

        public NoiseBitMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new float[width * height];
        }

        public float[] GenerateNoise(NoiseFunction noiseFunction)
        {
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    // generate a float in the range [0:1]
                    map[j * width + i] = noiseFunction(new Vector2D(i, j));
                }
            }
            return map;
        }
    }
    class PpmNoiseGenerator
    {
        static void Main(string[] args)
        {
            var verbosity = 0;
            int imageWidth = 512;
            int imageHeight = 512;
            float frequency = 0.05f;
            float amplitude = 1.0f;
            var shouldShowHelp = false;
            string outputFile = "./valuenoise.ppm";

            var options = new OptionSet {
                { "o|output=", "the name of the output file", o => outputFile = o },
                { "x|width=", "the image width", (int x) => imageWidth = x },
                { "y|height=", "the image height", (int y) => imageHeight = y },
                { "f|frequency=", "the noise frequency", (float f) => frequency = f },
                { "a|amplitude=", "the noise frequency", (float a) => amplitude = a },
                { "v", "increase debug message verbosity", v => { if (v != null) ++verbosity; } },
                { "h|help", "show this message and exit", h => shouldShowHelp = h != null },
            };

            try
            {
                // parse the command line
                options.Parse(args);
            }
            catch (OptionException e)
            {
                // output some error message
                Console.Write("Error: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }

            NoiseBitMap noiseMap = new NoiseBitMap(imageWidth, imageHeight);
            // generate value noise
            FrequencyDecorator noise = new  FrequencyDecorator(new ValueNoise2D(), 0.05f);

            float[] generatedNoiseMap = noiseMap.GenerateNoise(noise.Evaluate);

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
                byte n = (byte)(generatedNoiseMap[k] * 255);
                writerB.Write(n);
                writerB.Write(n);
                writerB.Write(n);
            }
            writerB.Close();

            return;
        }
    }
}
