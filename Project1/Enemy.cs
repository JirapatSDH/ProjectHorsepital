using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Penumbra;
using Light = Penumbra.Light;
using System.Diagnostics;

namespace Project1
{
    internal class Enemy : Game1
    {
        Texture2D eneTexture;
        Vector2 enePos;
        Vector2 eneOrigin;
        Vector2 velocity;
        Vector2 ecamPos = Vector2.Zero;
        Vector2 escroll_factor = new Vector2(1.0f, 1);
        int eneframe;
        Vector2 playPos;
        float enerotate = 0f;
        public static bool isHit = false;

        bool right;
        float distance;
        float oldDistance;

        public Enemy (Texture2D neweneTexture, Vector2 newenePos, float newdistance)
        {
            eneTexture = neweneTexture;
            enePos = newenePos;
            distance = newdistance;
            enePos.Y -= 110;
            oldDistance = distance;
        }
        float playerDistance;
        public void Update(Vector2 newpos)
        {
            playPos = newpos;
            enePos += velocity;
            eneOrigin = Vector2.Zero;
            if (distance <= 0)
            {
                right = true;
                velocity.X = 1f;
            }
             else if (distance >= oldDistance)
            {
                right = false;
                velocity.X = -1f;
            }

            if (right) distance += 1; else distance -= 1;
            playerDistance = playPos.X - enePos.X;
            if (playerDistance >= -20 && playerDistance <= 20)
            {
                if (playerDistance < -1)
                    velocity.X = -1f;
                else if (playerDistance > 1)
                    velocity.X = 1f;
                else if (playerDistance == 0)
                    velocity.X = 0f;
            }
            Rectangle personRectangle = new Rectangle((int)playPos.X, (int)playPos.Y, 50, 120);
            Rectangle enemyRectangle = new Rectangle((int)enePos.X, (int)enePos.Y, 60, 100);
            if (personRectangle.Intersects(enemyRectangle) == true )
            {
                isHit = true;
                
            }
            else if (personRectangle.Intersects(enemyRectangle) == false)
            {
                isHit = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 newcampos,Vector2 newscroll,int neweframe)
        {
            ecamPos = newcampos;
            escroll_factor = newscroll;
            eneframe = neweframe % 2;
            if (velocity.X > 0)
                spriteBatch.Draw(eneTexture, enePos - ecamPos * escroll_factor, new Rectangle(120 * eneframe, 0, 120, 120), Color.White, enerotate, eneOrigin, 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(eneTexture, enePos - ecamPos * escroll_factor, new Rectangle(120 * eneframe, 0, 120, 120), Color.White, enerotate, eneOrigin, 1f, SpriteEffects.None, 0f);
        }
    }
}
