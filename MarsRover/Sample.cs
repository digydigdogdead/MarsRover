using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Sample
    {
        private static int SampleCount = 0;
        public SampleType Type { get; private set; }
        public int ID { get; private set; }

        public Sample()
        {
            ID = SampleCount;
            SampleCount++;

            Random random = new Random();
            int sampleGeneratorInt = random.Next(1, 101);
            if (sampleGeneratorInt < 50)
            {
                Type = SampleType.DIRT;
            }
            else if (sampleGeneratorInt < 100)
            {
                Type = SampleType.ROCK;
            }
            else
            {
                Type = SampleType.LIFE;
            }
        }

        public enum SampleType
        {
            DIRT,
            ROCK,
            LIFE
        }
    }
}
