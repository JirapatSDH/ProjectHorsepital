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
        private Texture2D uiTexture;
        private Texture2D sanityBar;
        private Texture2D staminaBar;
        private SpriteFont deBugFont;

        public Texture2D farmer;
        public Texture2D pIdle;
        public Vector2 pos;
        public Vector2 bgPos = Vector2.Zero;
        public Vector2 ballPos = new Vector2(0,0);
        public Vector2 textPos;
        public Vector2 uiPos;
        public Vector2 sbarPos = new Vector2(73,12);

        Vector2 camPos = Vector2.Zero;
        Vector2 fLine, bLine;
        Vector2 scroll_factor = new Vector2(1.0f, 1);
        

        public Rectangle rec;
        private string text;
        private string ptext;
        public Rectangle hBarRec;
        public Rectangle sBarRec;
        public bool personHit;
        Vector2 speed = new Vector2(3,3);
        int direction = 0;
        int rad = 50;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;

        //--------------------------------------------------------------------------Set Light---------------------------------------------
        Light light2 = new Spotlight
        {
            Color = Color.White,
            Scale = new Vector2(510f),
            Radius = 100,
            CastsShadows = false,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 300.5f,
            ShadowType = ShadowType.Solid
        };
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
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLight2 = new Spotlight
        {
            Color = Color.Yellow,
            Scale = new Vector2(400),
            Radius = 120,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 2.5f,
            ShadowType = ShadowType.Illuminated 
        };
        Light spotLight3 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLight4 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        //-------------------------------------------------------------enemy-----------------------------------------------------------------------
        enum FaceDirection
        {
            Left = -1,
            Right = 1,
        }
        public Light eLight { get; } = new PointLight
        {
            Color = new Color(255, 0, 0),
            Scale = new Vector2(400),
            Intensity = 1.5f
        };
        public Vector2 ePosition;
        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 380;
            _graphics.ApplyChanges();   
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            dylight = new PenumbraComponent(this);
            //add Light
            dylight.Lights.Add(light);
            dylight.Lights.Add(light2);
            dylight.Lights.Add(spotLight);
            dylight.Lights.Add(spotLight2);
            dylight.Lights.Add(spotLight3);
            dylight.Lights.Add(spotLight4);
            dylight.Lights.Add(eLight);

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
            pIdle = Content.Load<Texture2D>("kaolad_standing");
            uiTexture = Content.Load<Texture2D>("UI_emty");
            sanityBar = Content.Load<Texture2D>("SanityBar");
            staminaBar = Content.Load<Texture2D>("StaminaBar");

            frame = 0;
            totalframe = 4;
            framepersec = 6;
            timeperframe = (float)1 / framepersec;
            totalelapsed = 0;

            pos = new Vector2(150, 270);
            ballPos = new Vector2(20, 255);
            uiPos = new Vector2(0, 0);

            fLine.X = pos.X + rad;
            bLine.X = pos.X - rad;

            hBarRec = new Rectangle(0, 0, sanityBar.Width, sanityBar.Height);
            sBarRec = new Rectangle(0, 0, staminaBar.Width, staminaBar.Height);
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
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
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
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
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
                        uiPos -= new Vector2(3, 0);
                    }
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                            speed.X = 6;
                        fLine -= new Vector2(6, 0);
                        bLine -= new Vector2(6, 0);
                        camPos -= new Vector2(6, 0);
                        uiPos -= new Vector2(6, 0);
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;
                    
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width*3 - 25)
                {
                    if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width*2)
                    {
                        fLine += new Vector2(3, 0);
                        bLine += new Vector2(3, 0);
                        camPos += new Vector2(3, 0);
                        uiPos += new Vector2(3, 0);
                    }
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        fLine += new Vector2(6, 0);
                        bLine += new Vector2(6, 0);
                        camPos += new Vector2(6, 0);
                        uiPos += new Vector2(6, 0);
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                {
                    speed.X = 0;
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
            ptext = "" + pos.ToString() + "" + speed.ToString();
            textPos = pos + new Vector2(5, 95);
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            //camera.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            dylight.BeginDraw();
            _spriteBatch.Draw(bGtile, (bgPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(bGtile2, (bgPos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(bGtile3, (bgPos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width + 720, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            if(speed.X == 0)
            {
                totalframe = 20; 
                _spriteBatch.Draw(pIdle, pos - camPos, new Rectangle(72 * frame, 0 , 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4 )
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            _spriteBatch.DrawString(deBugFont, text, (ballPos - new Vector2(0,20) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor,Color.White);
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor,hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0,33)) - camPos) * scroll_factor,sBarRec, Color.White);

            //SpotLight
            spotLight.Position = (new Vector2 (894,30) - camPos) * scroll_factor;
            spotLight2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLight3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
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
