using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerexamenGame
{
    public class Bullet
    {
         Texture2D texture;

        public Vector2 position;
        public Vector2 velocity;
        public Vector2 origin;
        public List<Bullet> bullets = new List<Bullet>();
        private Rectangle bulletSize;

        bool isVisible;

        public Bullet(Texture2D newTexture)
        {
            texture = newTexture;
            isVisible = false;
            bulletSize = new Rectangle(65, 156, 273, 91);
        }

        public void Update(Hero hero)
        {
            foreach (Bullet bullet in bullets)
            {
                if (hero.inputReader.LastKey().IsKeyUp(Keys.Left))
                {
                    bullet.position += bullet.velocity;

                }
                else if (hero.inputReader.LastKey().IsKeyUp(Keys.Right))
                {
                    bullet.position -= bullet.velocity;

                }

                    if (Vector2.Distance(bullet.position, hero.Position) > 800)
                {
                    bullet.isVisible = false;
                }
            }
            
            for (int i = 0; i < bullets.Count; i++)
			    {
                    if (!bullets[i].isVisible)
                    {
                        bullets.RemoveAt(i);
                        i--;
                    }
                }
        }
        
        public void Shoot(Hero hero)
        {
            Bullet newBullet = new Bullet(texture);
            newBullet.velocity = new Vector2(20,0);
            newBullet.position = new Vector2(hero.Position.X, hero.Position.Y+(hero.animation.CurrentFrame.SourceRectangle.Height-30));
            newBullet.isVisible = true;

            if (bullets.Count() < 20)
            {
                bullets.Add(newBullet);
            }

        }

        public void Draw(SpriteBatch sprite)
        {
            
                sprite.Draw(texture, position, bulletSize, Color.White, 0f, origin, 0.1f, SpriteEffects.None, 0 );
            
        }

    }
}
