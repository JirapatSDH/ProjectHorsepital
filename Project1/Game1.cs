using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
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

        bool personHit = false;
        Vector2 speed = new Vector2(3,3);
        int direction = 0;
        int rad = 50;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;

        //Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();   
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            //camera = new Camera(GraphicsDevice.Viewport);
            text = "";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bGtile = base.Content.Load<Texture2D>("IMG_0130");
            ballTexture = Content.Load<Texture2D>("ball");
            deBugFont = Content.Load<SpriteFont>("MyFont");
            farmer = Content.Load<Texture2D>("Char01");

            frame = 0;
            totalframe = 4;
            framepersec = 12;
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
                    if (pos.Y <= 240)
                    {
                        pos.Y = 240;
                    }
                    direction = 3;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    //pos.Y = 350;
                    pos.Y = pos.Y + speed.Y;
                    if (pos.Y >= 380)
                    {
                        pos.Y = 380;
                    }
                    direction = 0;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.A))
                {
                    if(pos.X <= bLine.X)
                    {
                        fLine -= new Vector2(3,0);
                        bLine -= new Vector2(3,0);
                        camPos -= new Vector2(3,0);   
                    }

                    pos.X = pos.X - speed.X;

                    if (pos.X < 0)
                    {
                        pos.X = 0;
                    }
                    direction = 1;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.D))
                {
                    if (pos.X >= fLine.X)
                    {
                        fLine += new Vector2(3, 0);
                        bLine += new Vector2(3, 0);
                        camPos += new Vector2(3, 0);
                    }

                    pos.X = pos.X + speed.X;

                    if (pos.X > 1415)
                    {
                        pos.X = 1415;
                    }
                    direction = 2;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 32, 48);
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


            //camera.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(bGtile, (bgPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(bGtile, (bgPos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos - camPos) * scroll_factor, new Rectangle(24, 0, 24, 24), (Color.White));
            _spriteBatch.Draw(farmer, pos - camPos, new Rectangle(32 * frame, 48 * direction, 32, 48), (Color.White));
            _spriteBatch.DrawString(deBugFont, text, (ballPos - new Vector2(0,20) - camPos) * scroll_factor, (Color.White));

            _spriteBatch.End();
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
