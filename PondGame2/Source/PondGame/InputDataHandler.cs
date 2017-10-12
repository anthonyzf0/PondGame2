using Encog.ML.Data.Basic;
using Encog.Util.Arrayutil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondGame2.Source.PondGame
{
    class InputDataHandler
    {
        //Network Data
        private static NormalizedField location, speed;

        public static int inputSize = 2;

        public static void initalize()
        {
            location = new NormalizedField(NormalizationAction.Normalize, "Location", -800, 800, -0.9, 0.9);
            speed = new NormalizedField(NormalizationAction.Normalize, "Speed", -10, 10, -0.9, 0.9);
        }

        public static BasicMLData getData(Pond pond)
        {
            var input = new BasicMLData(inputSize);

            input[0] = location.Normalize(- pond.sharkPos.X + pond.fishPos.X);
            input[1] = location.Normalize(- pond.sharkPos.Y + pond.fishPos.Y);
           /* input[2] = location.Normalize(pond.sharkPos.X - pond.fishPos.X);
            input[3] = location.Normalize(pond.sharkPos.Y - pond.fishPos.Y);
            input[4] = speed.Normalize(pond.fishVel.X - pond.sharkVel.X);
            input[5] = speed.Normalize(pond.fishVel.Y - pond.sharkVel.Y);
            input[6] = speed.Normalize(pond.sharkVel.X - pond.fishVel.X);
            input[7] = speed.Normalize(pond.sharkVel.Y - pond.sharkVel.Y);
            input[8] = pond.lastFish.X;
            input[9] = pond.lastFish.Y;
            input[10] = pond.lastShark.X;
            input[11] = pond.lastShark.Y;*/

            return input;
            
        }

    }
}
