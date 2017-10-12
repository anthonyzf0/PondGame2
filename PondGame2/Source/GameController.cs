using Encog.Neural.Networks;
using PondGame2.Source.Graphics;
using PondGame2.Source.PondGame;
using PondGame2.Source.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondGame2.Source
{
    class GameController
    {
        //Trains networks
        private Trainer trainer;

        //Best networks so far
        private BasicNetwork shark;

        //Debug pond
        private Pond pond;

        public GameController()
        {
            
            InputDataHandler.initalize();

            trainer = new Trainer();
            shark = trainer.SharkTrain();

            pond = new Pond(shark, null);
        }

        public void update()
        {

            pond.tick();
        }

        public void draw(Render render)
        {
            pond.draw(render);
        }

    }
}
