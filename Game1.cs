using ChekhovsUtil;
using ChekhovsUtil.cache;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TalosSoccer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ResourceCache ResourceCache { get; private set; }

        private int virtualWidth = 1280;
        private int virtualHeight = 720;
        private float aspectRatio;
        private float screenAspectRatio;
        private Matrix scaleMatrix;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            aspectRatio = virtualWidth / (float)virtualHeight;
            screenAspectRatio = GraphicsDevice.Viewport.Width / (float)GraphicsDevice.Viewport.Height;
            scaleMatrix = Matrix.Identity;
            ChekhovSettings.Initialize("TalosSoccer");
            ResourceCache = ResourceCache.Instance;
            ResourceCache.Initialize(Content);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ResourceCache.LoadTexture("field", "Misc/field");
            ResourceCache.LoadTexture("ball", "Misc/ball");

            Window.ClientSizeChanged += OnWindowSizeChanged;
            UpdateScaleMatrix();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: scaleMatrix);

            // Draw your game elements here

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void OnWindowSizeChanged(object sender, EventArgs e)
        {
            UpdateScaleMatrix();
        }

        private void UpdateScaleMatrix()
        {
            float scaleX = GraphicsDevice.Viewport.Width / (float)virtualWidth;
            float scaleY = GraphicsDevice.Viewport.Height / (float)virtualHeight;
            float scale = Math.Min(scaleX, scaleY);

            int viewportWidth = (int)(virtualWidth * scale);
            int viewportHeight = (int)(virtualHeight * scale);

            int viewportX = (GraphicsDevice.Viewport.Width / 2) - (viewportWidth / 2);
            int viewportY = (GraphicsDevice.Viewport.Height / 2) - (viewportHeight / 2);

            GraphicsDevice.Viewport = new Viewport(viewportX, viewportY, viewportWidth, viewportHeight);
            scaleMatrix = Matrix.CreateScale(scale);
        }
    }
}