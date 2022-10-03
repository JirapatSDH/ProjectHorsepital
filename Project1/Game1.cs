using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Penumbra;
using System;
using System.Collections.Generic;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        PenumbraComponent dylight;
        private SpriteBatch _spriteBatch;
        private Texture2D bGtile;
        private Texture2D bGtile2;
        private Texture2D bGtile3;
        private Texture2D ballTexture;
        private SpriteFont deBugFont;

        public Texture2D farmer;
        public Vector2 pos;
        public Vector2 bgPos = Vector2.Zero;
        public Vector2 ballPos = new Vector2(0,0);
        public Vector2 textPos;

        Vector2 camPos = Vector2.Zero;
        Vector2 fLine, bLine;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        public Rectangle rec;
        private string text;
        private string ptext;

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
            Scale = new Vector2(250f), 
            ShadowType = ShadowType.Illuminated 
        };
        Light spotLight = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f
        };
        Light spotLight2 = new Spotlight
        {
            Color = Color.Yellow,
            Scale = new Vector2(400),
            Radius = 120,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f
        };
        Light spotLight3 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f
        };
        Light spotLight4 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f
        };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 380;
            _graphics.ApplyChanges();   
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            dylight = new PenumbraComponent(this);
            dylight.Lights.Add(light);
            dylight.Lights.Add(spotLight);
            dylight.Lights.Add(spotLight2);
            dylight.Lights.Add(spotLight3);
            dylight.Lights.Add(spotLight4);
        }

        protected override void Initialize()
        {

            //camera = new Camera(GraphicsDevice.Viewport);
            text = "";
            ptext = "";

            base.Initialize();
            dylight.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bGtile = base.Content.Load<Texture2D>("2-1D");
            bGtile2 = base.Content.Load<Texture2D>("2-2D");
            bGtile3 = base.Content.Load<Texture2D>("2-3D");
            ballTexture = Content.Load<Texture2D>("ball");
            deBugFont = Content.Load<SpriteFont>("MyFont");
            farmer = Content.Load<Texture2D>("kaolad_walk_newV2");

            frame = 0;
            totalframe = 4;
            framepersec = 6;
            timeperframe = (float)1 / framepersec;
            totalelapsed = 0;

            pos = new Vector2(150, 270);
            ballPos = new Vector2(20, 255);
           
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
            KeyboardState old_ks = Keyboard.GetState();
            {
                if (ks.IsKeyDown(Keys.W))
                {
                    //pos.Y = 270;
                    pos.Y = pos.Y - speed.Y;
                    if (pos.Y <= 210)
                    {
                        pos.Y = 210;
                    }
                    direction = 3;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    //pos.Y = 350;
                    pos.Y = pos.Y + speed.Y;
                    if (pos.Y >= 280)
                    {
                        pos.Y = 280;
                    }
                    direction = 0;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
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
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width*3 - 25)
                {
                    if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width*2)
                    {
                        fLine += new Vector2(3, 0);
                        bLine += new Vector2(3, 0);
                        camPos += new Vector2(3, 0);
                    }

                    pos.X = pos.X + speed.X;

                    
                    direction = 2;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 70);
                Rectangle ballRectangle = new Rectangle((int)ballPos.X, (int)ballPos.Y, 24, 24);

                if (personRectangle.Intersects(ballRectangle) == true)
                {
                    personHit = true;
                    text = "F To Enter";
                    {
                        if (ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            text = "Enter room 1";
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) ==false)
                {
                    personHit = false;
                    text = "Check";
                }
                old_ks = ks;
            }
            light.Position = pos - camPos + new Vector2 (40,40);
            ptext = "" + pos.ToString();
            textPos = pos + new Vector2(5, 95);
            //camera.Update(gameTime, this);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            dylight.BeginDraw();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(bGtile, (bgPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(bGtile2, (bgPos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(bGtile3, (bgPos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width + 720, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            _spriteBatch.DrawString(deBugFont, text, (ballPos - new Vector2(0,20) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));

            //SpotLight
            spotLight.Position = (new Vector2 (894,20) - camPos) * scroll_factor;
            spotLight2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLight3.Position = (new Vector2(1557, 20) - camPos) * scroll_factor;
            spotLight4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;

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
