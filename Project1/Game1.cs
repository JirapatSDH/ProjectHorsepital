using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Penumbra;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Transactions;
using SharpDX.MediaFoundation;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        Screenstate mCurrentScreen;
        enum Screenstate
        {
            Title,
            Room1,
            Room2,
            Room3,
            Room4,
            Room5,
            Room7,
            over
        }
        PenumbraComponent dylight;
        private SpriteBatch _spriteBatch;
        private Texture2D room1;
        private Texture2D room2_1;
        private Texture2D room2_2;
        private Texture2D room2_3;
        private Texture2D room3;
        private Texture2D room4;
        private Texture2D room5_1;
        private Texture2D room5_2;
        private Texture2D room7;
        private Texture2D menu;
        private Texture2D menuchar1;
        private Texture2D menuchar2;
        private Texture2D menuGlitch;
        private Texture2D overGlitch;
        private Texture2D overMenu;
        private Texture2D ballTexture;
        private Texture2D ball2Texture;
        private Texture2D ball3Texture;
        private Texture2D uiTexture;
        private Texture2D sanityBar;
        private Texture2D staminaBar;
        private Texture2D eTexture;
        private Texture2D trap;
        private Texture2D eWalk;
        private SpriteFont deBugFont;

        public Texture2D farmer;
        public Texture2D pIdle;
        public Vector2 pos;
        public Vector2 bg2Pos = Vector2.Zero;
        public Vector2 bg5Pos = Vector2.Zero;
        public Vector2 ballPos = new Vector2(0,0);
        public Vector2 ballPos2_1 = new Vector2(0, 0);
        public Vector2 ballPos2_3 = new Vector2(0, 0);
        public Vector2 ballPos2_4 = new Vector2(0, 0);
        public Vector2 ballPos2_7 = new Vector2(0, 0);
        public Vector2 ballPos3_2 = new Vector2(0, 0);
        public Vector2 ballPos4_2 = new Vector2(0, 0);
        public Vector2 ballPos4_5 = new Vector2(0, 0);
        public Vector2 ballPos7_2 = new Vector2(0, 0);
        public Vector2 textPos;
        public Vector2 uiPos;
        public Vector2 sbarPos = new Vector2(73,12);

        Vector2 camPos = Vector2.Zero;
        Vector2 fLine, bLine;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        public Rectangle enemyRec;
        public Rectangle rec;
        private string toRoom_2;
        private string backRoom2_1;
        private string toRoom_3;
        private string backRoom3_2;
        private string toRoom_4;
        private string backRoom4_2;
        private string toRoom_5;
        private string backRoom5_4;
        private string toRoom_7;
        private string backRoom7_2;
        private string ptext;
        public Rectangle hBarRec;
        public Rectangle sBarRec;
        public bool personHit;
        public bool personHit2;
        public bool personHit3;
        public bool personHit4;
        Vector2 speed = new Vector2(3,3);
        int direction = 0;
        int rad = 50;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;
        float elapsed;

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
        int eframe;
        int etotalframe;
        int eframepersec;
        float etimeperframe;
        float etotalelapsed;
        public Light eLight { get; } = new PointLight
        {
            Color = new Color(255, 0, 0),
            Scale = new Vector2(400),
            Intensity = 1.5f
        };
        public Vector2 ePos;
        public Vector2 trapPos;
        Vector2 eSpeed = new Vector2(1, 1);

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
            toRoom_2 = "";
            backRoom2_1 = "";
            toRoom_3 = "";
            backRoom3_2 = "";
            toRoom_4 = "";
            backRoom4_2 = "";
            toRoom_5 = "";
            backRoom5_4 = "";
            toRoom_7 = "";
            backRoom7_2 = "";
            ptext = "";
            
            base.Initialize();
            dylight.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            room2_1 = base.Content.Load<Texture2D>("2-1D");
            room2_2 = base.Content.Load<Texture2D>("2-2D");
            room2_3 = base.Content.Load<Texture2D>("2-3D");
            room3 = base.Content.Load<Texture2D>("3D");
            room4 = base.Content.Load<Texture2D>("4D");
            room5_1 = base.Content.Load<Texture2D>("5-1D");
            room5_2 = base.Content.Load<Texture2D>("5-2D");
            room7 = base.Content.Load<Texture2D>("7D");
            ballTexture = Content.Load<Texture2D>("ball");
            ball2Texture = Content.Load<Texture2D>("ball");
            ball3Texture = Content.Load<Texture2D>("ball");
            deBugFont = Content.Load<SpriteFont>("MyFont");
            farmer = Content.Load<Texture2D>("kaolad_walk_newV2");
            pIdle = Content.Load<Texture2D>("kaolad_standing");
            uiTexture = Content.Load<Texture2D>("UI_emty");
            sanityBar = Content.Load<Texture2D>("SanityBar");
            staminaBar = Content.Load<Texture2D>("StaminaBar");
            eTexture = Content.Load<Texture2D>("Ghost_stand");
            eWalk = Content.Load<Texture2D>("Ghost_walk");
            trap = Content.Load<Texture2D>("Hand_up-down");
            room1 = Content.Load<Texture2D>("1D");
            menu = Content.Load<Texture2D>("MainMenu_bg");
            menuchar1 = Content.Load<Texture2D>("MainMenu_kaolad1");
            menuchar2 = Content.Load<Texture2D>("MainMenu_kaolad2");
            menuGlitch = Content.Load<Texture2D>("Horspital_glitch");
            overMenu = Content.Load<Texture2D>("Gameover_bg");
            overGlitch = Content.Load<Texture2D>("Game over_glitch");

            frame = 0;
            totalframe = 4;
            framepersec = 6;
            timeperframe = (float)1 / framepersec;
            totalelapsed = 0;

            eframe = 0;
            etotalframe = 5;
            eframepersec = 6;
            etimeperframe = (float)1 / eframepersec;
            etotalelapsed = 0;

            pos = new Vector2(150, 270);
            ballPos = new Vector2(650, 250);
            ballPos2_1 = new Vector2(20, 255);
            ballPos2_3 = new Vector2(1730, 200);
            ballPos3_2 = new Vector2(250, 200);
            ballPos2_4 = new Vector2(930, 200);
            ballPos4_2 = new Vector2(460, 200);
            ballPos4_5 = new Vector2(200, 200);
            ballPos2_7 = new Vector2(250, 200);
            ballPos7_2 = new Vector2(310, 200);
            uiPos = new Vector2(0, 0);
            ePos = new Vector2(1850,170);
            trapPos = new Vector2(900, 340);

            fLine.X = pos.X + rad;
            bLine.X = pos.X - rad;

            hBarRec = new Rectangle(0, 0, sanityBar.Width, sanityBar.Height);
            sBarRec = new Rectangle(0, 0, staminaBar.Width, staminaBar.Height);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (mCurrentScreen)
            {
                case Screenstate.Title:
                    {
                        UpdateTitle();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
                case Screenstate.Room1:
                    {
                        UpdateRoom1();
                        dylight.AmbientColor = new Color(new Vector3(0.3f));
                        break;
                    }
                case Screenstate.Room2:
                    {
                        UpdateRoom2();
                        dylight.AmbientColor = new Color(new Vector3(0.2f));
                        break;
                    }
                case Screenstate.Room3:
                    {
                        UpdateRoom3();
                        dylight.AmbientColor = new Color(new Vector3(0.3f));
                        break;
                    }
                case Screenstate.Room4:
                    {
                        UpdateRoom4();
                        dylight.AmbientColor = new Color(new Vector3(0.3f));
                        break;
                    }
                case Screenstate.Room5:
                    {
                        UpdateRoom5();
                        dylight.AmbientColor = new Color(new Vector3(0.2f));
                        break;
                    }
                case Screenstate.Room7:
                    {
                        UpdateRoom7();
                        dylight.AmbientColor = new Color(new Vector3(0.3f));
                        break;
                    }
                case Screenstate.over:
                    {
                        UpdateOver();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
            }
            
            //camera.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            dylight.BeginDraw();
            
            switch (mCurrentScreen)
            {
                case Screenstate.Title:
                    {
                        DrawMenu();
                        break;
                    }
                case Screenstate.Room1:
                    {
                        DrawRoom1();
                        break;
                    }
                case Screenstate.Room2:
                    {
                        DrawRoom2();
                        break;
                    }
                case Screenstate.Room3:
                    {
                        DrawRoom3();
                        break;
                    }
                case Screenstate.Room4:
                    {
                        DrawRoom4();
                        break;
                    }
                case Screenstate.Room5:
                    {
                        DrawRoom5();
                        break;
                    }
                case Screenstate.Room7:
                    {
                        DrawRoom7();
                        break;
                    }
                case Screenstate.over:
                    {
                        DrawOver();
                        break;
                    }
            }
            _spriteBatch.End();
            dylight.Draw(gameTime);
            base.Draw(gameTime);
        }
        void UpdateRoom1()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) == true)
            {
                mCurrentScreen = Screenstate.Title;
            }
            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room2;
                pos.X = 48;
            }
            ProcessInput();
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
                    speed.X = 3;
                    direction = 3;
                    UpdateFrame(elapsed);
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
                    speed.X = 3;
                    direction = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
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
                    UpdateFrame(elapsed);
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos.X, (int)ballPos.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {

                toRoom_2 = "F To Enter";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        toRoom_2 = "Enter room ?";
                        personHit2 = true;
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit2 = false;
                toRoom_2 = "Check";
            }
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateTitle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)==true)
            {
                mCurrentScreen = Screenstate.Room1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O) == true)
            {
                mCurrentScreen = Screenstate.Room2;
            }
            UpdateFrame(elapsed);
        }
        void UpdateOver()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                mCurrentScreen = Screenstate.Title;
            }
            UpdateFrame(elapsed);
        }
        void UpdateRoom2()
        {
            
            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room1;
                spotLight.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLight2.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLight3.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLight4.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                pos.X = 580;
            }

            if(personHit == true)
            {
                mCurrentScreen = Screenstate.Room3;
                pos.X = 200;
            }

            if(personHit3 == true)
            {
                mCurrentScreen = Screenstate.Room4;
                pos.X = 500;
            }

            if(personHit4 == true)
            {
                mCurrentScreen = Screenstate.Room7;
                pos.X = 350;
            }

            if (hBarRec.Width <= 0)
            {
                mCurrentScreen = Screenstate.over;
            }
            ProcessInput();
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
                    speed.X = 3;
                    direction = 3;
                    UpdateFrame(elapsed);
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
                    speed.X = 3;
                    direction = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
                {
                    if (pos.X <= bLine.X && camPos.X > 0)
                    {
                        fLine -= new Vector2(3, 0);
                        bLine -= new Vector2(3, 0);
                        camPos -= new Vector2(3, 0);
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

                    UpdateFrame(elapsed);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width * 3 - 25)
                {
                    if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width * 2)
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
                    UpdateFrame(elapsed);
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
                    UpdateFrame(elapsed);
                }
                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos2_1.X, (int)ballPos2_1.Y, 24, 24);
                Rectangle ball2_3Rectangle = new Rectangle((int)ballPos2_3.X, (int)ballPos2_3.Y, 24, 24);
                Rectangle ball2_4Rectangle = new Rectangle((int)ballPos2_4.X, (int)ballPos2_4.Y, 24, 24);
                Rectangle ball2_7Rectangle = new Rectangle((int)ballPos2_7.X, (int)ballPos2_7.Y, 24, 24);
                Rectangle enemyRectangle = new Rectangle((int)ePos.X, (int)ePos.Y, 60, 100);
                Rectangle trapRectangle = new Rectangle((int)trapPos.X, (int)trapPos.Y, 100, 100);

                if (personRectangle.Intersects(trapRectangle) == true)
                {
                    sBarRec.Width -= 3;
                }
                else if (personRectangle.Intersects(trapRectangle) == false)
                {

                }
                if (personRectangle.Intersects(enemyRectangle) == true)
                {
                    hBarRec.Width -= 5;
                }
                else if (personRectangle.Intersects(enemyRectangle) == false)
                {
                    UpdateEnemy(elapsed);
                }

                if (personRectangle.Intersects(ballRectangle) == true)
                {

                    backRoom2_1 = "F To Enter";
                    {
                        if (ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            backRoom2_1 = "Enter room ?";
                            personHit2 = true;
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit2 = false;
                    backRoom2_1 = "Check";
                }
                if(personRectangle.Intersects(ball2_3Rectangle) == true)
                {
                    toRoom_3 = "F To Enter";
                    if (ks.IsKeyDown(Keys.F)) //Tnteract object
                    {
                        toRoom_3 = "Enter room ?";
                        personHit = true;
                    }
                }
                else if(personRectangle.Intersects(ball2_3Rectangle) == false)
                {
                    personHit = false;
                    toRoom_3 = "Check";
                }
                if (personRectangle.Intersects(ball2_4Rectangle) == true)
                {
                    toRoom_4 = "F To Enter";
                    if (ks.IsKeyDown(Keys.F)) //Tnteract object
                    {
                        toRoom_4 = "Enter room ?";
                        personHit3 = true;
                    }
                }
                else if (personRectangle.Intersects(ball2_4Rectangle) == false)
                {
                    personHit3 = false;
                    toRoom_4 = "Check";
                }
                if (personRectangle.Intersects(ball2_7Rectangle) == true)
                {
                    toRoom_7 = "F To Enter";
                    if (ks.IsKeyDown(Keys.F)) //Tnteract object
                    {
                        toRoom_7 = "Enter room ?";
                        personHit4 = true;
                    }
                }
                else if (personRectangle.Intersects(ball2_7Rectangle) == false)
                {
                    personHit4 = false;
                    toRoom_7 = "Check";
                }

                old_ks = ks;
            }
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);
            ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdateRoom3()
        {

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room2;
                pos.X = 1675;
            }

            ProcessInput();
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
                    speed.X = 3;
                    direction = 3;
                    UpdateFrame(elapsed);
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
                    speed.X = 3;
                    direction = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
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
                    UpdateFrame(elapsed);
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos3_2.X, (int)ballPos3_2.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom3_2 = "F To Enter";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        backRoom3_2 = "Enter room ?";
                        personHit = true;
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom3_2 = "Check";
            }
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateRoom4()
        {

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room2;
                pos.X = 880;
            }

            if(personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room5;
                pos.X = 100;
            }

            ProcessInput();
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
                    speed.X = 3;
                    direction = 3;
                    UpdateFrame(elapsed);
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
                    speed.X = 3;
                    direction = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
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
                    UpdateFrame(elapsed);
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos4_2.X, (int)ballPos4_2.Y, 24, 24);
            Rectangle ball2Rectangle = new Rectangle((int)ballPos4_5.X, (int)ballPos4_5.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom4_2 = "F To Enter";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        backRoom4_2 = "Enter room ?";
                        personHit = true;
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom4_2 = "Check";
            }
            if (personRectangle.Intersects(ball2Rectangle) == true)
            {
                toRoom_5 = "F To Enter";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        toRoom_5 = "Enter room ?";
                        personHit2 = true;
                    }
                }
            }
            else if (personRectangle.Intersects(ball2Rectangle) == false)
            {
                personHit = false;
                toRoom_5 = "Check";
            }
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateRoom5()
        {
            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room1;
                spotLight.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLight2.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLight3.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLight4.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                pos.X = 580;
            }

            if (hBarRec.Width <= 0)
            {
                mCurrentScreen = Screenstate.over;
            }
            ProcessInput();
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
                    speed.X = 3;
                    direction = 3;
                    UpdateFrame(elapsed);
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
                    speed.X = 3;
                    direction = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
                {
                    if (pos.X <= bLine.X && camPos.X > 0)
                    {
                        fLine -= new Vector2(3, 0);
                        bLine -= new Vector2(3, 0);
                        camPos -= new Vector2(3, 0);
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

                    UpdateFrame(elapsed);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width * 2 - 25)
                {
                    if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width)
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
                    UpdateFrame(elapsed);
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
                    UpdateFrame(elapsed);
                }
                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos2_1.X, (int)ballPos2_1.Y, 24, 24);
                Rectangle enemyRectangle = new Rectangle((int)ePos.X, (int)ePos.Y, 60, 100);
                Rectangle trapRectangle = new Rectangle((int)trapPos.X, (int)trapPos.Y, 100, 100);

                if (personRectangle.Intersects(trapRectangle) == true)
                {
                    sBarRec.Width -= 3;
                }
                else if (personRectangle.Intersects(trapRectangle) == false)
                {

                }
                if (personRectangle.Intersects(enemyRectangle) == true)
                {
                    hBarRec.Width -= 5;
                }
                else if (personRectangle.Intersects(enemyRectangle) == false)
                {
                    UpdateEnemy(elapsed);
                }

                if (personRectangle.Intersects(ballRectangle) == true)
                {

                    backRoom2_1 = "F To Enter";
                    {
                        if (ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            backRoom2_1 = "Enter room ?";
                            personHit2 = true;
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit2 = false;
                    backRoom2_1 = "Check";
                }
               
                old_ks = ks;
            }
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);
            ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdateRoom7()
        {

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room2;
                pos.X = 200;
            }

            ProcessInput();
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
                    speed.X = 3;
                    direction = 3;
                    UpdateFrame(elapsed);
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
                    speed.X = 3;
                    direction = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyDown(Keys.A) && pos.X > 30)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
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
                    UpdateFrame(elapsed);
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos7_2.X, (int)ballPos7_2.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom7_2 = "F To Enter";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        backRoom7_2 = "Enter room ?";
                        personHit = true;
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom7_2 = "Check";
            }
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void DrawRoom1()
        {
            _spriteBatch.Draw(room1, (bg2Pos - camPos) * scroll_factor, Color.White);
            if (speed.X <= 0)
            {
                totalframe = 20;
                _spriteBatch.Draw(pIdle, pos - camPos, new Rectangle(72 * frame, 0, 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4)
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture,ballPos , new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_2, (ballPos - new Vector2(0, 20)) ,(Color.White));
        }
        void DrawMenu()
        {
            _spriteBatch.Draw(menu, bg2Pos , Color.White);
            _spriteBatch.Draw(menuchar1, bg2Pos, Color.White);
            _spriteBatch.Draw(menuGlitch, new Vector2(30, 50), new Rectangle(722 * frame, 0, 722, 482), Color.White);
        }
        void DrawOver()
        {
            _spriteBatch.Draw(overMenu, bg2Pos, Color.White);
            _spriteBatch.Draw(overGlitch, new Vector2(10, 10), new Rectangle(722 * frame, 0, 722, 482), Color.White);
        }
        void DrawRoom2()
        {
            _spriteBatch.Draw(room2_1, (bg2Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(room2_2, (bg2Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(room2_3, (bg2Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width + 720, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos2_1 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, (ballPos2_3 - camPos) * scroll_factor, new Rectangle(0,24,0,0), (Color.White));
            _spriteBatch.Draw(ball3Texture, (ballPos2_4 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball3Texture, (ballPos2_7 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(trap, trapPos - camPos * scroll_factor, new Rectangle(0, 0, 26, 26), (Color.White));
            if (speed.X <= 0)
            {
                totalframe = 20;
                _spriteBatch.Draw(pIdle, pos - camPos, new Rectangle(72 * frame, 0, 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4)
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            _spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 120, 120), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom2_1, (ballPos2_1 - new Vector2(0, 20) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_3, (ballPos2_3 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_4, (ballPos2_4 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_7, (ballPos2_7 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            //SpotLight
            spotLight.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLight2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLight3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLight4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }
        void DrawRoom3()
        {
            _spriteBatch.Draw(room3, Vector2.Zero, Color.White);
            if (speed.X <= 0)
            {
                totalframe = 20;
                _spriteBatch.Draw(pIdle, pos, new Rectangle(72 * frame, 0, 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4)
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos3_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom3_2, (ballPos3_2 - new Vector2(0, 80)), (Color.White));
        }
        void DrawRoom4()
        {
            _spriteBatch.Draw(room4, Vector2.Zero, Color.White);
            if (speed.X <= 0)
            {
                totalframe = 20;
                _spriteBatch.Draw(pIdle, pos, new Rectangle(72 * frame, 0, 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4)
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos4_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, ballPos4_5, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom4_2, (ballPos4_2 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_5, (ballPos4_5 - new Vector2(0, 80)), (Color.White));
        }
        void DrawRoom5()
        {
            _spriteBatch.Draw(room5_1, (bg5Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(room5_2, (bg5Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            //_spriteBatch.Draw(ballTexture, (ballPos2_1 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            if (speed.X <= 0)
            {
                totalframe = 20;
                _spriteBatch.Draw(pIdle, pos - camPos, new Rectangle(72 * frame, 0, 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4)
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            //_spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 120, 120), (Color.White));
            //_spriteBatch.DrawString(deBugFont, backRoom2_1, (ballPos2_1 - new Vector2(0, 20) - camPos) * scroll_factor, (Color.White));
            //_spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            //_spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            //_spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            //_spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            //SpotLight
            spotLight.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLight2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLight3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLight4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }
        void DrawRoom7()
        {
            _spriteBatch.Draw(room7, Vector2.Zero, Color.White);
            if (speed.X <= 0)
            {
                totalframe = 20;
                _spriteBatch.Draw(pIdle, pos, new Rectangle(72 * frame, 0, 72, 96), (Color.White));
            }
            else
            {
                if (totalframe > 4)
                {
                    frame = 0;
                }
                totalframe = 4;
                _spriteBatch.Draw(farmer, pos, new Rectangle(72 * frame, 100 * direction, 72, 100), (Color.White));
            }
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos7_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom7_2, (ballPos7_2 - new Vector2(0, 80)), (Color.White));
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
        void UpdateEnemy(float elapsed)
        {
            etotalelapsed += elapsed;
            if (etotalelapsed > etimeperframe)
            {
                eframe = (eframe + 1) % etotalframe;
                etotalelapsed -= etimeperframe;
            }
        }
        protected void ProcessInput()
        {
            // TODO: Add your input handle here


        }
    }
}
