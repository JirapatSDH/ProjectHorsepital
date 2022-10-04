using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Penumbra;
using System;
using System.Collections.Generic;
using SharpDX.XAudio2;
//using System.Drawing;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Screen mCurrentScreen;
        public Main_Hall mMain_HallScreen;
        public Room1 mRoom1Screen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 380;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mMain_HallScreen = new Main_Hall(this, new EventHandler(GameplayScreenEvent));
            mRoom1Screen = new Room1(this, new EventHandler(GameplayScreenEvent));
            mCurrentScreen = mMain_HallScreen;

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            mCurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (Screen)obj;
        }
    }
}
