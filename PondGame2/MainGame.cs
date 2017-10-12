﻿using Encog.Neural.Networks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PondGame2.Source;
using PondGame2.Source.Graphics;
using PondGame2.Source.Training;

namespace PondGame2
{
    public class MainGame : Game
    {
        //Setup Graphics
        Render render;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game file
        private GameController game;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            //Display
            spriteBatch = new SpriteBatch(GraphicsDevice);
            render = new Render(spriteBatch, graphics.GraphicsDevice, Content);
            
            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 800;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            game = new GameController();

            base.Initialize();
        }
        
        protected override void Update(GameTime gameTime)
        {
            game.update();
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            render.start();

            game.draw(render);

            render.end();

            base.Draw(gameTime);
        }
    }
}
