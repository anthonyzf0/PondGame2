using Encog.Neural.Networks.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encog.ML;
using PondGame2.Source.PondGame;
using Encog.Neural.Networks;

namespace PondGame2.Source.Training
{
    class SharkTrainer : ICalculateScore
    {
        public bool RequireSingleThreaded
        {
            get
            {
                return true;
            }
        }

        public bool ShouldMinimize
        {
            get
            {
                return true;
            }
        }

        public double CalculateScore(IMLMethod network)
        {
            double ret = 0;
            for (int i = 0; i < 10; i++)
            {
                Pond p = new Pond((BasicNetwork)network, null);
                ret += p.tick(100);
            }
            return ret/10;

        }
    }
}
