using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ClassLibrary1;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary >
        /// Bottom paddle object
        /// </ summary >
        public Paddle PaddleBottom { get; private set; }
        /// <summary >
        /// Top paddle object
        /// </ summary >
        public Paddle PaddleTop { get; private set; }
        /// <summary >
        /// Ball object
        /// </ summary >
        public Ball Ball { get; private set; }
        /// <summary >
        /// Background image
        /// </ summary >
        public Background Background { get; private set; }
        /// <summary >
        /// Sound when ball hits an obstacle .
        /// SoundEffect is a type defined in Monogame framework
        /// </ summary >
        public SoundEffect HitSound { get; private set; }
        /// <summary >
        /// Background music . Song is a type defined in Monogame framework
        /// </ summary >
        public Song Music { get; private set; }
        /// <summary >
        /// Generic list that holds Sprites that should be drawn on screen
        /// </ summary >
        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500
            };
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Screen bounds details . Use this information to set up game objects positions.
            var screenBounds = GraphicsDevice.Viewport.Bounds;
            PaddleBottom = new Paddle(GameConstants.PaddleDefaultWidth,
            GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);
            //PaddleBottom.X = < PaddleBottom X Position >;
            //PaddleBottom.Y = < PaddleBottom Y Position >;
            PaddleBottom.X = 0;
            PaddleBottom.Y = 0;
            PaddleTop = new Paddle(GameConstants.PaddleDefaultWidth,
            GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);
            //PaddleTop.X = < PaddleTop X Position >;
            //PaddleTop.Y = < PaddleTop Y Position >;
            Ball = new Ball(GameConstants.DefaultBallSize,
            GameConstants.DefaultInitialBallSpeed,
            GameConstants.DefaultBallBumpSpeedIncreaseFactor)
            {
                //X = < Ball center X Position >
                //Y = < Ball center Y Position >
                X = 10,
                Y = 10
            };
            //Background = new Background( < width of the screen bounds > , < height of the screen bounds >);
            Background = new Background(200, 300);
            // Add our game objects to the sprites that should be drawn collection .. you ’ll see why in a second
            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Initialize new SpriteBatch object which will be used to draw textures .
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Set textures
            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            PaddleBottom.Texture = paddleTexture;
            PaddleTop.Texture = paddleTexture;
            Ball.Texture = Content.Load<Texture2D>("ball");
            Background.Texture = Content.Load<Texture2D>("background");
            // Load sounds
            // Start background music
            HitSound = Content.Load<SoundEffect>("hit");
            Music = Content.Load<Song>("music");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Music);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Start drawing .
            spriteBatch.Begin();
            for (int i = 0; i < SpritesForDrawList.Count; i++)
            {
                SpritesForDrawList.GetElement(i).DrawSpriteOnScreen(spriteBatch);
            }
            // End drawing .
            // Send all gathered details to the graphic card in one batch .
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
