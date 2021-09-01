using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.World
{
    public class Enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public Animation animation;

        public List<Enemy> enemies = new List<Enemy>();

        private bool isVisible;

        public Enemy(Texture2D newTexture)
        {
            texture = newTexture;
            position = new Vector2(0, 375);
            velocity = new Vector2(2,0);
            isVisible = false;

            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(12, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(88, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(175, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(258, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(338, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(427, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(518, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(594, 254, 53, 88)));
            animation.AddFrame(new AnimationFrame(new Rectangle(670, 254, 53, 88)));
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.position += enemy.velocity;
                enemy.animation.Update(gameTime);

            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].isVisible)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Create()
        {
            Enemy newEnemy = new Enemy(texture);
            //newEnemy.position = new Vector2(spawn.position.X, spawn.position.Y);
            newEnemy.position = new Vector2(0, 375); 
            newEnemy.velocity = new Vector2(2, 0);
            newEnemy.isVisible = true;
            enemies.Add(newEnemy);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.None, 0);
        }

    }
}
