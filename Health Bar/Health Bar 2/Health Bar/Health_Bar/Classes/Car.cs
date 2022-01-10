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
    class Car
    {
        //Declare all private variables
        private Rectangle rec;
        private Texture2D tex;
        private Color clr;
        private int dir;
        private ContentManager contentManager;
        private int gear = 2;
        // Delcare all texture variables
        Texture2D down;
        Texture2D up;
        Texture2D right;
        Texture2D left;

        // create constructor
        public Car(Rectangle aRec, Texture2D aTex, Color aClr, int aDir, ContentManager aCm)
        {
            SetRec(aRec);
            SetTex(aTex);
            SetClr(aClr);
            SetDir(aDir);
            SetContent(aCm);
            loadImages();
        }
        // create accesors and mutators for all private variables
        public void SetRec(Rectangle aRec)
        {
            rec = aRec;
        }
        public void SetTex(Texture2D aTex)
        {
            tex = aTex;
        }
        public void SetClr(Color aClr)
        {
            clr = aClr;
        }
        public void SetDir(int aDir)
        {
            dir = aDir;
        }
        public void SetContent(ContentManager aCm)
        {
            contentManager = aCm;
        }

        public Rectangle GetRec()
        {
            return rec;
        }
        public Texture2D GetTex()
        {
            return tex;
        }
        public Color GetClr()
        {
            return clr;
        }
        public int GetDir()
        {
            return dir;
        }
        public ContentManager GetCm()
        {
            return contentManager;
        }
        // move it methoed for player
        public void MoveIt(GamePadState gps, KeyboardState kb)
        {
            // Gets multiplied by 10 because thumbstick and trigger are both values between 0 and 1. When converted to int, all digits after decimal are ignored.
            rec.X += Convert.ToInt32(gps.ThumbSticks.Left.X * gps.Triggers.Right * 10);
            rec.Y -= Convert.ToInt32(gps.ThumbSticks.Left.Y * gps.Triggers.Right * 10);

            if (dir == 1 && kb.IsKeyDown(Keys.W))
            {
                rec.Y -= gear;
            }
            else if (dir == 2 && kb.IsKeyDown(Keys.A))
            {
                rec.X -= gear;
            }
            else if (dir == 3 && kb.IsKeyDown(Keys.S))
            {
                rec.Y += gear;
            }
            else if (dir == 4 && kb.IsKeyDown(Keys.D))
            {
                rec.X += gear;
            }
        }
        public void DrawIt(SpriteBatch spr)
        {
            spr.Draw(tex, rec, clr);
        }
        // turning method
        public void turn(GamePadState gps, KeyboardState kb)
        {
            if (gps.ThumbSticks.Left.X > 0 || kb.IsKeyDown(Keys.D))
            {
                dir = 4;
            }
            else if (gps.ThumbSticks.Left.X < 0 || kb.IsKeyDown(Keys.A))
            {
                dir = 2;
            }

            if ((gps.ThumbSticks.Left.Y > 0 && gps.ThumbSticks.Left.X == 0) || kb.IsKeyDown(Keys.W) && (kb.IsKeyUp(Keys.A) || kb.IsKeyUp(Keys.D)))
            {
                dir = 1;
            }
            else if (gps.ThumbSticks.Left.Y < 0 && gps.ThumbSticks.Left.X == 0 || kb.IsKeyDown(Keys.S) && (kb.IsKeyUp(Keys.A) || kb.IsKeyUp(Keys.D)))
            {
                dir = 3;
            }
            if (GetDir() == 1)
            {
                SetTex(up);
            }
            else if (GetDir() == 2)
            {
                SetTex(left);
            }
            else if (GetDir() == 3)
            {
                SetTex(down);
            }
            else if (GetDir() == 4)
            {
                SetTex(right);
            }
        }
        // changing gears with keyboard method
        public void ChangeGears(KeyboardState kb)
        {
            if (kb.IsKeyDown(Keys.F1))
            {
                gear = 5;
            }
            else if (kb.IsKeyDown(Keys.F2))
            {
                gear = 10;
            }
            else if (kb.IsKeyDown(Keys.F3))
            {
                gear = 15;
            }
            else if (kb.IsKeyDown(Keys.F4))
            {
                gear = 20;
            }
            else if (kb.IsKeyDown(Keys.F5))
            {
                gear = 25;
            }
        }
        // loading different images method
        public void loadImages()
        {
            down = contentManager.Load<Texture2D>("Raul Down");
            up = contentManager.Load<Texture2D>("Raul 1Up");
            right = contentManager.Load<Texture2D>("Raul Right");
            left = contentManager.Load<Texture2D>("Raul Left");
        }
        // Collison testing with medicine bottles
        public bool IsColliding(Rectangle aRec)
        {
            if ((rec.Right > aRec.Left && rec.Right < aRec.Right) || (rec.Left < aRec.Right && rec.Left > aRec.Left) || (rec.Bottom > aRec.Top && rec.Bottom < aRec.Bottom) || (rec.Top < aRec.Bottom && rec.Top > aRec.Top))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
