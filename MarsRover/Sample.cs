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
            SampleCount++;
            ID = SampleCount;

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

        public override string ToString() => Type switch
        {
            SampleType.DIRT => $"This sample is sample #{ID} and is Dirt.",
            SampleType.ROCK => $"This sample is sample #{ID} and is a Rock.",
            SampleType.LIFE => $"This sample is sample #{ID} and is... wait... this is life! It's alive, this changes everything!",
        };
    }
}
