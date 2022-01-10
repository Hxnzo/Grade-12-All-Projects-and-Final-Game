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

namespace Health_Bar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Car ambulence;
        GamePadState pad1;
        KeyboardState kb;
        Rectangle healthBar;
        Texture2D healthBarImage;
        Car[] meds;
        Texture2D medsImage;
        Random rnd;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            rnd = new Random();
            meds = new Car[3];

            Rectangle myRec = new Rectangle(45, 45, 45, 45);
            Color myColor = Color.White;
            Texture2D up = Content.Load<Texture2D>("AmbulanceBackward");
            ambulence = new Car(myRec, up, myColor, 1, Content);

            healthBar = new Rectangle(10, 10, 100, 30);
            healthBarImage = Content.Load<Texture2D>("Red");

            // draw medicine bottles for loop
            medsImage = Content.Load<Texture2D>("Medicine Bottle");
            for (int i = 0; i < 3; i++)
            {
                meds[0] = new Car(new Rectangle(rnd.Next(GraphicsDevice.Viewport.Width), rnd.Next(GraphicsDevice.Viewport.Height), 20, 20), medsImage, Color.White, 1, Content);
                meds[1] = new Car(new Rectangle(rnd.Next(GraphicsDevice.Viewport.Width), rnd.Next(GraphicsDevice.Viewport.Height), 20, 20), medsImage, Color.White, 1, Content);
                meds[2] = new Car(new Rectangle(rnd.Next(GraphicsDevice.Viewport.Width), rnd.Next(GraphicsDevice.Viewport.Height), 20, 20), medsImage, Color.White, 1, Content);
            }

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            pad1 = GamePad.GetState(PlayerIndex.One);
            kb = Keyboard.GetState(PlayerIndex.One);

            ambulence.turn(pad1, kb);
            ambulence.ChangeGears(kb);
            ambulence.MoveIt(pad1, kb);


            if (ambulence.GetRec().Intersects(meds[0].GetRec()))
            {
                GetMeds(meds[0]);
            }
            else if (ambulence.GetRec().Intersects(meds[1].GetRec()))
            {
                GetMeds(meds[1]);
            }
            else if (ambulence.GetRec().Intersects(meds[2].GetRec()))
            {
                GetMeds(meds[2]);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            DrawBackground();
            spriteBatch.Draw(healthBarImage, healthBar, Color.Red);
            spriteBatch.Draw(medsImage, meds[0].GetRec(), Color.White);
            spriteBatch.Draw(medsImage, meds[1].GetRec(), Color.White);
            spriteBatch.Draw(medsImage, meds[2].GetRec(), Color.White);
            ambulence.DrawIt(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void DrawBackground()
        {
            Texture2D background = Content.Load<Texture2D>("Hospital Parking Lot");
            Rectangle aRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            spriteBatch.Draw(background, aRec, Color.White);
        }

        private void GetMeds(Car meds)
        {
            healthBar.Width += 25;
            meds.SetRec(new Rectangle(-1000, -1000, 1, 1));
        }
    }
}
