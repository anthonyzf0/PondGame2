using Encog.ML.Data;
using Encog.Neural.Networks;
using Microsoft.Xna.Framework;
using PondGame2.Source.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondGame2.Source.PondGame
{
    class Pond
    {
        private static Random rand = new Random();

        //Movement Values
        public Vector2 sharkPos, sharkVel, fishPos, fishVel, lastShark, lastFish;

        private BasicNetwork shark, fish;

        private int ticks = 0;

        public Pond(BasicNetwork sharkAI, BasicNetwork fishAI)
        {
            //Gets networks
            shark = (BasicNetwork)sharkAI ?? null;
            fish = (BasicNetwork)fishAI ?? null;

            reset();
            
        }

        public void reset()
        {
            while (true)
            {
                sharkPos = new Vector2(rand.Next(800), rand.Next(800));
                fishPos = new Vector2(rand.Next(800), rand.Next(800));

                if (Vector2.Distance(sharkPos, fishPos) > 400)
                    break;
            }

            ticks = 0;
            
        }

        public double tick(int amount)
        {
            for (int i = 0; i < amount; i++)
                if (tick())
                    return 0;
                
            return (double)Vector2.Distance(fishPos,sharkPos);
        }
        
        public bool tick()
        {
            ticks++;

            var input = InputDataHandler.getData(this);

            if (fish != null)
            {
                IMLData fishOut = fish.Compute(input);

                Vector2 fishValues = new Vector2((float)fishOut[0], (float)fishOut[1]) * 5;

                fishVel = fishValues;
                fishPos += fishValues;

                lastFish = fishValues;

                fishPos = fix(fishPos);
            }

            //Shark
            if (shark != null)
            {
                IMLData sharkOut = shark.Compute(input);

                Vector2 sharkValues = new Vector2((float)sharkOut[0], (float)sharkOut[1]) * 5;

                sharkVel = sharkValues;
                sharkPos += sharkValues;

                lastShark = sharkValues;

                sharkPos = fix(sharkPos);
            }

            if (ticks > 200)
                reset();
            

            return Vector2.Distance(sharkPos, fishPos) < 20;

        }

        public Vector2 fix(Vector2 v)
        {
            return new Vector2((v.X < 0) ? 0 : (v.X > 800) ? 800 : v.X,
                                (v.Y < 0) ? 0 : (v.Y > 800) ? 800 : v.Y);
        }

        public void draw(Render render)
        {
            render.drawBox(sharkPos, Color.Red);
            render.drawBox(fishPos, Color.Green);
        }

    }
}
