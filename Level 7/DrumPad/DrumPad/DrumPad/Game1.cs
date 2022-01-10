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

namespace DrumPad
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SoundEffect cymbolTing;
        SoundEffect kick;
        SoundEffect snare;
        SoundEffect top;
        SoundEffect music;
        SoundEffectInstance musicInstance;
        Song tune;
        GamePadState pad1;
        GamePadState oldpad1;


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

            cymbolTing = Content.Load<SoundEffect>("cymbolTing");
            kick= Content.Load<SoundEffect>("kick");
            snare = Content.Load<SoundEffect>("snare");
            top= Content.Load<SoundEffect>("top");
            music = Content.Load<SoundEffect>("music");
            tune = Content.Load<Song>("song");
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
            pad1 = GamePad.GetState(PlayerIndex.One);


            // Allows the game to exit
            if (pad1.Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (oldpad1.Buttons.A == ButtonState.Released && pad1.Buttons.A == ButtonState.Pressed)
            {
                snare.Play();
            }
            if (oldpad1.Buttons.B == ButtonState.Released && pad1.Buttons.B == ButtonState.Pressed)
            {
                kick.Play();
            }
            if (oldpad1.Buttons.X == ButtonState.Released && pad1.Buttons.X == ButtonState.Pressed)
            {
                top.Play();
            }
            if (oldpad1.Buttons.Y == ButtonState.Released && pad1.Buttons.Y == ButtonState.Pressed)
            {
                cymbolTing.Play();
            }
            if (oldpad1.Buttons.LeftShoulder == ButtonState.Released && pad1.Buttons.LeftShoulder == ButtonState.Pressed)
            {
                if (MediaPlayer.State == MediaState.Paused)
                {
                    MediaPlayer.Resume();
                }
                else
                {
                    MediaPlayer.Play(tune);
                }
                
            }
            if (oldpad1.Buttons.RightShoulder == ButtonState.Released && pad1.Buttons.RightShoulder == ButtonState.Pressed)
            {
                if (MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Pause();
                }
            }
            oldpad1 = pad1;


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
