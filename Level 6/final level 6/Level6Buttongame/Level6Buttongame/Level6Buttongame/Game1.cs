using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Level6Buttongame
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        SpriteFont font2;
        int time;
        int timer = 0;
        bool time4 = false;
        bool time10 = false;
        KeyboardState kb;
        //Game Pad1:
        GamePadState oldpad;
        GamePadState pad1;

        int xcount = 0;
        int acount = 0;
        int bcount = 0;
        int ycount = 0;

        Vector2 bpos = new Vector2(200, 100);
        Vector2 apos = new Vector2(150, 150);
        Vector2 ypos = new Vector2(150, 50);
        Vector2 xpos = new Vector2(100, 100);

        //Game Pad2:
        GamePadState oldpad2;
        GamePadState pad2;

        int bcount2 = 0;
        int xcount2 = 0;
        int ycount2 = 0;
        int acount2 = 0;

        Vector2 bpos2 = new Vector2(650, 150);
        Vector2 xpos2 = new Vector2(700, 100);
        Vector2 ypos2 = new Vector2(600, 100);
        Vector2 apos2 = new Vector2(650, 50);

        //Game Pad3:
        GamePadState oldpad3;
        GamePadState pad3;

        int bcount3 = 0;
        int xcount3 = 0;
        int ycount3 = 0;
        int acount3 = 0;

        Vector2 bpos3 = new Vector2(150, 350);
        Vector2 xpos3 = new Vector2(200, 300);
        Vector2 ypos3 = new Vector2(100, 300);
        Vector2 apos3 = new Vector2(150, 250);

        //Game Pad4:
        GamePadState oldpad4;
        GamePadState pad4;

        int bcount4 = 0;
        int xcount4 = 0;
        int ycount4 = 0;
        int acount4 = 0;

        Vector2 bpos4 = new Vector2(650,350);
        Vector2 xpos4 = new Vector2(700,300);
        Vector2 ypos4 = new Vector2(600,300);
        Vector2 apos4 = new Vector2(650,250);

        bool gameOver = false;

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

            bcount = 0;
            xcount = 0;
            ycount = 0;
            acount = 0;

            bcount4 = 0;
            xcount4 = 0;
            ycount4 = 0;
            acount4 = 0;

            bcount2 = 0;
            xcount2 = 0;
            ycount2 = 0;
            acount2 = 0;

            bcount3 = 0;
            xcount3 = 0;
            ycount3 = 0;
            acount3 = 0;
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

            font = this.Content.Load<SpriteFont>("SpriteFont1");
            font2 = this.Content.Load<SpriteFont>("SpriteFont2");



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

            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                time4 = true;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                time10 = true;
            }

            if (time4 || time10)
            {

                pad1 = GamePad.GetState(PlayerIndex.One);
                pad2 = GamePad.GetState(PlayerIndex.Two);
                pad3 = GamePad.GetState(PlayerIndex.Three);
                pad4 = GamePad.GetState(PlayerIndex.Four);
                
                if (pad1.IsConnected)
                {
                    if (oldpad.Buttons.A == ButtonState.Released && pad1.Buttons.A == ButtonState.Pressed)
                    {
                        acount++;
                    }
                    if (oldpad.Buttons.B == ButtonState.Released && pad1.Buttons.B == ButtonState.Pressed)
                    {
                        bcount++;
                    }
                    if (oldpad.Buttons.X == ButtonState.Released && pad1.Buttons.X == ButtonState.Pressed)
                    {
                        xcount++;
                    }
                    if (oldpad.Buttons.Y == ButtonState.Released && pad1.Buttons.Y == ButtonState.Pressed)
                    {
                        ycount++;
                    }
                    oldpad = pad1;

                }

                if (pad2.IsConnected)
                {
                    if (oldpad2.Buttons.A == ButtonState.Released && pad2.Buttons.A == ButtonState.Pressed)
                    {
                        acount2++;
                    }
                    if (oldpad2.Buttons.B == ButtonState.Released && pad2.Buttons.B == ButtonState.Pressed)
                    {
                        bcount2++;
                    }
                    if (oldpad2.Buttons.X == ButtonState.Released && pad2.Buttons.X == ButtonState.Pressed)
                    {
                        xcount2++;
                    }
                    if (oldpad2.Buttons.Y == ButtonState.Released && pad2.Buttons.Y == ButtonState.Pressed)
                    {
                        ycount2++;
                    }
                    oldpad2 = pad2;

                }

                if (pad3.IsConnected)
                {
                    if (oldpad3.Buttons.A == ButtonState.Released && pad3.Buttons.A == ButtonState.Pressed)
                    {
                        acount3++;
                    }
                    if (oldpad3.Buttons.B == ButtonState.Released && pad3.Buttons.B == ButtonState.Pressed)
                    {
                        bcount3++;
                    }
                    if (oldpad3.Buttons.X == ButtonState.Released && pad3.Buttons.X == ButtonState.Pressed)
                    {
                        xcount3++;
                    }
                    if (oldpad3.Buttons.Y == ButtonState.Released && pad3.Buttons.Y == ButtonState.Pressed)
                    {
                        ycount3++;
                    }
                    oldpad3 = pad3;
                }

                if (pad4.IsConnected)
                {
                    if (oldpad4.Buttons.A == ButtonState.Released && pad4.Buttons.A == ButtonState.Pressed)
                    {
                        acount4++;
                    }
                    if (oldpad4.Buttons.B == ButtonState.Released && pad4.Buttons.B == ButtonState.Pressed)
                    {
                        bcount4++;
                    }
                    if (oldpad4.Buttons.X == ButtonState.Released && pad4.Buttons.X == ButtonState.Pressed)
                    {
                        xcount4++;
                    }
                    if (oldpad4.Buttons.Y == ButtonState.Released && pad4.Buttons.Y == ButtonState.Pressed)
                    {
                        ycount4++;
                    }
                    oldpad4 = pad4;
                }
                
                timer++;

                if (time4 && timer == 240)
                {
                    time4 = false;
                    time10 = false;
                    gameOver = true;
                }
                else if (time10 && timer == 600)
                {
                    time10 = false;
                    time4 = false;
                    gameOver = true;
                }
            }

            



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            float wordHeight = font.MeasureString("WINNER").Y;
            float wordWidth = font.MeasureString("WINNER").X;

            spriteBatch.Begin();
            if (!time4 && !time10)
            {
                if(!gameOver) spriteBatch.DrawString(font2,"Press X for a 4 second game. B for 10 seconds" ,new Vector2(20,100), Color.Black);
                if (gameOver)
                {
                    GraphicsDevice.Clear(DeclareWinner());
                    spriteBatch.DrawString(font, "WINNER", new Vector2(320,200), Color.Black);
                }
            }

            if ((time4 || time10) && !gameOver)
            {
                if (pad1.IsConnected)
                {
                    spriteBatch.DrawString(font, acount.ToString(), apos, Color.Green);
                    spriteBatch.DrawString(font, bcount.ToString(), bpos, Color.Red);
                    spriteBatch.DrawString(font, xcount.ToString(), xpos, Color.Blue);
                    spriteBatch.DrawString(font, ycount.ToString(), ypos, Color.Yellow);
                }
                if (pad2.IsConnected)
                {
                    spriteBatch.DrawString(font, acount2.ToString(), apos2, Color.Green);
                    spriteBatch.DrawString(font, bcount2.ToString(), bpos2, Color.Red);
                    spriteBatch.DrawString(font, xcount2.ToString(), xpos2, Color.Blue);
                    spriteBatch.DrawString(font, ycount2.ToString(), ypos2, Color.Yellow);
                }
                if (pad3.IsConnected)
                {
                    spriteBatch.DrawString(font, acount3.ToString(), apos3, Color.Green);
                    spriteBatch.DrawString(font, bcount3.ToString(), bpos3, Color.Red);
                    spriteBatch.DrawString(font, xcount3.ToString(), xpos3, Color.Blue);
                    spriteBatch.DrawString(font, ycount3.ToString(), ypos3, Color.Yellow);
                }
                if (pad4.IsConnected)
                {
                    spriteBatch.DrawString(font, acount4.ToString(), apos4, Color.Green);
                    spriteBatch.DrawString(font, bcount4.ToString(), bpos4, Color.Red);
                    spriteBatch.DrawString(font, xcount4.ToString(), xpos4, Color.Blue);
                    spriteBatch.DrawString(font, ycount4.ToString(), ypos4, Color.Yellow);
                }
            }
            

            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        public Color DeclareWinner()
        {
            int yTotal = ycount + ycount2 + ycount3 + ycount4;
            int xTotal = xcount + xcount2 + xcount3 + xcount4;
            int aTotal = acount + acount2 + acount3 + acount4;
            int bTotal = bcount + bcount2 + bcount3 + bcount4;
            if (yTotal > xTotal && yTotal > aTotal && yTotal > bTotal)
            {
                return Color.Yellow;
            }
            else if (xTotal > aTotal && xTotal > bTotal)
            {
                return Color.Blue;
            }
            else if(aTotal > bTotal)
            {
                return Color.Green;
            }
            else
            {
                return Color.Red;
            }
        }
    }
}
