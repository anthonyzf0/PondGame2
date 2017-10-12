using Encog.Engine.Network.Activation;
using Encog.ML;
using Encog.ML.Genetic;
using Encog.ML.Train;
using Encog.Neural.Networks;
using Encog.Neural.Pattern;
using PondGame2.Source.PondGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondGame2.Source.Training
{
    class Trainer
    {

        public Trainer()
        {


        }

        public BasicNetwork SharkTrain()
        {
            IMLTrain train = new MLMethodGeneticAlgorithm(() =>
            {
                BasicNetwork result = CreateNetwork(2, 2);
                ((IMLResettable)result).Reset();
                return result;

            }, new SharkTrainer(), 1000);
            
            for (int i = 0; i < 6; i++)
            {
                train.Iteration();
                Console.WriteLine("Shark Inital Train Score: " + Math.Round(train.Error,2));
            }

            return (BasicNetwork)train.Method;

        }

        public static BasicNetwork CreateNetwork(int end, params int[] layers)
        {
            var pattern = new FeedForwardPattern { InputNeurons = InputDataHandler.inputSize };

            foreach (int i in layers)
                pattern.AddHiddenLayer(i);

            pattern.OutputNeurons = end;
            pattern.ActivationFunction = new ActivationTANH();
            var network = (BasicNetwork)pattern.Generate();
            network.Reset();
            return network;
        }

    }
}
