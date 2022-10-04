using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Penumbra;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Screen
    {
        protected EventHandler ScreenEvent;

        public Screen(EventHandler screenEvent)
        {
            ScreenEvent = screenEvent;
        }
        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch theBatch)
        {

        }
    }
}
