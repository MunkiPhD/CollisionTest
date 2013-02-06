using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CollisionTest {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D level;
        Texture2D player;
        MapData mapData;

        Vector2 playerMovement = Vector2.Zero;
        Vector2 playerPosition;
        float maxSpeed = 30f;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            level = Content.Load<Texture2D>("Background");
            player = Content.Load<Texture2D>("Player");
            mapData = new MapData(Content, GraphicsDevice.Viewport);

            playerPosition = new Vector2(200, 300);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();



            // player input
            KeyboardState keyState = Keyboard.GetState();
            // x-axis
            if(keyState.IsKeyDown(Keys.A)) {
                playerMovement.X = -1;
            } else if(keyState.IsKeyDown(Keys.D)) {
                playerMovement.X = 1;
            } else {
                playerMovement.X = 0;
            }

            // y-axis
            if(keyState.IsKeyDown(Keys.W)) {
                playerMovement.Y = -1;
            } else if(keyState.IsKeyDown(Keys.S)) {
                playerMovement.Y = 1;
            } else {
                playerMovement.Y = 0;
            }


            // move the player sprite
            playerPosition += maxSpeed * playerMovement;

            // set the bounds to the size of the viewport
            int left = GraphicsDevice.Viewport.TitleSafeArea.Left;
            int right = GraphicsDevice.Viewport.TitleSafeArea.Right - player.Width;
            playerPosition.X = MathHelper.Clamp(playerPosition.X, left, right);

            int top = GraphicsDevice.Viewport.TitleSafeArea.Top;
            int bottom = GraphicsDevice.Viewport.TitleSafeArea.Bottom - player.Height;
            playerPosition.Y = MathHelper.Clamp(playerPosition.Y, top, bottom);

            mapData.Update(gameTime, GraphicsDevice.Viewport);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(level, new Vector2(0, 0), Color.White);
            mapData.Draw(spriteBatch);
            spriteBatch.Draw(player, playerPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
