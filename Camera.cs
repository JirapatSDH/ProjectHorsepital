using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public class Camera
    {
        //GraphicsDeviceManager _graphics;
        public Matrix transform;
        Viewport view;
        Vector2 centre;

        public Camera (Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime, Game1 player)
        {
            /*if(player.pos.X >= 360 || player.pos.X + player.farmer.Width <= _graphics.GraphicsDevice.Viewport.Width - 360)
            {
                centre = new Vector2(player.pos.X + (player.rec.Width / 2) - 350, 0);
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, 0, 0));
            }*/

            if (player.pos.X >= 360 && player.pos.X <= 1070)
            {
                centre = new Vector2(player.pos.X + (player.rec.Width / 2) - 350, 0);
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, 0, 0));
            }
        }
    }
}
