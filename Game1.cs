#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace Breakernoid
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D bgTexture;
        Paddle paddle;
        Ball ball;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bgTexture = Content.Load<Texture2D>("bg");

            paddle = new Paddle(this);
            paddle.LoadContent();
            paddle.position = new Vector2(512, 740);

            ball = new Ball(this);
            ball.LoadContent();
            ball.position = new Vector2(512, 720);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // TODO: Add your update logic here
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            paddle.Update(deltaTime);
            ball.Update(deltaTime);
            this.CheckCollisions();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            // Draw all sprites here
            spriteBatch.Draw(bgTexture, new Vector2(0, 0), Color.White);
            paddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void CheckCollisions()
        {
            float radius = ball.Width / 2;

            // Paddle collision
            if (
                (ball.position.X > (paddle.position.X - radius - paddle.Width / 2)) &&
                (ball.position.X < (paddle.position.X + radius + paddle.Width / 2)) &&
                (ball.position.Y < paddle.position.Y) &&
                (ball.position.Y > (paddle.position.Y - radius - paddle.Height / 2))
            )
            {
                ball.direction.Y = -1.0f * ball.direction.Y;
            }

            if (Math.Abs(ball.position.X - 32) < radius)
            {
                ball.direction.X = -1.0f * ball.direction.X;
            }
            else if (Math.Abs(ball.position.X - 992) < radius)
            {
                ball.direction.X = -1.0f * ball.direction.X;
            }

            //Top collision
            if (Math.Abs(ball.position.Y - 32) < radius)
            {
                ball.direction.Y = -1.0f * ball.direction.Y;
            }

            // Floor collision
            /*if (Math.Abs(ball.position.Y - 768) < radius)
            {
                ball.direction.Y = -1.0f * ball.direction.Y;
            }*/


        }
    }
}
