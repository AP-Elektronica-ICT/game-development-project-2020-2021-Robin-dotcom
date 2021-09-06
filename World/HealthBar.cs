using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.World
{
    public class HealthBar
    {
        public Vector2 Position;
        private int heigth;
        public Rectangle healthRectangle;
        public Texture2D texture;

        public HealthBar(Texture2D newTexture)
        {
            texture = newTexture;
            heigth = 20;
            Position = new Vector2(50, 20);
        }

        public void Update(Hero hero)
        {
            healthRectangle = new Rectangle((int)Position.X, (int)Position.Y, hero.Health, heigth);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, healthRectangle, Color.White);
        }
    }
}
