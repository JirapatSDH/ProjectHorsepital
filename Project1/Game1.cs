using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Penumbra;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Transactions;
using SharpDX.MediaFoundation;
using System.Security.Cryptography.Xml;
using SharpDX.XAudio2;
using SharpDX.Direct2D1.Effects;
using System.Diagnostics;
using Application = System.Windows.Forms.Application;
using SharpDX.XInput;
using System.Threading;
using SharpDX.Direct2D1;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using SharpDX.DirectWrite;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        Screenstate mCurrentScreen;

        enum Screenstate
        {
            Title,
            startcutscene,
            Room1,
            Room2,
            Room3,
            Room4,
            Room5,
            Room6,
            Room7,
            LRoom1,
            LRoom2,
            LRoom3,
            LRoom4,
            LRoom5,
            LRoom6,
            LRoom7,
            LRoom8,
            PipePuzz,
            PassPuzz,
            endcutscene,
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
        private Texture2D room6;
        private Texture2D room7;
        private Texture2D Lroom1;
        private Texture2D Lroom2_1;
        private Texture2D Lroom2_2;
        private Texture2D Lroom2_3;
        private Texture2D Lroom3;
        private Texture2D Lroom4;
        private Texture2D Lroom5_1;
        private Texture2D Lroom5_2;
        private Texture2D Lroom6;
        private Texture2D Lroom7;
        private Texture2D Lroom8_1;
        private Texture2D Lroom8_2;
        private Texture2D Lroom8_3;
        private Texture2D menu;
        private Texture2D menuBG;
        private Texture2D menuchar2;
        private Texture2D menuCharGlitch;
        private Texture2D menuGlitch;
        private Texture2D start_cut1;
        private Texture2D overGlitch;
        private Texture2D overMenu;
        private Texture2D end_cut;
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
        private Texture2D paperTu;
        private Texture2D tutorial;
        private Texture2D tutorial2;
        private Texture2D tutorial3;
        public Texture2D farmer;
        public Texture2D pIdle;
        public Texture2D note1;
        public Texture2D note2;
        public Texture2D normal_mood;
        public Texture2D cry_mood;
        public Texture2D fear_mood;
        public Vector2 pos;
        public Vector2 bg2Pos = Vector2.Zero;
        public Vector2 bg5Pos = Vector2.Zero;
        public Vector2 ballPos = new Vector2(0, 0);
        public Vector2 ballPos2_1 = new Vector2(0, 0);
        public Vector2 ballPos2_3 = new Vector2(0, 0);
        public Vector2 ballPos2_4 = new Vector2(0, 0);
        public Vector2 ballPos2_7 = new Vector2(0, 0);
        public Vector2 ballPos3_2 = new Vector2(0, 0);
        public Vector2 ballPos4_2 = new Vector2(0, 0);
        public Vector2 ballPos4_5 = new Vector2(0, 0);
        public Vector2 ballPos5_4 = new Vector2(0, 0);
        public Vector2 ballPos5_6 = new Vector2(0, 0);
        public Vector2 ballPos6_5 = new Vector2(0, 0);
        public Vector2 ballPos7_2 = new Vector2(0, 0);
        public Vector2 ballPos8 = new Vector2(0, 0);
        public Vector2 ballPos8_End = new Vector2(0, 0);
        public Vector2 puzzlePos1 = new Vector2(0, 0);
        public Vector2 puzzlePos2 = new Vector2(0, 0);
        public Vector2 puzzlePos3 = new Vector2(0, 0);
        public Vector2 ballLockerR2_1 = new Vector2(0, 0);
        public Vector2 ballLockerR2_2 = new Vector2(0, 0);
        public Vector2 ballLockerR3 = new Vector2(0, 0);
        public Vector2 ballLockerR5 = new Vector2(0, 0);
        public Vector2 textPos;
        public Vector2 uiPos;
        public Vector2 uiPos5;
        public Vector2 sbarPos = new Vector2(73, 12);
        public Vector2 paperPos = new Vector2(240, 300);
        public Vector2 capetPos = new Vector2(0, 0);
        public Vector2 note1Pos = new Vector2(0, 0);
        public Vector2 note2Pos = new Vector2(0, 0);

        Vector2 camPos = Vector2.Zero;
        //Vector2 camPos5 = Vector2.Zero;
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
        private string toRoom_6;
        private string backRoom6_5;
        private string toRoom_7;
        private string backRoom7_2;
        private string toRoom_8;
        private string toEnd;
        private string ptext;
        private string puzzle1;
        private string puzzle3;
        private string puzzle2;
        private string tu1;
        private string tu2;
        private string locker2_1;
        private string locker2_2;
        private string locker3;
        private string locker5;
        private string capetText;
        public Rectangle hBarRec;
        public Rectangle sBarRec;
        public bool personHit;
        public bool personHit2;
        public bool personHit3;
        public bool personHit4;
        public bool personHit5;
        public bool personHit6;
        public static bool isHide;
        public static bool isSearch = false;
        bool isRead;
        Vector2 speed = new Vector2(3, 3);
        int direction = 0;
        int rad = 50;

        int bgframe;
        int bgtotalframe;
        int bgframepersec;
        float bgtimeperframe;
        float bgtotalelapsed;

        int startframe;
        int starttotalframe;
        float startframepersec;
        float starttimeperframe;
        float starttotalelapsed;

        int endframe;
        int endtotalframe;
        float endframepersec;
        float endtimeperframe;
        float endtotalelapsed;

        int normalframe;
        int normaltotalframe;
        int normalframepersec;
        float normaltimeperframe;
        float normaltotalelapsed;

        int cryframe;
        int crytotalframe;
        int cryframepersec;
        float crytimeperframe;
        float crytotalelapsed;

        int fearframe;
        int feartotalframe;
        int fearframepersec;
        float feartimeperframe;
        float feartotalelapsed;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;
        float elapsed;

        float cooldowntime = 0;
        SoundEffect bgm;
        SoundEffectInstance instance;

        SoundEffect walk;
        SoundEffectInstance w_instance;
        AudioListener w_listener;
        AudioEmitter w_emitter;

        SoundEffect run;
        SoundEffectInstance r_instance;
        AudioListener r_listener;
        AudioEmitter r_emitter;

        SoundEffect door;
        SoundEffectInstance d_instance;
        AudioListener d_listener;
        AudioEmitter d_emitter;

        SoundEffect ghost1;
        SoundEffectInstance g1_instance;
        AudioListener g1_listener;
        AudioEmitter g1_emitter;

        SoundEffect ghost2;
        SoundEffectInstance g2_instance;
        AudioListener g2_listener;
        AudioEmitter g2_emitter;

        SoundEffect search;
        SoundEffectInstance s_instance;
        AudioListener s_listener;
        AudioEmitter s_emitter;

        SoundEffect paperFlip;
        SoundEffectInstance p_instance;
        AudioListener p_listener;
        AudioEmitter p_emitter;

        SoundEffect genaretor;
        SoundEffectInstance gen_instance;
        AudioListener gen_listener;
        AudioEmitter gen_emitter;

        SoundEffect chase;
        SoundEffectInstance c_instance;
        AudioListener c_listener;
        AudioEmitter c_emitter;


        /// -----------------------------------------------------------------------------<PuzlePipe>
        Texture2D playingPieces;
        Pipeboard pipeboard;
        int playerScore = 0;

        Vector2 gameBoardDisplayOrigin = new Vector2(270, 89);
        bool isClear = false;
        bool isPipe1Clear = false;
        bool isPipe2Clear = false;
        bool inRoom6 = false;

        Rectangle EmptyPiece = new Rectangle(1, 247, 40, 40);
        const float MinTimeSinceLastInput = 0.25f;
        float timeSinceLastInput = 0.0f;

        int passNum1 = 2;
        int passNum2 = 4;
        int passNum3 = 3;
        int passNum4 = 2;
        KeyboardState old_ks;
        Texture2D passTexture;
        Texture2D passBackgroud;
        /// -----------------------------------------------------------------------------<PuzzlePipe>
        /// -----------------------------------------------------------------------------<Item>
        Texture2D sPill;
        Texture2D hPill;
        Texture2D keyNormal;
        Texture2D keyStory;

        public static string sanityText;
        public static string staminaText;
        public static string gotItemText;
        public static int sanity = 0;
        public static int stamina = 0;

        bool cKey1 = false;
        bool cKey2 = false;

        Vector2 sanityPos;
        Vector2 staminaPos;
        Vector2 gotItemPos = new Vector2(0, 0);
        Vector2 textsanityPos;
        Vector2 textstaminaPos;
        Vector2 key1Pos;
        Vector2 key2Pos;
        //--------------------------------------------------------------------------Set Light---------------------------------------------
        Light light2 = new Spotlight
        {
            Color = Color.White,
            Scale = new Vector2(0f),
            Radius = 100,
            CastsShadows = false,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 300.5f,
            ShadowType = ShadowType.Solid
        };
        Light light = new PointLight
        {
            Scale = new Vector2(200f),
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR2_1 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR2_2 = new Spotlight
        {
            Color = Color.Yellow,
            Scale = new Vector2(400),
            Radius = 120,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 2.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR2_3 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR2_4 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR3 = new Spotlight
        {
            Color = Color.Yellow,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR4 = new Spotlight
        {
            Color = Color.Yellow,
            Scale = new Vector2(400),
            Radius = 120,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR6 = new Spotlight
        {
            Color = Color.Yellow,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        Light spotLightR7 = new Spotlight
        {
            Color = Color.YellowGreen,
            Scale = new Vector2(400),
            Radius = 90,
            Rotation = MathHelper.Pi - MathHelper.PiOver2 * 1f,
            ConeDecay = 1.5f,
            ShadowType = ShadowType.Illuminated
        };
        //-------------------------------------------------------------enemy-----------------------------------------------------------------------
        Texture2D ghostStand;
        Texture2D ghostWalk;
        Enemy enemy;
        bool isAlive = true;
        int eframe;
        int etotalframe;
        int eframepersec;
        float etimeperframe;
        float etotalelapsed;

        int gdirection;
        int gframe;
        int gtotalframe;
        int gframepersec;
        float gtimeperframe;
        float gtotalelapsed;

        public Light eLight { get; } = new PointLight
        {
            Color = new Color(255, 0, 0),
            Scale = new Vector2(400),
            Intensity = 1.5f
        };
        public Vector2 ePos;
        public Vector2 gPos;
        public Vector2 trapPos;
        Vector2 eSpeed = new Vector2(1, 1);
        private string tu3;
        private bool isRead2;
        private bool isSearch2 = false;
        private bool isSearch3 = false;
        private bool isHuant1 = false;
        private bool isHuant2 = false;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 480;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            dylight = new PenumbraComponent(this);
            //add Light
            pipeboard = new Pipeboard();

            dylight.Lights.Add(light);
            dylight.Lights.Add(light2);
            dylight.Lights.Add(spotLightR2_1);
            dylight.Lights.Add(spotLightR2_2);
            dylight.Lights.Add(spotLightR2_3);
            dylight.Lights.Add(spotLightR2_4);
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
            toRoom_6 = "";
            backRoom6_5 = "";
            toRoom_7 = "";
            backRoom7_2 = "";
            toRoom_8 = "";
            toEnd = "";
            ptext = "";
            puzzle1 = "";
            puzzle2 = "";
            puzzle3 = "";
            tu1 = "";
            tu2 = "";
            tu3 = "";
            locker2_1 = "";
            locker2_2 = "";
            locker3 = "";
            locker5 = "";
            capetText = "";
            gotItemText = "";
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            base.Initialize();
            dylight.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            room2_1 = base.Content.Load<Texture2D>("2-1D");
            room2_2 = base.Content.Load<Texture2D>("2-2 D fix");
            room2_3 = base.Content.Load<Texture2D>("2-3 D fix");
            room3 = base.Content.Load<Texture2D>("3 D fix");
            room4 = base.Content.Load<Texture2D>("4D");
            room5_1 = base.Content.Load<Texture2D>("5-1D");
            room5_2 = base.Content.Load<Texture2D>("5-2 D fix");
            room6 = base.Content.Load<Texture2D>("6D");
            room7 = base.Content.Load<Texture2D>("7D");
            Lroom1 = Content.Load<Texture2D>("1L");
            Lroom2_1 = Content.Load<Texture2D>("2-1L");
            Lroom2_2 = Content.Load<Texture2D>("2-2L");
            Lroom2_3 = Content.Load<Texture2D>("2-3L");
            Lroom3 = Content.Load<Texture2D>("3L");
            Lroom4 = Content.Load<Texture2D>("4L");
            Lroom5_1 = Content.Load<Texture2D>("5-1L");
            Lroom5_2 = Content.Load<Texture2D>("5-2L");
            Lroom6 = Content.Load<Texture2D>("6L");
            Lroom7 = Content.Load<Texture2D>("7L");
            Lroom8_1 = Content.Load<Texture2D>("8-1L");
            Lroom8_2 = Content.Load<Texture2D>("8-3L");
            Lroom8_3 = Content.Load<Texture2D>("8-2L");
            ballTexture = Content.Load<Texture2D>("ball");
            ball2Texture = Content.Load<Texture2D>("ball");
            ball3Texture = Content.Load<Texture2D>("ball");
            deBugFont = Content.Load<SpriteFont>("MyFont");
            farmer = Content.Load<Texture2D>("kaolad_walk_newV2");
            pIdle = Content.Load<Texture2D>("kaolad_standing");
            normal_mood = Content.Load<Texture2D>("normal_mood_spritesheet");
            cry_mood = Content.Load<Texture2D>("cry_mood_spritesheet");
            fear_mood = Content.Load<Texture2D>("fear_mood_spritesheet");
            uiTexture = Content.Load<Texture2D>("UI_emty");
            sanityBar = Content.Load<Texture2D>("SanityBar");
            staminaBar = Content.Load<Texture2D>("StaminaBar");
            eTexture = Content.Load<Texture2D>("Ghost_stand");
            eWalk = Content.Load<Texture2D>("Ghost_walk");
            trap = Content.Load<Texture2D>("Hand_up-down");
            room1 = Content.Load<Texture2D>("1D");
            menu = Content.Load<Texture2D>("MainMenu_new");
            menuBG = Content.Load<Texture2D>("Empty_Screen_Menu");
            menuchar2 = Content.Load<Texture2D>("MainMenu_kaolad2");
            menuCharGlitch = Content.Load<Texture2D>("MainMenu_kaolad_Tile1");
            menuGlitch = Content.Load<Texture2D>("Horspital_glitch");
            start_cut1 = Content.Load<Texture2D>("startcutscene");
            end_cut = Content.Load<Texture2D>("endcutscene");
            overMenu = Content.Load<Texture2D>("Gameover_bg");
            overGlitch = Content.Load<Texture2D>("Game over_glitch");
            playingPieces = Content.Load<Texture2D>("0669_02_03");
            enemy = new Enemy(Content.Load<Texture2D>("Ghost_walk"), new Vector2(1261,352),440);
            passTexture = Content.Load<Texture2D>("passPuzzle");
            paperTu = Content.Load<Texture2D>("Paper");
            tutorial = Content.Load<Texture2D>("Pong_thai");
            tutorial2 = Content.Load<Texture2D>("2");
            tutorial3 = Content.Load<Texture2D>("3");
            passBackgroud = Content.Load<Texture2D>("passPuzzle-BackGround");
            sPill = Content.Load<Texture2D>("stamina_pill");
            hPill = Content.Load<Texture2D>("sanity_pill");
            note1 = Content.Load<Texture2D>("Diagnosis_paper");
            note2 = Content.Load<Texture2D>("NotePaperIsus");
            keyNormal = Content.Load<Texture2D>("Key_normal");
            keyStory = Content.Load<Texture2D>("Key_story");
            ghostStand = Content.Load<Texture2D>("ghostDoor_standing");
            ghostWalk = Content.Load<Texture2D>("ghostDoor_walk");

            bgm = Content.Load<SoundEffect>("BGM");
            instance = bgm.CreateInstance();
            instance.IsLooped = true;
            instance.Play();

            chase = Content.Load<SoundEffect>("chase");
            c_instance = chase.CreateInstance();
            c_instance.IsLooped = true;
            c_listener = new AudioListener(); c_emitter = new AudioEmitter();
            c_instance.Apply3D(c_listener, c_emitter);

            walk = Content.Load<SoundEffect>("Walk1");
            w_instance = walk.CreateInstance();
            w_instance.IsLooped = true;
            w_listener = new AudioListener();   w_emitter = new AudioEmitter();
            w_instance.Apply3D(w_listener, w_emitter);

            run = Content.Load<SoundEffect>("Run1");
            r_instance = run.CreateInstance();
            r_instance.IsLooped = true;
            r_listener = new AudioListener(); r_emitter = new AudioEmitter();
            r_instance.Apply3D(r_listener, r_emitter);

            door = Content.Load<SoundEffect>("door");
            d_instance = door.CreateInstance();
            d_instance.IsLooped = false;
            d_listener = new AudioListener(); d_emitter = new AudioEmitter();
            d_instance.Apply3D(d_listener, d_emitter);

            ghost1 = Content.Load<SoundEffect>("Ghost1");
            g1_instance = ghost1.CreateInstance();
            g1_instance.IsLooped = false;
            g1_listener = new AudioListener(); g1_emitter = new AudioEmitter();
            g1_instance.Apply3D(g1_listener, g1_emitter);

            ghost2 = Content.Load<SoundEffect>("Ghost2");
            g2_instance = ghost2.CreateInstance();
            g2_instance.IsLooped = false;
            g2_listener = new AudioListener(); g2_emitter = new AudioEmitter();
            g2_instance.Apply3D(g2_listener, g2_emitter);

            search = Content.Load<SoundEffect>("searching");
            s_instance = search.CreateInstance();
            s_instance.IsLooped = false;
            s_listener = new AudioListener(); s_emitter = new AudioEmitter();
            s_instance.Apply3D(s_listener, s_emitter);

            paperFlip = Content.Load<SoundEffect>("paper-flutter");
            p_instance = paperFlip.CreateInstance();
            p_instance.IsLooped = false;
            p_listener = new AudioListener(); p_emitter = new AudioEmitter();
            p_instance.Apply3D(p_listener, p_emitter);

            genaretor = Content.Load<SoundEffect>("generator");
            gen_instance = genaretor.CreateInstance();
            gen_instance.IsLooped = false;
            gen_listener = new AudioListener(); gen_emitter = new AudioEmitter();
            gen_instance.Apply3D(gen_listener, gen_emitter);

            startframe = 0;
            starttotalframe = 10;
            startframepersec = 0.5f;
            starttimeperframe = (float)1 / startframepersec;
            starttotalelapsed = 0;

            endframe = 0;
            endtotalframe = 6;
            endframepersec = 0.8f;
            endtimeperframe = (float)1 / endframepersec;
            endtotalelapsed = 0;

            bgframe = 0;
            bgtotalframe = 4;
            bgframepersec = 4;
            bgtimeperframe = (float)1 / bgframepersec;
            bgtotalelapsed = 0;

            normalframe = 0;
            normaltotalframe = 4;
            normalframepersec = 2;
            normaltimeperframe = (float)1 / normalframepersec;
            normaltotalelapsed = 0;

            cryframe = 0;
            crytotalframe = 4;
            cryframepersec = 2;
            crytimeperframe = (float)1 / cryframepersec;
            crytotalelapsed = 0;

            fearframe = 0;
            feartotalframe = 4;
            fearframepersec = 2;
            feartimeperframe = (float)1 / fearframepersec;
            feartotalelapsed = 0;

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

            gframe = 0;
            gtotalframe = 4;
            gframepersec = 6;
            gtimeperframe = (float)1 / eframepersec;
            gtotalelapsed = 0;

            pos = new Vector2(150, 270);
            ballPos = new Vector2(650, 250);
            ballPos2_1 = new Vector2(20, 255);
            ballPos2_3 = new Vector2(1730, 200);
            ballPos3_2 = new Vector2(250, 200);
            ballPos2_4 = new Vector2(930, 200);
            ballPos4_2 = new Vector2(460, 200);
            ballPos4_5 = new Vector2(200, 200);
            ballPos5_4 = new Vector2(160, 200);
            ballPos5_6 = new Vector2(1227, 200);
            ballPos6_5 = new Vector2(450, 200);
            ballPos2_7 = new Vector2(250, 200);
            ballPos7_2 = new Vector2(310, 200);
            ballPos8 = new Vector2(25, 250);
            ballPos8_End = new Vector2(20, 250);
            puzzlePos1 = new Vector2(450, 250);
            puzzlePos2 = new Vector2(270, 220);
            puzzlePos3 = new Vector2(360, 240);
            ballLockerR2_1 = new Vector2(775, 200);
            ballLockerR2_2 = new Vector2(1890, 200);
            ballLockerR3 = new Vector2(125, 200);
            ballLockerR5 = new Vector2(1105, 200);
            uiPos = new Vector2(0, 400);
            uiPos5 = new Vector2(0, 0);
            ePos = new Vector2(1850, 170);
            trapPos = new Vector2(900, 340);
            capetPos = new Vector2(470, 200);
            staminaPos = new Vector2(250, 400);
            sanityPos = new Vector2(280, 400);
            key2Pos = sanityPos + new Vector2(0, 40);
            key1Pos = staminaPos + new Vector2(0, 40);

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
            cooldowntime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (mCurrentScreen)
            {
                case Screenstate.Title:
                    {
                        UpdateTitle();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
                case Screenstate.startcutscene:
                    {
                        UpdateStartCutscene();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
                case Screenstate.Room1:
                    {
                        UpdateRoom1();
                        if(isRead == false)
                        {
                            dylight.AmbientColor = new Color(new Vector3(0.3f));
                        }
                        else if(isRead == true)
                        {
                            dylight.AmbientColor = new Color(new Vector3(0.7f));
                        }

                        break;
                    }
                case Screenstate.Room2:
                    {
                        UpdateRoom2();
                        dylight.AmbientColor = new Color(new Vector3(0.3f));
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
                        if (isRead == false)
                        {
                            dylight.AmbientColor = new Color(new Vector3(0.3f));
                        }
                        else if (isRead == true)
                        {
                            dylight.AmbientColor = new Color(new Vector3(0.7f));
                        }
                        break;
                    }
                case Screenstate.Room6:
                    {
                        UpdateRoom6();
                        dylight.AmbientColor = new Color(new Vector3(0.3f));
                        break;
                    }
                case Screenstate.Room7:
                    {
                        UpdateRoom7();
                        if (isRead == false)
                        {
                            dylight.AmbientColor = new Color(new Vector3(0.3f));
                        }
                        else if (isRead == true)
                        {
                            dylight.AmbientColor = new Color(new Vector3(0.7f));
                        }

                        break;
                    }
                case Screenstate.LRoom1:
                    {
                        UpdateL_Room1();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom2:
                    {
                        UpdateL_Room2();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom3:
                    {
                        UpdateL_Room3();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom4:
                    {
                        UpdateL_Room4();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom5:
                    {
                        UpdateL_Room5();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom6:
                    {
                        UpdateL_Room6();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom7:
                    {
                        UpdateL_Room7();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.LRoom8:
                    {
                        UpdateL_Room8();
                        dylight.AmbientColor = new Color(new Vector3(0.4f));
                        break;
                    }
                case Screenstate.endcutscene:
                    {
                        UpdateEndCutscene();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
                case Screenstate.over:
                    {
                        UpdateOver();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
                case Screenstate.PipePuzz:
                    {
                        timeSinceLastInput += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        UpdatePipePuzz();
                        dylight.AmbientColor = new Color(new Vector3(0.7f));
                        break;
                    }
                case Screenstate.PassPuzz:
                    {
                        UpdatePassPuzz();
                        break;
                    }

            }
            if (hBarRec.Width <= 0)
            {
                mCurrentScreen = Screenstate.over;
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
                case Screenstate.startcutscene:
                    {
                        DrawStartcutscene();
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
                case Screenstate.Room6:
                    {
                        DrawRoom6();
                        break;
                    }
                case Screenstate.Room7:
                    {
                        DrawRoom7();
                        break;
                    }
                case Screenstate.LRoom1:
                    {
                        DrawL_Room1();
                        break;
                    }
                case Screenstate.LRoom2:
                    {
                        DrawL_Room2();
                        break;
                    }
                case Screenstate.LRoom3:
                    {
                        DrawL_Room3();
                        break;
                    }
                case Screenstate.LRoom4:
                    {
                        DrawL_Room4();
                        break;
                    }
                case Screenstate.LRoom5:
                    {
                        DrawL_Room5();
                        break;
                    }
                case Screenstate.LRoom6:
                    {
                        DrawL_Room6();
                        break;
                    }
                case Screenstate.LRoom7:
                    {
                        DrawL_Room7();
                        break;
                    }
                case Screenstate.LRoom8:
                    {
                        DrawL_Room8();
                        break;
                    }
                case Screenstate.endcutscene:
                    {
                        DrawEndcutscene();
                        break;
                    }
                case Screenstate.over:
                    {
                        DrawOver();
                        break;
                    }
                case Screenstate.PipePuzz:
                    {
                        DrawPipePuzz();
                        break;
                    }
                case Screenstate.PassPuzz:
                    {
                        DrawPassPuzz();
                        break;
                    }
            }
            _spriteBatch.End();
            dylight.Draw(gameTime);
            base.Draw(gameTime);
        }

        void UpdateRoom1()
        {
            /*if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
            {
                mCurrentScreen = Screenstate.Title;
            }*/
            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room2;
                spotLightR2_1.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_2.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_3.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_4.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                gPos = new Vector2(399,252);
                pos.X = 50;
            }
            if (isRead == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
                {
                    p_instance.Play();
                    dylight.Lights.Add(light);
                    dylight.Lights.Add(spotLightR2_1);
                    dylight.Lights.Add(spotLightR2_2);
                    dylight.Lights.Add(spotLightR2_3);
                    dylight.Lights.Add(spotLightR2_4);
                    isRead = false;
                }
            }
            if (isRead2 == true)
            {
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
                {
                    p_instance.Play();
                    dylight.Lights.Add(spotLightR2_1);
                    dylight.Lights.Add(spotLightR2_2);
                    dylight.Lights.Add(spotLightR2_3);
                    dylight.Lights.Add(spotLightR2_4);
                    isRead2 = false;
                }
            }

            if(hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }

            textstaminaPos = staminaPos + new Vector2(0,-20);
            textsanityPos = sanityPos + new Vector2(0, -20);
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            {
                if (isRead == false && isRead2 == false)
                {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();
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
                    w_instance.Play();
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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {   
                    if ( sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if ( sBarRec.Width <= 0 && cooldowntime >= 5000 )
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if(cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                    if (hBarRec.Width >= 163)
                    {
                        hBarRec.Width = 163;
                    }
                }
                }
                
                if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                {
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos.X, (int)ballPos.Y, 24, 24);
            Rectangle paperRec = new Rectangle((int)paperPos.X, (int)paperPos.Y, 53, 41);
            Rectangle capetRec = new Rectangle((int)capetPos.X, (int)capetPos.Y, 53, 41);
            if (personRectangle.Intersects(ballRectangle) == true)
            {

                toRoom_2 = "F To Enter";
                {
                    if (ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        //toRoom_2 = "Enter room ?";
                        personHit2 = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit2 = false;
                toRoom_2 = "";
            }
            if (personRectangle.Intersects(capetRec) == true)
            {
                capetText = "F To Search";
                {
                    if (ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        s_instance.Play();
                        isRead2 = true;
                        if (isSearch == false)
                        {
                            gotItemText = "Got SanityPill & StanimaPill";
                            AddSanityPill();
                            AddStanimaPill();
                            isSearch = true;
                        }
                        else if (isSearch == true)
                        {
                            capetText = "Already Search";
                        }
                    }
                }
            }
            else if (personRectangle.Intersects(capetRec) == false)
            {
                isRead2 = false;
                capetText = "";
                gotItemText = "";
                s_instance.Stop();
            }
            if (personRectangle.Intersects(paperRec) == true)
            {
                tu1 = "F to Read";
                {
                    if (ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        p_instance.Play();
                        isRead = true;
                        dylight.Lights.Remove(light);
                        dylight.Lights.Remove(spotLightR2_1);
                        dylight.Lights.Remove(spotLightR2_2);
                        dylight.Lights.Remove(spotLightR2_3);
                        dylight.Lights.Remove(spotLightR2_4);
                    }
                }
            }
            else if (personRectangle.Intersects(paperRec) == false)
            {
                isRead = false;
                tu1 = "";
                p_instance.Stop();

            }
            old_ks = ks;
            gotItemPos = pos + new Vector2(5, -45);
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);
            
        }
        void UpdateTitle()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                mCurrentScreen = Screenstate.startcutscene;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D1) == true)
            {
                mCurrentScreen = Screenstate.Room1;
                //mCurrentScreen = Screenstate.endcutscene;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
            {
                //mCurrentScreen = Screenstate.LRoom1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2) == true)
            {
                //mCurrentScreen = Screenstate.Room2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R) == true)
            {
                //mCurrentScreen = Screenstate.LRoom2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D5) == true)
            {
                mCurrentScreen = Screenstate.Room5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T) == true)
            {
                //mCurrentScreen = Screenstate.LRoom5;
            }

            UpdateFrame(elapsed);
            UpdateMenuFrame(elapsed);
        }
        void UpdateStartCutscene()
        {
            if (startframe == 9)
            {
                wait(2000);
                mCurrentScreen = Screenstate.Room1;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                mCurrentScreen = Screenstate.Room1;
            }

            UpdateStartCutFrame(elapsed);
        }
        void UpdateEndCutscene()
        {
            dylight.Lights.Remove(spotLightR2_1);
            dylight.Lights.Remove(spotLightR2_2);
            dylight.Lights.Remove(spotLightR2_3);
            dylight.Lights.Remove(spotLightR2_4);
            dylight.Lights.Remove(light);
            dylight.Lights.Remove(eLight);
            w_instance.Stop();
            r_instance.Stop();

            if (endframe == 5)
            {
                wait(3000);
                Exit();
            }

            UpdateEndCutFrame(elapsed);
        }
        void UpdateOver()
        {
            totalframe = 4;
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                Exit();
            }
            UpdateFrame(elapsed);
        }
        void UpdateRoom2()
        {

            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room1;
                spotLightR3.Position = Vector2.Zero;
                spotLightR2_1.Position = Vector2.Zero;
                spotLightR2_2.Position = Vector2.Zero;
                spotLightR2_3.Position = Vector2.Zero;
                spotLightR2_4.Position = Vector2.Zero;
                capetPos = new Vector2(470, 200);
                pos.X = 580;
            }

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room3;
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                dylight.Lights.Add(spotLightR3);
                spotLightR3.Position = new Vector2(480, 30);
                capetPos = new Vector2(512, 200);
                pos.X = 200;
            }

            if (personHit3 == true && isPipe1Clear == true)
            {
                mCurrentScreen = Screenstate.Room4;
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                dylight.Lights.Add(spotLightR4);
                spotLightR4.Position = new Vector2(360, 30);
                capetPos = new Vector2(318, 190);
                pos.X = 500;
                isHuant1 = false;
            }

            if (personHit4 == true && cKey1 == true)
            {
                mCurrentScreen = Screenstate.Room7;
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                dylight.Lights.Add(spotLightR7);
                spotLightR7.Position = new Vector2(350, 30);
                pos.X = 350;
            }

            if(personHit5 == true)
            {
                isHide = true;

                if(Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (personHit6 == true)
            {
                isHide = true;

                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (isRead == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
                {
                    p_instance.Play();
                    dylight.Lights.Add(light);
                    dylight.Lights.Add(spotLightR2_1);
                    dylight.Lights.Add(spotLightR2_2);
                    dylight.Lights.Add(spotLightR2_3);
                    dylight.Lights.Add(spotLightR2_4);
                    isRead = false;
                }
            }
            if (pos.X >= 633 && pos.X <= 870 && isPipe1Clear == true && cKey2 == false)
            {
                g1_instance.Play();
                isHuant1 = true;
            }
            if(isHuant1 == true && mCurrentScreen == Screenstate.Room2)
            {
                if(gPos.X <= 912)
                {
                    gdirection = 2;
                    gPos.X += 5;
                }
                if(gPos.X >= 912)
                {
                    Debug.Write(isHuant1);
                    gdirection = 0;
                    gPos.X = 912;
                    cKey2 = true;
                    isHuant1 = false;
                }
                UpdateGhost(elapsed);
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            {
                if(isHide == false)
                {
                    if (isRead == false)
                    {
                       if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                    {
                        hBarRec.Width -= 5;
                    }

                    if (ks.IsKeyDown(Keys.W))
                    {
                        w_instance.Play();

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
                        w_instance.Play();

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
                        w_instance.Play();

                        if (pos.X <= bLine.X && camPos.X > 0)
                        {
                            r_instance.Stop();
                            fLine -= new Vector2(3, 0);
                            bLine -= new Vector2(3, 0);
                            camPos -= new Vector2(3, 0);
                            uiPos -= new Vector2(3, 0);
                            sanityPos -= new Vector2(3, 0);
                            staminaPos -= new Vector2(3, 0);
                            }

                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine -= new Vector2(6, 0);
                            bLine -= new Vector2(6, 0);
                            camPos -= new Vector2(6, 0);
                            uiPos -= new Vector2(6, 0);
                            sanityPos -= new Vector2(6, 0);
                            staminaPos -= new Vector2(6, 0);
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
                        if (sBarRec.Width >= 1)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                        {
                            sBarRec.Width = 0;
                            cooldowntime = 0;
                        }
                        if (cooldowntime == 0)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width >= 163)
                        {
                            sBarRec.Width = 163;
                        }
                    }
                    if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width * 3 - 25)
                    {
                        w_instance.Play();

                        if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width * 2)
                        {
                            r_instance.Stop();
                            fLine += new Vector2(3, 0);
                            bLine += new Vector2(3, 0);
                            camPos += new Vector2(3, 0);
                            uiPos += new Vector2(3, 0);
                            sanityPos += new Vector2(3, 0);
                            staminaPos += new Vector2(3, 0);
                            }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine += new Vector2(6, 0);
                            bLine += new Vector2(6, 0);
                            camPos += new Vector2(6, 0);
                            uiPos += new Vector2(6, 0);
                            sanityPos += new Vector2(6, 0);
                            staminaPos += new Vector2(6, 0);
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
                        if (sBarRec.Width >= 1)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                        {
                            sBarRec.Width = 0;
                            cooldowntime = 0;
                        }
                        if (cooldowntime == 0)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width >= 163)
                        {
                            sBarRec.Width = 163;
                        }
                    }
                    if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                    {
                        w_instance.Stop();
                        r_instance.Stop();
                        speed.X = 0;
                        UpdateFrame(elapsed);
                    }
                    if (pos.X >= 1700)
                    {
                        ePos.X = ePos.X - eSpeed.X - 16;
                    }
                        if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                        {
                            UseStanimaPill();
                        }
                        if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                        {
                            UseSanityPill();
                        }
                    } 
            }
                    
                else
                {
                    speed.X = 0;

                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }

                
                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos2_1.X, (int)ballPos2_1.Y, 24, 24);
                Rectangle ball2_3Rectangle = new Rectangle((int)ballPos2_3.X, (int)ballPos2_3.Y, 24, 24);
                Rectangle ball2_4Rectangle = new Rectangle((int)ballPos2_4.X, (int)ballPos2_4.Y, 24, 24);
                Rectangle ball2_7Rectangle = new Rectangle((int)ballPos2_7.X, (int)ballPos2_7.Y, 24, 24);
                Rectangle LockerRec1 = new Rectangle((int)ballLockerR2_1.X, (int)ballLockerR2_1.Y, 24, 24);
                Rectangle LockerRec2 = new Rectangle((int)ballLockerR2_2.X, (int)ballLockerR2_2.Y, 24, 24);
                Rectangle enemyRectangle = new Rectangle((int)ePos.X, (int)ePos.Y, 60, 100);
                Rectangle trapRectangle = new Rectangle((int)trapPos.X, (int)trapPos.Y, 10, 10);
                if(isHuant1 == true)
                {
                    Rectangle ghostRectangle = new Rectangle((int)gPos.X, (int)gPos.Y, 50, 80);
                    if (isHuant1 == true)
                    {
                        if (isHide == false)
                        {
                           if (personRectangle.Intersects(ghostRectangle) == true)

                            {
                            hBarRec.Width -= 20;
                            }
                             else if (personRectangle.Intersects(ghostRectangle) == false)
                                {

                                }
                        }
                        
                    }
                }
                Rectangle paperRec = new Rectangle((int)paperPos.X, (int)paperPos.Y, 53, 41);

                if (personRectangle.Intersects(trapRectangle) == true)
                {
                    sBarRec.Width -= 3;
                }
                else if (personRectangle.Intersects(trapRectangle) == false)
                {

                }
                if (isAlive == true)
                {
                    if (personRectangle.Intersects(enemyRectangle) == true)

                    {
                        g2_instance.Play();
                        hBarRec.Width -= 90;
                        isAlive = false;
                    }
                    else if (personRectangle.Intersects(enemyRectangle) == false)
                    {
                        UpdateEnemy(elapsed);
                    }
                }

                if (personRectangle.Intersects(LockerRec1) == true)
                {
                    locker2_1 = "F to Hide";

                    if(ks.IsKeyDown(Keys.F))
                    {
                        personHit5 = true;
                    }
                }
                else if(personRectangle.Intersects(LockerRec1) == false)
                {
                    personHit5 = false;
                    locker2_1 = "";
                }

                if (personRectangle.Intersects(LockerRec2) == true)
                {
                    locker2_2 = "F to Hide";

                    if (ks.IsKeyDown(Keys.F))
                    {
                        personHit6 = true;
                    }
                }
                else if(personRectangle.Intersects(LockerRec2) == false)
                {
                    personHit6 = false;
                    locker2_2 = "";
                }

                if (personRectangle.Intersects(ballRectangle) == true)
                {

                    backRoom2_1 = "F To Enter";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            //backRoom2_1 = "Enter room ?";
                            personHit2 = true;
                            d_instance.Play();
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit2 = false;
                    backRoom2_1 = "";
                }
                if (personRectangle.Intersects(ball2_3Rectangle) == true)
                {
                    toRoom_3 = "F To Enter";
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Tnteract object
                    {
                        //toRoom_3 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
                else if (personRectangle.Intersects(ball2_3Rectangle) == false)
                {
                    personHit = false;
                    toRoom_3 = "";
                }
                if (personRectangle.Intersects(ball2_4Rectangle) == true)
                {
                    toRoom_4 = "Lock";;

                    if (isPipe1Clear == true)
                    {
                        toRoom_4 = "F To Enter";
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Tnteract object
                        {
                            //toRoom_4 = "Enter room ?";
                            personHit3 = true;
                            d_instance.Play();
                            
                        }
                    }
                }
                else if (personRectangle.Intersects(ball2_4Rectangle) == false)
                {
                    personHit3 = false;
                    toRoom_4 = "";
                }
                if (personRectangle.Intersects(ball2_7Rectangle) == true)
                {
                    toRoom_7 = "Lock";
                    if (cKey1 == true )
                    {
                        toRoom_7 = "F to Enter";
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Tnteract object
                            {
                                //toRoom_7 = "Enter room ?";
                                personHit4 = true;
                                d_instance.Play();
                            }
                    }
                    
                }
                else if (personRectangle.Intersects(ball2_7Rectangle) == false)
                {
                    personHit4 = false;
                    toRoom_7 = "";
                }
                if (personRectangle.Intersects(paperRec) == true)
                {
                    tu1 = "F to Read";
                    {
                        if (ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            p_instance.Play();
                            isRead = true;
                            dylight.Lights.Remove(light);
                            dylight.Lights.Remove(spotLightR2_1);
                            dylight.Lights.Remove(spotLightR2_2);
                            dylight.Lights.Remove(spotLightR2_3);
                            dylight.Lights.Remove(spotLightR2_4);
                        }
                    }
                }
                else if (personRectangle.Intersects(paperRec) == false)
                {
                    isRead = false;
                    tu1 = "";
                    p_instance.Stop();
                }

                old_ks = ks;
            }
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            gotItemPos = pos + new Vector2(5, -45);
            if (isAlive == false)
            {
                eLight.Position = new Vector2(4440, 4440);
            }
            light.Position = pos - camPos + new Vector2(40, 40);
           // ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            textstaminaPos = staminaPos;
            textsanityPos = sanityPos;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdateRoom3()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room2;
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                dylight.Lights.Remove(spotLightR3);
                pos.X = 1675;
            }
            if(personHit2 == true)
            {
                isHide = true;

                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if(isHide == false)
                {
                    if (ks.IsKeyDown(Keys.W))
                    {
                        w_instance.Play();

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
                        w_instance.Play();

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
                        w_instance.Play();

                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            r_instance.Play();
                            w_instance.Stop();
                            speed.X = 6;
                            sBarRec.Width -= 3;
                        }
                        else
                        {
                            r_instance.Stop();
                            speed.X = 3;
                        }
                        pos.X = pos.X - speed.X;
                        direction = 1;

                        UpdateFrame(elapsed);
                    }
                    else
                    {
                        if (sBarRec.Width >= 1)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                        {
                            sBarRec.Width = 0;
                            cooldowntime = 0;
                        }
                        if (cooldowntime == 0)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width >= 163)
                        {
                            sBarRec.Width = 163;
                        }
                    }
                    if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                    {
                        w_instance.Play();

                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            sBarRec.Width -= 3;
                        }
                        else
                        {
                            r_instance.Stop();
                            speed.X = 3;
                        }
                        pos.X = pos.X + speed.X;

                        direction = 2;
                        UpdateFrame(elapsed);
                    }
                    else
                    {
                        if (sBarRec.Width >= 1)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                        {
                            sBarRec.Width = 0;
                            cooldowntime = 0;
                        }
                        if (cooldowntime == 0)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width >= 163)
                        {
                            sBarRec.Width = 163;
                        }
                    }
                    if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                    {
                        w_instance.Stop();
                        r_instance.Stop();
                        speed.X = 0;
                        UpdateFrame(elapsed);
                    }
                    if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                    {
                        UseStanimaPill();
                    }
                    if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                    {
                        UseSanityPill();
                    }
                }

                else
                {
                    speed.X = 0;

                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos3_2.X, (int)ballPos3_2.Y, 24, 24);
            Rectangle LockerRec3 = new Rectangle((int)ballLockerR3.X, (int)ballLockerR3.Y, 24, 24);
            Rectangle capetRec = new Rectangle((int)capetPos.X, (int)capetPos.Y, 53, 41);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom3_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom3_2 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom3_2 = "";
            }
            if (personRectangle.Intersects(LockerRec3) == true)
            {
                locker3 = "F To Hide";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        personHit2 = true;
                    }
                }
            }
            else if(personRectangle.Intersects(LockerRec3) == false)
            {
                 personHit2 = false;
                 locker3 = "";
            }
            if (personRectangle.Intersects(capetRec) == true)
            {
                capetText = "F To Search";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        s_instance.Play();
                        if (isSearch2 == false)
                        {
                            gotItemText = "Got SanityPill & GeneratorKey";
                            AddSanityPill();
                            cKey1 = true;
                            isSearch2 = true;
                        }
                        else if (isSearch2 == true)
                        {
                            capetText = "Already Search";
                        }
                    }
                }
            }
            else if (personRectangle.Intersects(capetRec) == false)
            {
                capetText = "";
                gotItemText = "";
                s_instance.Stop();
            }
            old_ks = ks;
            gotItemPos = pos + new Vector2(5, -45);
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(100, 40);

        }
        void UpdateRoom4()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room2;
                dylight.Lights.Remove(spotLightR4);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 1000;
                camPos.X = 780;
                uiPos.X = 780;
                staminaPos.X = 1025;
                sanityPos.X = 1055;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }

            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.Room5;
                dylight.Lights.Remove(spotLightR4);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 100;
                camPos.X = 0;
                uiPos.X = 0;
                staminaPos.X = 245;
                sanityPos.X = 275;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                {
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos4_2.X, (int)ballPos4_2.Y, 24, 24);
            Rectangle ball2Rectangle = new Rectangle((int)ballPos4_5.X, (int)ballPos4_5.Y, 24, 24);
            Rectangle capetRec = new Rectangle((int)capetPos.X, (int)capetPos.Y, 53, 41);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom4_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom4_2 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom4_2 = "";
            }
            if (personRectangle.Intersects(ball2Rectangle) == true)
            {
                toRoom_5 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //toRoom_5 = "Enter room ?";
                        personHit2 = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ball2Rectangle) == false)
            {
                personHit2 = false;
                toRoom_5 = "";
            }
            if (personRectangle.Intersects(capetRec) == true)
            {
                capetText = "F To Search";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        s_instance.Play();
                        if (isSearch3 == false)
                        {
                            gotItemText = "Got StaminaPill x2 ";
                            AddStanimaPill();
                            AddStanimaPill();
                            cKey1 = true;
                            isSearch3 = true;
                        }
                        else if (isSearch3 == true)
                        {
                            capetText = "Already Search";
                        }
                    }
                }
            }
            else if (personRectangle.Intersects(capetRec) == false)
            {
                capetText = "";
                gotItemText = "";
                s_instance.Stop();
            }
            old_ks = ks;
            gotItemPos = pos + new Vector2(5, -45);
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(60, 40);

        }
        void UpdateRoom5()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room4;
                dylight.Lights.Add(spotLightR4);
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                capetPos = new Vector2(318, 190);
                pos.X = 240;
            }

            if (personHit2 == true && isClear == true)
            {
                mCurrentScreen = Screenstate.Room6;
                dylight.Lights.Add(spotLightR6);
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                spotLightR6.Position = new Vector2(300, 30);
                pos.X = 400;
            }
            if (personHit3 == true && isClear == false)
            { 
                mCurrentScreen = Screenstate.PassPuzz;
            }
            bool hit = Enemy.isHit;
            if(hit == true && isHide == false)
            {
                hBarRec.Width -= 5;
            }
            if (personHit4 == true)
            {
                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if(isRead == true)
            {
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
                {
                    p_instance.Play();
                    isRead = false;
                    dylight.Lights.Add(spotLightR2_1);
                    dylight.Lights.Add(spotLightR2_2);
                    dylight.Lights.Add(spotLightR2_3);
                    dylight.Lights.Add(spotLightR2_4);
                }
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();

            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (isHide == false)
                {
                    if(ks.IsKeyDown(Keys.Space))
                    {
                        hBarRec.Width -= 5;
                    }
                    if (ks.IsKeyDown(Keys.W))
                    {
                        w_instance.Play();

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
                        w_instance.Play();

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
                        w_instance.Play();

                        if (pos.X <= bLine.X && camPos.X > 0)
                        {
                            fLine -= new Vector2(3, 0);
                            bLine -= new Vector2(3, 0);
                            camPos -= new Vector2(3, 0);
                            uiPos -= new Vector2(3, 0);
                            sanityPos -= new Vector2(3, 0);
                            staminaPos -= new Vector2(3, 0);
                        }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine -= new Vector2(6, 0);
                            bLine -= new Vector2(6, 0);
                            camPos -= new Vector2(6, 0);
                            uiPos -= new Vector2(6, 0);
                            sanityPos -= new Vector2(6, 0);
                            staminaPos -= new Vector2(6, 0);
                            sBarRec.Width -= 3;
                        }
                        else
                        {
                            speed.X = 3;
                            r_instance.Stop();
                        }
                        pos.X = pos.X - speed.X;
                        direction = 1;

                        UpdateFrame(elapsed);
                    }
                    else
                    {
                        if (sBarRec.Width >= 1)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                        {
                            sBarRec.Width = 0;
                            cooldowntime = 0;
                        }
                        if (cooldowntime == 0)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width >= 163)
                        {
                            sBarRec.Width = 163;
                        }
                    }
                    if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width * 2 - 25)
                    {
                        w_instance.Play();
                        r_instance.Stop();

                        if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width)
                        {
                            fLine += new Vector2(3, 0);
                            bLine += new Vector2(3, 0);
                            camPos += new Vector2(3, 0);
                            uiPos += new Vector2(3, 0);
                            sanityPos += new Vector2(3, 0);
                            staminaPos += new Vector2(3, 0);
                        }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine += new Vector2(6, 0);
                            bLine += new Vector2(6, 0);
                            camPos += new Vector2(6, 0);
                            uiPos += new Vector2(6, 0);
                            sanityPos += new Vector2(6, 0);
                            staminaPos += new Vector2(6, 0);
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
                        if (sBarRec.Width >= 1)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                        {
                            sBarRec.Width = 0;
                            cooldowntime = 0;
                        }
                        if (cooldowntime == 0)
                        {
                            sBarRec.Width += 1;
                        }
                        if (sBarRec.Width >= 163)
                        {
                            sBarRec.Width = 163;
                        }
                    }
                    if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                    {
                        w_instance.Stop();
                        r_instance.Stop();
                        speed.X = 0;
                        UpdateFrame(elapsed);
                    }
                    if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                    {
                        UseStanimaPill();
                    }
                    if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                    {
                        UseSanityPill();
                    }
                }
                else
                {
                    speed.X = 0;
                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos5_4.X, (int)ballPos5_4.Y, 24, 24);
                Rectangle ball2Rectangle = new Rectangle((int)ballPos5_6.X, (int)ballPos5_6.Y, 24, 24);
                Rectangle LockerRec5 = new Rectangle((int)ballLockerR5.X, (int)ballLockerR5.Y, 24, 24);
                Rectangle puzzleRectangle = new Rectangle((int)puzzlePos2.X, (int)puzzlePos2.Y, 24, 24);
                Rectangle enemyRectangle = new Rectangle((int)ePos.X, (int)ePos.Y, 60, 100);
                Rectangle paperRec = new Rectangle((int)paperPos.X, (int)paperPos.Y, 53, 41);

                if (personRectangle.Intersects(enemyRectangle) == true)
                {
                    hBarRec.Width -= 5;
                }
                else if (personRectangle.Intersects(enemyRectangle) == false)
                {
                    UpdateEnemy(elapsed);
                }
                if (personRectangle.Intersects(LockerRec5) == true)
                {
                    locker5 = "F To Hide";
                    {
                        if (ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            personHit4 = true;
                            isHide = true;
                        }
                    }
                }
                else if (personRectangle.Intersects(LockerRec5) == false)
                {
                    personHit4 = false;
                    locker5 = "";
                }
                if (personRectangle.Intersects(ballRectangle) == true)
                {

                    backRoom5_4 = "F To Enter";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            //backRoom5_4 = "Enter room ?";
                            personHit = true;
                            d_instance.Play();
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit = false;
                    backRoom5_4 = "";
                }
                if (personRectangle.Intersects(ball2Rectangle) == true)
                {
                    if(isClear == false)
                    {
                        toRoom_6 = "Lock";
                    }
                    if (isClear == true)
                    {
                        toRoom_6 = "F to Enter";
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            //toRoom_6 = "Enter room ?";
                            personHit2 = true;
                            d_instance.Play();
                        }
                    }
                }
                else if (personRectangle.Intersects(ball2Rectangle) == false)
                {
                    personHit2 = false;
                    toRoom_6 = "";
                }
                if (personRectangle.Intersects(puzzleRectangle) == true)
                {
                    if (isClear == true)
                    {
                        puzzle2 = "Got MainGate Key";
                    }
                    if (isClear == false)
                    {
                        puzzle2 = "F To Solve";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            personHit3 = true;
                        }
                    }
                    }
                    
                }
                else if (personRectangle.Intersects(puzzleRectangle) == false)
                {
                    personHit3 = false;
                    puzzle2 = "";
                }
                if (personRectangle.Intersects(paperRec) == true)
                {
                    tu3 = "F to Read";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            p_instance.Play();
                            isRead = true;
                        }
                    }
                }
                else if (personRectangle.Intersects(paperRec) == false)
                {
                    isRead = false;
                    tu3 = "";
                    r_instance.Stop();
                }

                old_ks = ks;
            }
            enemy.Update(pos);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);
            //ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            textstaminaPos = staminaPos;
            textsanityPos = sanityPos;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdateRoom6()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room5;
                gen_instance.Stop();
                dylight.Lights.Remove(spotLightR6);
                pos.X = 1170;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if(personHit2 == true && isPipe2Clear == false)
            {
                mCurrentScreen = Screenstate.PipePuzz;
                inRoom6 = true;
            }
            if (isPipe2Clear == true)
            {
                gen_instance.Play();
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                {
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos6_5.X, (int)ballPos6_5.Y, 24, 24);
            Rectangle puzzleRectangle = new Rectangle((int)puzzlePos3.X, (int)puzzlePos3.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom6_5 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom6_5 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom6_5 = "";
            }
            if (personRectangle.Intersects(puzzleRectangle) == true)
            {
                puzzle3 = "F To Solve";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        puzzle3 = "Solved";
                        personHit2 = true;
                    }
                }
            }
            else if (personRectangle.Intersects(puzzleRectangle) == false)
            {
                personHit2 = false;
                puzzle3 = "Check";
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateRoom7()
        {

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.Room2;
                gen_instance.Stop();
                dylight.Lights.Remove(spotLightR7);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 200;
                camPos.X = 0;
                uiPos.X = 0;
                staminaPos.X = 245;
                sanityPos.X = 275;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if (personHit2 == true && isPipe1Clear == false)
            {
                mCurrentScreen = Screenstate.PipePuzz;
                dylight.Lights.Remove(spotLightR7);
            }
            if (isPipe1Clear == true)
            {
                gen_instance.Play();
            }
            if (isRead == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
                {
                    p_instance.Play();
                    dylight.Lights.Add(light);
                    dylight.Lights.Add(spotLightR7);
                    isRead = false;
                }
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width - 110)
                {
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                {
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos7_2.X, (int)ballPos7_2.Y, 24, 24);
            Rectangle ballpuzzle = new Rectangle((int)puzzlePos1.X, (int)puzzlePos1.Y, 24, 24);
            Rectangle paperRec = new Rectangle((int)paperPos.X, (int)paperPos.Y, 53, 41);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom7_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom7_2 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom7_2 = "";
            }
            if (personRectangle.Intersects(ballpuzzle) == true)
            {
                puzzle1 = "F To Solve";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        puzzle1 = "Solved";
                        personHit2 = true;
                    }
                }
            }
            else if (personRectangle.Intersects(ballpuzzle) == false)
            {
                personHit2 = false;
                puzzle1 = "Check";
            }
            if (personRectangle.Intersects(paperRec) == true)
            {
                tu2= "F to Read";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        p_instance.Play();
                        isRead = true;
                        dylight.Lights.Remove(light);
                        dylight.Lights.Remove(spotLightR7);
                    }
                }
            }
            else if (personRectangle.Intersects(paperRec) == false)
            {
                isRead = false;
                tu2 = "";
                p_instance.Stop();
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos + new Vector2(60,40);

        }

        void UpdateL_Room1()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back) == true)
            {
                mCurrentScreen = Screenstate.Title;
            }
            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.LRoom2;
                spotLightR2_1.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_2.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_3.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_4.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                pos.X = 50;
            }
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom8;
                spotLightR2_1.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_2.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_3.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_4.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                pos.X = 2025;
                camPos.X = 1450;
                uiPos.X = 1450; 
                staminaPos.X = 1695;
                sanityPos.X = 1725;
                eLight.Position = Vector2.Zero;
                gPos = new Vector2(1881,262);
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos.X, (int)ballPos.Y, 24, 24);
            Rectangle ball2Rectangle = new Rectangle((int)ballPos8.X, (int)ballPos8.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {

                toRoom_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //toRoom_2 = "Enter room ?";
                        personHit2 = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit2 = false;
                toRoom_2 = "";
            }
            if (personRectangle.Intersects(ball2Rectangle) == true)
            {

                toRoom_8 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //toRoom_8 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ball2Rectangle) == false)
            {
                personHit = false;
                toRoom_8 = "";
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateL_Room2()
        {

            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.LRoom1;
                spotLightR2_1.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_2.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_3.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                spotLightR2_4.Position = (new Vector2(0, 0) - camPos) * scroll_factor;
                pos.X = 580;
            }

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom3;
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                dylight.Lights.Add(spotLightR3);
                spotLightR3.Position = new Vector2(480, 30);
                pos.X = 200;
            }

            if (personHit3 == true)
            {
                mCurrentScreen = Screenstate.LRoom4;
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                dylight.Lights.Add(spotLightR4);
                spotLightR4.Position = new Vector2(360, 30);
                pos.X = 500;
            }

            if (personHit4 == true)
            {
                mCurrentScreen = Screenstate.LRoom7;
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                dylight.Lights.Add(spotLightR7);
                spotLightR7.Position = new Vector2(350, 30);
                pos.X = 350;
            }

            if (personHit5 == true)
            {
                isHide = true;

                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (personHit6 == true)
            {
                isHide = true;

                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if(isHide == false)
                {
                    if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                    {
                        hBarRec.Width -= 5;
                    }

                    if (ks.IsKeyDown(Keys.W))
                    {
                        w_instance.Play();

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
                        w_instance.Play();

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
                        w_instance.Play();

                        if (pos.X <= bLine.X && camPos.X > 0)
                        {
                            r_instance.Stop();
                            fLine -= new Vector2(3, 0);
                            bLine -= new Vector2(3, 0);
                            camPos -= new Vector2(3, 0);
                            uiPos -= new Vector2(3, 0);
                            sanityPos -= new Vector2(3, 0);
                            staminaPos -= new Vector2(3, 0);
                        }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine -= new Vector2(6, 0);
                            bLine -= new Vector2(6, 0);
                            camPos -= new Vector2(6, 0);
                            uiPos -= new Vector2(6, 0);
                            sanityPos -= new Vector2(6, 0);
                            staminaPos -= new Vector2(6, 0);
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
                        w_instance.Play();

                        if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width * 2)
                        {
                            r_instance.Stop();
                            fLine += new Vector2(3, 0);
                            bLine += new Vector2(3, 0);
                            camPos += new Vector2(3, 0);
                            uiPos += new Vector2(3, 0);
                            sanityPos += new Vector2(3, 0);
                            staminaPos += new Vector2(3, 0);
                        }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine += new Vector2(6, 0);
                            bLine += new Vector2(6, 0);
                            camPos += new Vector2(6, 0);
                            uiPos += new Vector2(6, 0);
                            sanityPos += new Vector2(6, 0);
                            staminaPos += new Vector2(6, 0);
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
                        w_instance.Stop();
                        r_instance.Stop();
                        speed.X = 0;
                        UpdateFrame(elapsed);
                    }
                    if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                    {
                        UseStanimaPill();
                    }
                    if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                    {
                        UseSanityPill();
                    }
                }
                else
                {
                    speed.X = 0;

                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }

                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos2_1.X, (int)ballPos2_1.Y, 24, 24);
                Rectangle ball2_3Rectangle = new Rectangle((int)ballPos2_3.X, (int)ballPos2_3.Y, 24, 24);
                Rectangle ball2_4Rectangle = new Rectangle((int)ballPos2_4.X, (int)ballPos2_4.Y, 24, 24);
                Rectangle ball2_7Rectangle = new Rectangle((int)ballPos2_7.X, (int)ballPos2_7.Y, 24, 24);
                Rectangle LockerRec1 = new Rectangle((int)ballLockerR2_1.X, (int)ballLockerR2_1.Y, 24, 24);
                Rectangle LockerRec2 = new Rectangle((int)ballLockerR2_2.X, (int)ballLockerR2_2.Y, 24, 24);
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

                if (personRectangle.Intersects(LockerRec1) == true)
                {
                    locker2_1 = "F to Hide";

                    if (ks.IsKeyDown(Keys.F))
                    {
                        personHit5 = true;
                    }
                }
                else if (personRectangle.Intersects(LockerRec1) == false)
                {
                    personHit5 = false;
                    locker2_1 = "";
                }

                if (personRectangle.Intersects(LockerRec2) == true)
                {
                    locker2_2 = "F to Hide";

                    if (ks.IsKeyDown(Keys.F))
                    {
                        personHit6 = true;
                    }
                }
                else if (personRectangle.Intersects(LockerRec2) == false)
                {
                    personHit6 = false;
                    locker2_2 = "";
                }

                if (personRectangle.Intersects(ballRectangle) == true)
                {

                    backRoom2_1 = "F To Enter";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            //backRoom2_1 = "Enter room ?";
                            personHit2 = true;
                            d_instance.Play();
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit2 = false;
                    backRoom2_1 = "";
                }
                if (personRectangle.Intersects(ball2_3Rectangle) == true)
                {
                    toRoom_3 = "F To Enter";
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Tnteract object
                    {
                        //toRoom_3 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
                else if (personRectangle.Intersects(ball2_3Rectangle) == false)
                {
                    personHit = false;
                    toRoom_3 = "";
                }
                if (personRectangle.Intersects(ball2_4Rectangle) == true)
                {
                    toRoom_4 = "F To Enter";
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Tnteract object
                    {
                        //toRoom_4 = "Enter room ?";
                        personHit3 = true;
                        d_instance.Play();
                    }
                }
                else if (personRectangle.Intersects(ball2_4Rectangle) == false)
                {
                    personHit3 = false;
                    toRoom_4 = "";
                      
                }
                if (personRectangle.Intersects(ball2_7Rectangle) == true)
                {
                    toRoom_7 = "F To Enter";
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Tnteract object
                    {
                        //toRoom_7 = "Enter room ?";
                        personHit4 = true;
                        d_instance.Play();
                    }
                }
                else if (personRectangle.Intersects(ball2_7Rectangle) == false)
                {
                    personHit4 = false;
                    toRoom_7 = "";
                }

                old_ks = ks;
            }
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);
            //ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            textstaminaPos = staminaPos;
            textsanityPos = sanityPos;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdateL_Room3()
        {

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom2;
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                dylight.Lights.Remove(spotLightR3);
                pos.X = 1675;
            }
            if (personHit2 == true)
            {
                isHide = true;

                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if(isHide == false)
                {
                    if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                    {
                        hBarRec.Width -= 5;
                    }

                    if (ks.IsKeyDown(Keys.W))
                    {
                        w_instance.Play();

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
                        w_instance.Play();

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
                        w_instance.Play();

                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            sBarRec.Width -= 3;
                        }
                        else
                        {
                            r_instance.Stop();
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
                        w_instance.Play();

                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            sBarRec.Width -= 3;
                        }
                        else
                        {
                            r_instance.Stop();
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
                        w_instance.Stop();
                        r_instance.Stop();
                        speed.X = 0;
                        UpdateFrame(elapsed);
                    }
                    if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                    {
                        UseStanimaPill();
                    }
                    if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                    {
                        UseSanityPill();
                    }
                }
                else
                {
                    speed.X = 0;

                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }

            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos3_2.X, (int)ballPos3_2.Y, 24, 24);
            Rectangle LockerRec3 = new Rectangle((int)ballLockerR3.X, (int)ballLockerR3.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom3_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom3_2 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom3_2 = "";
            }
            if (personRectangle.Intersects(LockerRec3) == true)
            {
                locker3 = "F To Hide";
                {
                    if (ks.IsKeyDown(Keys.F)) //Intereact object
                    {
                        personHit2 = true;
                    }
                }
            }
            else if (personRectangle.Intersects(LockerRec3) == false)
            {
                personHit2 = false;
                locker3 = "";
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateL_Room4()
        {

            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom2;
                dylight.Lights.Remove(spotLightR4);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 1000;
                camPos.X = 780;
                uiPos.X = 780;
                staminaPos.X = 1025;
                sanityPos.X = 1055;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }

            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.LRoom5;
                dylight.Lights.Remove(spotLightR4);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 100;
                camPos.X = 0;
                uiPos.X = 0;
                staminaPos.X = 245;
                sanityPos.X = 275;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos4_2.X, (int)ballPos4_2.Y, 24, 24);
            Rectangle ball2Rectangle = new Rectangle((int)ballPos4_5.X, (int)ballPos4_5.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom4_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom4_2 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom4_2 = "";
            }
            if (personRectangle.Intersects(ball2Rectangle) == true)
            {
                toRoom_5 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //toRoom_5 = "Enter room ?";
                        personHit2 = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ball2Rectangle) == false)
            {
                personHit2 = false;
                toRoom_5 = "";
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateL_Room5()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom4;
                dylight.Lights.Add(spotLightR4);
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                pos.X = 240;
            }

            if (personHit2 == true)
            {
                mCurrentScreen = Screenstate.LRoom6;
                dylight.Lights.Add(spotLightR6);
                dylight.Lights.Remove(spotLightR2_1);
                dylight.Lights.Remove(spotLightR2_2);
                dylight.Lights.Remove(spotLightR2_3);
                dylight.Lights.Remove(spotLightR2_4);
                spotLightR6.Position = new Vector2(300, 30);
                pos.X = 400;
            }

            if (personHit4 == true)
            {
                isHide = true;

                if (Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isHide = false;
                }
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if(isHide == false)
                {
                    if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                    {
                        hBarRec.Width -= 5;
                    }

                    if (ks.IsKeyDown(Keys.W))
                    {
                        w_instance.Play();

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
                        w_instance.Play();

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
                        w_instance.Play();

                        if (pos.X <= bLine.X && camPos.X > 0)
                        {
                            r_instance.Stop();
                            fLine -= new Vector2(3, 0);
                            bLine -= new Vector2(3, 0);
                            camPos -= new Vector2(3, 0);
                            uiPos -= new Vector2(3, 0);
                            staminaPos -= new Vector2(3, 0);
                            sanityPos -= new Vector2(3, 0);
                        }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine -= new Vector2(6, 0);
                            bLine -= new Vector2(6, 0);
                            camPos -= new Vector2(6, 0);
                            uiPos -= new Vector2(6, 0);
                            staminaPos -= new Vector2(6, 0);
                            sanityPos -= new Vector2(6, 0);
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
                        w_instance.Play();

                        if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width)
                        {
                            r_instance.Stop();
                            fLine += new Vector2(3, 0);
                            bLine += new Vector2(3, 0);
                            camPos += new Vector2(3, 0);
                            uiPos += new Vector2(3, 0);
                            staminaPos += new Vector2(3, 0);
                            sanityPos += new Vector2(3, 0);
                        }
                        if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                        {
                            w_instance.Stop();
                            r_instance.Play();
                            speed.X = 6;
                            fLine += new Vector2(6, 0);
                            bLine += new Vector2(6, 0);
                            camPos += new Vector2(6, 0);
                            uiPos += new Vector2(6, 0);
                            staminaPos += new Vector2(6, 0);
                            sanityPos += new Vector2(6, 0);
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
                        w_instance.Stop();
                        r_instance.Stop();
                        speed.X = 0;
                        UpdateFrame(elapsed);
                    }
                    if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                    {
                        UseStanimaPill();
                    }
                    if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                    {
                        UseSanityPill();
                    }
                }
                else
                {
                    speed.X = 0;

                    sBarRec.Width += 1;
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }

                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos5_4.X, (int)ballPos5_4.Y, 24, 24);
                Rectangle ball2Rectangle = new Rectangle((int)ballPos5_6.X, (int)ballPos5_6.Y, 24, 24);
                Rectangle LockerRec5 = new Rectangle((int)ballLockerR5.X, (int)ballLockerR5.Y, 24, 24);
                Rectangle enemyRectangle = new Rectangle((int)ePos.X, (int)ePos.Y, 60, 100);
                Rectangle trapRectangle = new Rectangle((int)trapPos.X, (int)trapPos.Y, -20, 50);

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
                if (personRectangle.Intersects(LockerRec5) == true)
                {
                    locker5 = "F To Hide";
                    {
                        if (ks.IsKeyDown(Keys.F)) //Intereact object
                        {
                            personHit4 = true;
                        }
                    }
                }
                else if (personRectangle.Intersects(LockerRec5) == false)
                {
                    personHit4 = false;
                    locker5 = "";
                }
                if (personRectangle.Intersects(ballRectangle) == true)
                {

                    backRoom5_4 = "F To Enter";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            //backRoom5_4 = "Enter room ?";
                            personHit = true;
                            d_instance.Play();
                        }
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit = false;
                    backRoom5_4 = "";
                }
                if (personRectangle.Intersects(ball2Rectangle) == true)
                {

                    toRoom_6 = "F To Enter";
                    {
                        if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                        {
                            //toRoom_6 = "Enter room ?";
                            personHit2 = true;
                            d_instance.Play();
                        }
                    }
                }
                else if (personRectangle.Intersects(ball2Rectangle) == false)
                {
                    personHit2 = false;
                    toRoom_6 = "";
                }

                old_ks = ks;
            }
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);
            //ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            textstaminaPos = staminaPos;
            textsanityPos = sanityPos;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdateL_Room6()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom5;
                dylight.Lights.Remove(spotLightR6);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 1170;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos6_5.X, (int)ballPos6_5.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom6_5 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom6_5 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom6_5 = "";
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(40, 40);

        }
        void UpdateL_Room7()
        {
            if (personHit == true)
            {
                mCurrentScreen = Screenstate.LRoom2;
                dylight.Lights.Remove(spotLightR7);
                dylight.Lights.Add(spotLightR2_1);
                dylight.Lights.Add(spotLightR2_2);
                dylight.Lights.Add(spotLightR2_3);
                dylight.Lights.Add(spotLightR2_4);
                pos.X = 260;
                pos.Y = 230;
                camPos.X = 0;
                uiPos.X = 0;
                staminaPos.X = 245;
                sanityPos.X = 275;
                fLine.X = pos.X + rad;
                bLine.X = pos.X - rad;
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            
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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Play();

                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
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
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
            }
            Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
            Rectangle ballRectangle = new Rectangle((int)ballPos7_2.X, (int)ballPos7_2.Y, 24, 24);
            if (personRectangle.Intersects(ballRectangle) == true)
            {
                backRoom7_2 = "F To Enter";
                {
                    if ((ks.IsKeyUp(Keys.F) && old_ks.IsKeyDown(Keys.F))) //Intereact object
                    {
                        //backRoom7_2 = "Enter room ?";
                        personHit = true;
                        d_instance.Play();
                    }
                }
            }
            else if (personRectangle.Intersects(ballRectangle) == false)
            {
                personHit = false;
                backRoom7_2 = "";
            }
            old_ks = ks;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
            eLight.Position = ePos - camPos + new Vector2(40, 40);
            light.Position = pos - camPos + new Vector2(60, 40);

        }
        void UpdateL_Room8()
        {
            if(personHit == true)
            {
                c_instance.Stop();
                w_instance.Stop();
                r_instance.Stop();
                mCurrentScreen = Screenstate.endcutscene;
            }
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                UpdateNormalMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                UpdateCryMoodFrame(elapsed);
            }
            else if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                UpdateFearMoodFrame(elapsed);
            }
            sanityText = sanity.ToString();
            staminaText = stamina.ToString();
            ProcessInput();
            KeyboardState ks = Keyboard.GetState();
            if (pos.X <= 1701)
            {
                isHuant2 = true;
            }
            if (isHuant2 == true)
            {
                instance.Stop();
                g1_instance.Play();
                c_instance.Play();
                eLight.Position = ((gPos - camPos) + new Vector2(40, 40)) * scroll_factor;
                gPos.X -= 4;
            }
            {
                if (ks.IsKeyDown(Keys.Space))//------------------------------Health debug----------------------------------------
                {
                    hBarRec.Width -= 5;
                }

                if (ks.IsKeyDown(Keys.W))
                {
                    w_instance.Play();

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
                    w_instance.Play();

                    
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
                    w_instance.Play();
                    if (pos.X <= bLine.X && camPos.X > 0)
                    {
                        
                        fLine -= new Vector2(3, 0);
                        bLine -= new Vector2(3, 0);
                        camPos -= new Vector2(3, 0);
                        uiPos -= new Vector2(3, 0);
                        staminaPos -= new Vector2(3, 0);
                        sanityPos -= new Vector2(3, 0);
                    }
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        fLine -= new Vector2(6, 0);
                        bLine -= new Vector2(6, 0);
                        camPos -= new Vector2(6, 0);
                        uiPos -= new Vector2(6, 0);
                        staminaPos -= new Vector2(6, 0);
                        sanityPos -= new Vector2(6, 0);
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        speed.X = 3;
                        r_instance.Stop();
                    }
                    pos.X = pos.X - speed.X;
                    direction = 1;

                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && pos.X < GraphicsDevice.Viewport.Width * 3 - 100)
                {
                    w_instance.Play();

                    if (pos.X >= fLine.X && camPos.X < GraphicsDevice.Viewport.Width * 2)
                    {
                        
                        fLine += new Vector2(3, 0);
                        bLine += new Vector2(3, 0);
                        camPos += new Vector2(3, 0);
                        uiPos += new Vector2(3, 0);
                        staminaPos += new Vector2(3, 0);
                        sanityPos += new Vector2(3, 0);
                    }
                    if (ks.IsKeyDown(Keys.LeftShift) && sBarRec.Width >= 0) //Stanima
                    {
                        w_instance.Stop();
                        r_instance.Play();
                        speed.X = 6;
                        fLine += new Vector2(6, 0);
                        bLine += new Vector2(6, 0);
                        camPos += new Vector2(6, 0);
                        uiPos += new Vector2(6, 0);
                        staminaPos += new Vector2(6, 0);
                        sanityPos += new Vector2(6, 0);
                        sBarRec.Width -= 3;
                    }
                    else
                    {
                        r_instance.Stop();
                        speed.X = 3;
                    }
                    pos.X = pos.X + speed.X;

                    direction = 2;
                    UpdateFrame(elapsed);
                }
                else
                {
                    if (sBarRec.Width >= 1)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width <= 0 && cooldowntime >= 5000)
                    {
                        sBarRec.Width = 0;
                        cooldowntime = 0;
                    }
                    if (cooldowntime == 0)
                    {
                        sBarRec.Width += 1;
                    }
                    if (sBarRec.Width >= 163)
                    {
                        sBarRec.Width = 163;
                    }
                }
                if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S) && ks.IsKeyUp(Keys.W))
                {
                    w_instance.Stop();
                    r_instance.Stop();
                    speed.X = 0;
                    UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D1) && old_ks.IsKeyDown(Keys.D1)) //Use stamina
                {
                    UseStanimaPill();
                }
                if (ks.IsKeyUp(Keys.D2) && old_ks.IsKeyDown(Keys.D2)) //Use sanity 
                {
                    UseSanityPill();
                }
                // -----------------------------------------------------------------------------------------------collistion
                Rectangle personRectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 80);
                Rectangle ballRectangle = new Rectangle((int)ballPos8_End.X, (int)ballPos8_End.Y, 24, 24);
                if (isHuant2)
                {
                    Rectangle ghostRectangle = new Rectangle((int)gPos.X, (int)gPos.Y, 50, 80);
                    if (personRectangle.Intersects(ghostRectangle) == true)
                    {
                        hBarRec.Width -= 25;
                    }
                    else if (personRectangle.Intersects(ghostRectangle) == false)
                    {
                        UpdateGhost(elapsed);
                    }
                }
                Rectangle trapRectangle = new Rectangle((int)trapPos.X, (int)trapPos.Y, 100, 100);

                if (personRectangle.Intersects(trapRectangle) == true)
                {
                    sBarRec.Width -= 3;
                }
                else if (personRectangle.Intersects(trapRectangle) == false)
                {

                }

                if (personRectangle.Intersects(ballRectangle) == true)
                {
                    toEnd = "F to Enter";

                    if(Keyboard.GetState().IsKeyDown(Keys.F))
                    {
                        personHit = true;
                        d_instance.Play();
                    }
                }
                else if (personRectangle.Intersects(ballRectangle) == false)
                {
                    personHit = false;
                    toEnd = "Check";
                }

                old_ks = ks;
            }
            light.Position = pos - camPos + new Vector2(40, 40);
            //ptext = "Position :" + pos.ToString() + "Speed :" + speed.ToString(); // Debug Text
            textPos = pos + new Vector2(5, 95);
            textstaminaPos = staminaPos;
            textsanityPos = sanityPos;
            light2.Position = uiPos - camPos + new Vector2(65, -370);
        }
        void UpdatePipePuzz()
        {
            if (timeSinceLastInput >= MinTimeSinceLastInput)
            {
                HandleMouseInput(Mouse.GetState(Window));
            }
            pipeboard.ResetWater();

            for (int y = 0; y < Pipeboard.GameBoardHeight; y++)
            {
                CheckScoringChain(pipeboard.GetWaterChain(y));
            }

            pipeboard.GenerateNewPieces(true);

        }
        void UpdatePassPuzz()
        {
            ///-------------------------------------------------------------------- passWord is 5432--------------------------------------------------
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyUp(Keys.Q)&& old_ks.IsKeyDown(Keys.Q))
            {
                passNum1++;
                if (passNum1>6)
                {
                    passNum1 = 1;
                }
            }
            if (ks.IsKeyUp(Keys.W) && old_ks.IsKeyDown(Keys.W))
            {
                passNum2++;
                if (passNum2 > 6)
                {
                    passNum2 = 1;
                }
            }
            if (ks.IsKeyUp(Keys.E) && old_ks.IsKeyDown(Keys.E))
            {
                passNum3++;
                if (passNum3 > 6)
                {
                    passNum3 = 1;
                }
            }
            if (ks.IsKeyUp(Keys.R) && old_ks.IsKeyDown(Keys.R))
            {
                passNum4++;
                if (passNum4 > 6)
                {
                    passNum4 = 1;
                }
            }
            if(passNum1 == 4 && passNum2 == 3 && passNum3 == 2 && passNum4 == 1)
            {
                mCurrentScreen = Screenstate.Room5;
                isClear = true;
                pos = new Vector2(201, 253);
            }

            if (ks.IsKeyDown(Keys.Back))
            {
                mCurrentScreen = Screenstate.Room5;
                pos = new Vector2(201, 253);
            }
            old_ks = ks;
        }

        void DrawRoom1()
        {
            _spriteBatch.Draw(room1, (bg2Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(paperTu, paperPos, new Rectangle(319, 264, 53, 41), (Color.White));
            _spriteBatch.Draw(ballTexture, capetPos, new Rectangle(0, 24, 0, 0), (Color.White));
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
            _spriteBatch.DrawString(deBugFont, tu1, (paperPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.DrawString(deBugFont, capetText, (capetPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.DrawString(deBugFont, gotItemText, (gotItemPos - new Vector2(40, 20)), (Color.Red));
            _spriteBatch.Draw(ballTexture, ballPos, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_2, (ballPos - new Vector2(0, 20)), (Color.White));
            if (isRead == true)
            {
                _spriteBatch.Draw(tutorial, Vector2.Zero, (Color.White));
            }
            if(isRead == false)
            {
                _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
                if(hBarRec.Width <= 163 && hBarRec.Width > 98)
                {
                    _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
                }
                if (hBarRec.Width <= 98 && hBarRec.Width > 49)
                {
                    _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
                }
                if (hBarRec.Width <= 49 && hBarRec.Width > 0)
                {
                    _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
                }
                _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
                _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
                _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
                _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
                if (cKey1 == true)
                {
                    _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
                }
                if (isClear == true)
                {
                    _spriteBatch.Draw(keyStory, key2Pos, Color.White);
                }
                _spriteBatch.DrawString(deBugFont, staminaText, (textstaminaPos + new Vector2(10,45)), (Color.White));
                _spriteBatch.DrawString(deBugFont, sanityText, (textsanityPos + new Vector2(10, 45)), (Color.White));
            }
            if (isRead2 == true)
            {
                _spriteBatch.Draw(note1, Vector2.Zero, (Color.White));
            }
        }
        void DrawMenu()
        {
            _spriteBatch.Draw(menuBG, Vector2.Zero, Color.White);
            _spriteBatch.Draw(menu, new Vector2 (0,80),new Rectangle(720 * bgframe, 0, 720, 480), Color.White);
            _spriteBatch.Draw(menuGlitch, new Vector2(30, -20), new Rectangle(722 * frame, 0, 722, 482), Color.White);
        }
        void DrawStartcutscene()
        {
            _spriteBatch.Draw(start_cut1, Vector2.Zero, new Rectangle(720 * startframe, 0, 720, 480),Color.White);
        }
        void DrawEndcutscene()
        {
            _spriteBatch.Draw(end_cut, Vector2.Zero, new Rectangle(720 * endframe, 0, 720, 480), Color.White);
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
            _spriteBatch.Draw(ball2Texture, (ballPos2_3 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball3Texture, (ballPos2_4 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball3Texture, (ballPos2_7 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, (ballLockerR2_1 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballLockerR2_2 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), Color.White);
            _spriteBatch.Draw(trap, trapPos - camPos * scroll_factor, new Rectangle(0, 0, 26, 26), (Color.White));
            _spriteBatch.Draw(paperTu, (paperPos - camPos) * scroll_factor, new Rectangle(319, 264, 53, 41), (Color.White));
            _spriteBatch.DrawString(deBugFont, tu1, ((paperPos - new Vector2(0, 20)) - camPos) * scroll_factor, (Color.White));
            if (isHide == false)
            {
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
            
            }
            if (isAlive == true)
            {
                _spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 120, 120), (Color.White));
            }   
            _spriteBatch.DrawString(deBugFont, backRoom2_1, (ballPos2_1 - new Vector2(0, 20) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_3, (ballPos2_3 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_4, (ballPos2_4 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_7, (ballPos2_7 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, locker2_1, (ballLockerR2_1 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, locker2_2, (ballLockerR2_2 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            if(isHuant1 == true)
            {
                _spriteBatch.Draw(ghostWalk, (gPos - camPos) * scroll_factor,new Rectangle(72 *gframe,100 * gdirection,72,100), Color.White);
            }
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (isRead == true)
            {
                _spriteBatch.Draw(note2, Vector2.Zero, (Color.White));
            }
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            //SpotLight
            spotLightR2_1.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLightR2_2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLightR2_3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLightR2_4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }
        void DrawRoom3()
        {
            _spriteBatch.Draw(room3, Vector2.Zero, Color.White);
            _spriteBatch.Draw(ballTexture, capetPos, new Rectangle(0, 24, 0, 0), (Color.White));
            if (isHide == false)
            {
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
            }
            _spriteBatch.DrawString(deBugFont, capetText, (capetPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.DrawString(deBugFont, gotItemText, (gotItemPos - new Vector2(40, 20)), (Color.Red));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.Draw(ballTexture, ballPos3_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, ballLockerR3, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont,locker3, (ballLockerR3 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom3_2, (ballPos3_2 - new Vector2(0, 80)), (Color.White));
            
        }
        void DrawRoom4()
        {
            _spriteBatch.Draw(room4, Vector2.Zero, Color.White);
            _spriteBatch.Draw(ballTexture, capetPos, new Rectangle(0, 24, 0, 0), (Color.White));
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
            _spriteBatch.DrawString(deBugFont, capetText, (capetPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.DrawString(deBugFont, gotItemText, (gotItemPos - new Vector2(40, 20)), (Color.Red));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos4_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, ballPos4_5, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom4_2, (ballPos4_2 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_5, (ballPos4_5 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
        }
        void DrawRoom5()
        {
            _spriteBatch.Draw(room5_1, (bg5Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(room5_2, (bg5Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos5_4 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, (ballPos5_6 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, (puzzlePos2 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, (ballLockerR5 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(paperTu, paperPos - camPos * scroll_factor, new Rectangle(319, 264, 53, 41), (Color.White));
            if (isHide == false)
            {
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
            }
            //_spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 0, 0), (Color.White));
            //_spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 120, 120), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom5_4, (ballPos5_4 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_6, (ballPos5_6 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, puzzle2, (puzzlePos2 - new Vector2(0, 50) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, locker5, (ballLockerR5 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, tu3, (paperPos - new Vector2(0, 20) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            enemy.Draw(_spriteBatch,camPos,scroll_factor,eframe);
            if (isRead == true)
            {
                _spriteBatch.Draw(tutorial2, Vector2.Zero, (Color.White));
            }
            //SpotLight
            spotLightR2_1.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLightR2_2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLightR2_3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLightR2_4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }
        void DrawRoom6()
        {
            _spriteBatch.Draw(room6, Vector2.Zero, Color.White);
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
            _spriteBatch.DrawString(deBugFont, tu2, (paperPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.DrawString(deBugFont, tu1, (paperPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos6_5, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, puzzlePos3, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom6_5, (ballPos6_5 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, puzzle3, (puzzlePos3 - new Vector2(20, 50)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
        }
        void DrawRoom7()
        {
            _spriteBatch.Draw(room7, Vector2.Zero, Color.White);
            _spriteBatch.Draw(paperTu, paperPos, new Rectangle(319, 264, 53, 41), (Color.White));
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

            _spriteBatch.Draw(ballTexture, ballPos7_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, puzzlePos1, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom7_2, (ballPos7_2 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, puzzle1, (puzzlePos1 - new Vector2(20, 50)), (Color.White));
            _spriteBatch.DrawString(deBugFont, tu2, (paperPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            if (isRead == true)
            {
                _spriteBatch.Draw(tutorial3, Vector2.Zero, (Color.White));
            }
            if(isRead == false)
            {
                _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
                if (hBarRec.Width <= 163 && hBarRec.Width > 98)
                {
                    _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
                }
                if (hBarRec.Width <= 98 && hBarRec.Width > 49)
                {
                    _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
                }
                if (hBarRec.Width <= 49 && hBarRec.Width > 0)
                {
                    _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
                }
                _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
                _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            }

        }

        void DrawL_Room1()
        {
            _spriteBatch.Draw(Lroom1, (bg2Pos - camPos) * scroll_factor, Color.White);
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
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_2, (ballPos - new Vector2(0, 20)), (Color.White));
            _spriteBatch.Draw(ball2Texture, ballPos8, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_8, (ballPos8 - new Vector2(0, 20)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
        }
        void DrawL_Room2()
        {
            _spriteBatch.Draw(Lroom2_1, (bg2Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(Lroom2_2, (bg2Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(Lroom2_3, (bg2Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width + 720, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos2_1 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, (ballPos2_3 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball3Texture, (ballPos2_4 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball3Texture, (ballPos2_7 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, (ballLockerR2_1 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballLockerR2_2 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), Color.White);
            _spriteBatch.Draw(trap, trapPos - camPos * scroll_factor, new Rectangle(0, 0, 26, 26), (Color.White));
            if(isHide == false)
            {
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
            }
            _spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 120, 120), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom2_1, (ballPos2_1 - new Vector2(0, 20) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_3, (ballPos2_3 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_4, (ballPos2_4 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_7, (ballPos2_7 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, locker2_1, (ballLockerR2_1 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, locker2_2, (ballLockerR2_2 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            //SpotLight
            spotLightR2_1.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLightR2_2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLightR2_3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLightR2_4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }
        void DrawL_Room3()
        {
            _spriteBatch.Draw(Lroom3, Vector2.Zero, Color.White);
            if(isHide == false)
            {
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
            }
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos3_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, ballLockerR3, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, locker3, (ballLockerR3 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom3_2, (ballPos3_2 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
        }
        void DrawL_Room4()
        {
            _spriteBatch.Draw(Lroom4, Vector2.Zero, Color.White);
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
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos4_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, ballPos4_5, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom4_2, (ballPos4_2 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_5, (ballPos4_5 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
        }
        void DrawL_Room5()
        {
            _spriteBatch.Draw(Lroom5_1, (bg5Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(Lroom5_2, (bg5Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos5_4 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ball2Texture, (ballPos5_6 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.Draw(ballTexture, (ballLockerR5 - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            if(isHide == false)
            {
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
            }
            _spriteBatch.Draw(eTexture, ePos - camPos * scroll_factor, new Rectangle(120 * eframe, 0, 120, 120), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom5_4, (ballPos5_4 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toRoom_6, (ballPos5_6 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, locker5, (ballLockerR5 - new Vector2(0, 80) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            //SpotLight
            spotLightR2_1.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLightR2_2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLightR2_3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLightR2_4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }
        void DrawL_Room6()
        {
            _spriteBatch.Draw(Lroom6, Vector2.Zero, Color.White);
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
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos6_5, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom6_5, (ballPos6_5 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
        }
        void DrawL_Room7()
        {
            _spriteBatch.Draw(Lroom7, Vector2.Zero, Color.White);
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
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(ballTexture, ballPos7_2, new Rectangle(0, 24, 0, 0), (Color.White));
            _spriteBatch.DrawString(deBugFont, backRoom7_2, (ballPos7_2 - new Vector2(0, 80)), (Color.White));
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
        }
        void DrawL_Room8()
        {
            _spriteBatch.Draw(Lroom8_1, (bg2Pos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(Lroom8_2, (bg2Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width, 0), Color.White);
            _spriteBatch.Draw(Lroom8_3, (bg2Pos - camPos) * scroll_factor + new Vector2(_graphics.GraphicsDevice.Viewport.Width + 720, 0), Color.White);
            _spriteBatch.Draw(ballTexture, (ballPos8_End - camPos) * scroll_factor, new Rectangle(0, 24, 0, 0), (Color.White));
            
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
            if (isHuant2 == true)
            {
                _spriteBatch.Draw(ghostWalk, gPos - camPos * scroll_factor, new Rectangle(72 * gframe, 100, 72, 100), (Color.White));
                _spriteBatch.Draw(trap, trapPos - camPos * scroll_factor, new Rectangle(26*gframe, 0, 26, 26), (Color.White));
            }
            _spriteBatch.DrawString(deBugFont, ptext, (textPos - camPos) * scroll_factor, (Color.White));
            _spriteBatch.DrawString(deBugFont, toEnd, (ballPos8_End - new Vector2(0, 40) - camPos) * scroll_factor, (Color.White));
            _spriteBatch.Draw(uiTexture, (uiPos - camPos) * scroll_factor, Color.White);
            if (hBarRec.Width <= 163 && hBarRec.Width > 98)
            {
                _spriteBatch.Draw(normal_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * normalframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 98 && hBarRec.Width > 49)
            {
                _spriteBatch.Draw(cry_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * cryframe, 0, 74, 74), Color.White);
            }
            if (hBarRec.Width <= 49 && hBarRec.Width > 0)
            {
                _spriteBatch.Draw(fear_mood, (uiPos - camPos) * scroll_factor, new Rectangle(74 * fearframe, 0, 74, 74), Color.White);
            }
            _spriteBatch.Draw(sanityBar, ((uiPos + sbarPos) - camPos) * scroll_factor, hBarRec, Color.White);
            _spriteBatch.Draw(staminaBar, ((uiPos + sbarPos + new Vector2(0, 33)) - camPos) * scroll_factor, sBarRec, Color.White);
            _spriteBatch.Draw(sPill, (staminaPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.Draw(hPill, (sanityPos - camPos) * scroll_factor, Color.White);
            _spriteBatch.DrawString(deBugFont, staminaText, ((textstaminaPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            _spriteBatch.DrawString(deBugFont, sanityText, ((textsanityPos + new Vector2(10, 25) - camPos) * scroll_factor), (Color.White));
            if (cKey1 == true)
            {
                _spriteBatch.Draw(keyNormal, key1Pos, Color.White);
            }
            if (isClear == true)
            {
                _spriteBatch.Draw(keyStory, key2Pos, Color.White);
            }
            //SpotLight
            spotLightR2_1.Position = (new Vector2(894, 30) - camPos) * scroll_factor;
            spotLightR2_2.Position = (new Vector2(1212, 25) - camPos) * scroll_factor;
            spotLightR2_3.Position = (new Vector2(1557, 30) - camPos) * scroll_factor;
            spotLightR2_4.Position = (new Vector2(163, 30) - camPos) * scroll_factor;
        }

        void DrawPipePuzz()
        {
                for (int x = 0; x < Pipeboard.GameBoardWidth; x++)
                {
                    for (int y = 0; y < Pipeboard.GameBoardHeight; y++)
                    {
                        int pixelX = (int)gameBoardDisplayOrigin.X +
                        (x * PipePiece.PieceWidth);
                        int pixelY = (int)gameBoardDisplayOrigin.Y +
                        (y * PipePiece.PieceHeight);

                        _spriteBatch.Draw(playingPieces, new Rectangle(pixelX, pixelY, PipePiece.PieceWidth, PipePiece.PieceHeight), EmptyPiece, Color.White);
                        _spriteBatch.Draw(playingPieces, new Rectangle(pixelX, pixelY, PipePiece.PieceWidth, PipePiece.PieceHeight), pipeboard.GetSourceRect(x, y), Color.Red);
                    }
                }
        }
        void DrawPassPuzz()
        {
            _spriteBatch.Draw(passBackgroud, new Vector2(100, 30), Color.White);
            _spriteBatch.Draw(passTexture, new Vector2(130, 94), new Rectangle(80 * passNum1, 0, 80, 288), Color.White);
            if (passNum1 == 6)
            {
                _spriteBatch.Draw(passTexture, new Vector2(130, 94), new Rectangle(0 * passNum1, 0, 80, 288), Color.White);
            }
            _spriteBatch.Draw(passTexture, new Vector2(243, 94), new Rectangle(80 * passNum2, 0, 80, 288), Color.White);
            if (passNum2 == 6)
            {
                _spriteBatch.Draw(passTexture, new Vector2 (243, 94), new Rectangle(0 * passNum2, 0, 80, 288), Color.White);
            }
            _spriteBatch.Draw(passTexture, new Vector2(356, 94), new Rectangle(80 * passNum3, 0, 80, 288), Color.White);
            if (passNum3 == 6)
            {
                _spriteBatch.Draw(passTexture, new Vector2(356, 94), new Rectangle(0 * passNum3, 0, 80, 288), Color.White);
            }
            _spriteBatch.Draw(passTexture, new Vector2(469, 94), new Rectangle(80 * passNum4, 0, 80, 288), Color.White);
            if (passNum4 == 6)
            {
                _spriteBatch.Draw(passTexture, new Vector2(469, 94), new Rectangle(0 * passNum4, 0, 80, 288), Color.White);
            }
        }

        void UpdateMenuFrame(float elapsed)
        {
            bgtotalelapsed += elapsed;
            if (bgtotalelapsed > bgtimeperframe)
            {
                bgframe = (bgframe + 1) % bgtotalframe;
                bgtotalelapsed -= bgtimeperframe;
            }
        }
        void UpdateStartCutFrame(float elapsed)
        {
            starttotalelapsed += elapsed;
            if (starttotalelapsed > starttimeperframe)
            {
                startframe = (startframe + 1) % starttotalframe;
                starttotalelapsed -= starttimeperframe;
            }
        }
        void UpdateEndCutFrame(float elapsed)
        {
            endtotalelapsed += elapsed;
            if (endtotalelapsed > endtimeperframe)
            {
                endframe = (endframe + 1) % endtotalframe;
                endtotalelapsed -= endtimeperframe;
            }
        }
        void UpdateNormalMoodFrame(float elapsed)
        {
            normaltotalelapsed += elapsed;
            if (normaltotalelapsed > normaltimeperframe)
            {
                normalframe = (normalframe + 1) % normaltotalframe;
                normaltotalelapsed -= normaltimeperframe;
            }
        }
        void UpdateCryMoodFrame(float elapsed)
        {
            crytotalelapsed += elapsed;
            if (crytotalelapsed > crytimeperframe)
            {
                cryframe = (cryframe + 1) % crytotalframe;
                crytotalelapsed -= crytimeperframe;
            }
        }
        void UpdateFearMoodFrame(float elapsed)
        {
            feartotalelapsed += elapsed;
            if (feartotalelapsed > feartimeperframe)
            {
                fearframe = (fearframe + 1) % feartotalframe;
                feartotalelapsed -= feartimeperframe;
            }
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

        void UpdateGhost(float elapsed)
        {
            gtotalelapsed += elapsed;
            if (gtotalelapsed > gtimeperframe)
            {
                gframe = (gframe + 1) % gtotalframe;
                gtotalelapsed -= gtimeperframe;
            }
        }
        protected void ProcessInput()
        {
            // TODO: Add your input handle here


        }
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        private int DetermineScore(int SquareCount)
        {
            return (int)((Math.Pow((SquareCount / 5), 2) + SquareCount) * 10);
        }
        private void CheckScoringChain(List<Vector2> WaterChain)
        {
            if (WaterChain.Count > 0)
            {
                Vector2 LastPipe = WaterChain[WaterChain.Count - 1];

                if (LastPipe.X == Pipeboard.GameBoardWidth - 1)
                {
                    if (pipeboard.HasConnector((int)LastPipe.X, (int)LastPipe.Y, "Right"))
                    {
                        playerScore += DetermineScore(WaterChain.Count);
                        if (inRoom6 == true)
                        {
                            isPipe2Clear = true;
                            mCurrentScreen = Screenstate.LRoom6;
                        }
                        else
                        {
                            isPipe1Clear = true;
                            mCurrentScreen = Screenstate.Room7;
                            dylight.Lights.Add(spotLightR7);
                        }
                        foreach (Vector2 ScoringSquare in WaterChain)
                        {
                            pipeboard.SetSquare((int)ScoringSquare.X,
                            (int)ScoringSquare.Y, "Empty");
                        }
                    }
                }
            }
        }
        private void HandleMouseInput(MouseState mouseState)
        {
            int x = ((mouseState.X - (int)gameBoardDisplayOrigin.X) / PipePiece.PieceWidth);
            int y = ((mouseState.Y - (int)gameBoardDisplayOrigin.Y) / PipePiece.PieceHeight);
            if ((x >= 0) && (x < Pipeboard.GameBoardWidth) && (y >= 0) & (y < Pipeboard.GameBoardHeight))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    pipeboard.RotatePiece(x, y, false);
                    timeSinceLastInput = 0.0f;
                }
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    pipeboard.RotatePiece(x, y, true);
                    timeSinceLastInput = 0.0f;
                }
            }
        }
        private void AddStanimaPill()
        {
            stamina++;
        }
        private void AddSanityPill()
        {
            sanity ++;
        }
        private void UseStanimaPill()
        {
            if(stamina >= 1)
            {
                stamina--;
                sBarRec.Width += 50;
            }
        }
        private void UseSanityPill()
        {
            if (sanity >= 1)
            {
                sanity--;
                hBarRec.Width += 70;
            }
        }
    }
}

