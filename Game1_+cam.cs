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
        
        public Texture2D farmer;
        public Vector2 pos;
        public Rectangle rec;

        int speed = 3;
        int direction = 0;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;

        Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 480;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bGtile = base.Content.Load<Texture2D>("test");
            farmer = Content.Load<Texture2D>("Char01");
            frame = 0;
            totalframe = 4;
            framepersec = 12;
            timeperframe = (float)1 / framepersec;
            totalelapsed = 0;
            pos = new Vector2(720,270);
            // TODO: use this.Content to load your game content here
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
                    pos.Y = pos.Y - speed;
                    if(pos.Y <= 240)
                    {
                        pos.Y = 240;
                    }
                    direction = 3;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    //pos.Y = 350;
                    pos.Y = pos.Y + speed;
                    if (pos.Y >= 380)
                    {
                        pos.Y = 380;
                    }
                    direction = 0;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.A))
                {
                    pos.X = pos.X - speed;
                    if(pos.X < 0)
                    {
                        pos.X = 0;
                    }
                    direction = 1;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (ks.IsKeyDown(Keys.D))
                {
                    pos.X = pos.X + speed;
                    if (pos.X > 1415)
                    {
                        pos.X = 1415;
                    }
                    direction = 2;
                    UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            // TODO: Add your update logic here

            camera.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null,null,null,null, camera.transform);
            _spriteBatch.Draw(bGtile, new Vector2(0f, 0f), new Rectangle?(new Rectangle(0, 0, bGtile.Width, bGtile.Height)), Color.White);
            _spriteBatch.Draw(farmer, pos, new Rectangle(32 * frame, 48 * direction, 32, 48), (Color.White));
            // TODO: Add your drawing code here
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
