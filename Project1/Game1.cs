using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Penumbra;
using System;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        PenumbraComponent dylight;
        private SpriteBatch _spriteBatch;
        private Texture2D bGtile;
        private Texture2D ballTexture;
        private SpriteFont deBugFont;

        public Texture2D farmer;
        public Vector2 pos;
        public Vector2 bgPos = Vector2.Zero;
        public Vector2 ballPos = new Vector2(0,0);

        Vector2 camPos = Vector2.Zero;
        Vector2 fLine, bLine;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        public Rectangle rec;
        private string text;

        public bool personHit;
        Vector2 speed = new Vector2(3,3);
        int direction = 0;
        int rad = 50;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;

        Light light = new PointLight
        {
            Scale = new Vector2(450f), // Range of the light source (how far the light will travel)
            ShadowType = ShadowType.Illuminated // Will not lit hulls themselves
        };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();   
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            dylight = new PenumbraComponent(this);
            dylight.Lights.Add(light);
        }

        protected override void Initialize()
        {

            //camera = new Camera(GraphicsDevice.Viewport);
            text = "";

            base.Initialize();
            dylight.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bGtile = base.Content.Load<Texture2D>("IMG_0130");
            ballTexture = Content.Load<Texture2D>("ball");
            deBugFont = Content.Load<SpriteFont>("MyFont");
            farmer = Content.Load<Texture2D>("kaolad_walk_new");

            frame = 0;
            totalframe = 4;
            framepersec = 6;
            timeperframe = (float)1 / framepersec;
            totalelapsed = 0;

            pos = new Vector2(150, 270);
            ballPos = new Vector2(270, 290);
            fLine.X = pos.X + rad;
            bLine.X = pos.X - rad;
 
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ProcessInput();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState ks = Keyboard.GetState();
            {
                if (ks.IsKeyDown(Keys.W))
                {
                    //pos.Y = 270;
                    pos.Y = pos.Y - speed.Y;
                    if (pos.Y <= 200)
                    {
                        pos.Y = 200;
                    }
                    direction = 3;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    //pos.Y = 350;
                    pos.Y = pos.Y + speed.Y;
                    if (pos.Y >= 340)
                    {
                        pos.Y = 340;
                    }
                    direction = 0;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 0)
                {
                    if(pos.X <= bLine.X && camPos.X > 0)
                    {
                        fLine -= new Vector2(3,0);
                        bLine -= new Vector2(3,0);
                        camPos -= new Vector2(3,0);   
                    }

                    pos.X = pos.X - speed.X;

                    direction = 1;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width*2 - 25)
                {
                    if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width)
                    {
                        fLine += new Vector2(3, 0);
                        bLine += new Vector2(3, 0);
                        camPos += new Vector2(3, 0);
                    }

                    pos.X = pos.X + speed.X;

                    
                    direction = 2;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 74, 100);
                Rectangle ballRectangle = new Rectangle((int)ballPos.X, (int)ballPos.Y, 24, 24);

                if (personRectangle.Intersects(ballRectangle) == true)
                {
                    personHit = true;
                    text = "inter";
                    {
                        if (ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            text = "It is a phong";
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) ==false)
                {
                    personHit = false;
                    text = "outer";
                }
            }
            light.Position = pos - camPos + new Vector2 (40,40);


            //camera.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            dylight.BeginDraw();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(bGtile, (bgPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(bGtile, (bgPos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos - camPos) * scroll_factor, new Rectangle(24, 0, 24, 24), (Color.White));
            _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            _spriteBatch.DrawString(deBugFont, text, (ballPos - new Vector2(0,20) - camPos) * scroll_factor, (Color.White));

            _spriteBatch.End();
            dylight.Draw(gameTime);
            base.Draw(gameTime);
        }
        void UpdateFrame(float elapsed)
        {
            totalelapsed += elapsed;
            if (totalelapsed > timeperframe)
            {
                frame = (frame + 1) % totalframe;
                totalelapsed -= timeperframe;
            }
        }
        protected void ProcessInput()
        {
            // TODO: Add your input handle here


        }
    }
}
