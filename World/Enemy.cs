using HerexamenGame.Commands;
using HerexamenGame.Content.Animation;
using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.World
{
    public class Enemy : ITransform
    {
        public Texture2D texture;
        //public Vector2 position;
        public Vector2 velocity;
        public Animation animation;

        public List<Enemy> enemies = new List<Enemy>();
        private IGameCommand moveCommand;

        private bool isVisible;

        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public int Health { get; set; }

        private Rectangle _collisionRectangle;

        public Enemy(Texture2D newTexture)
        {
            texture = newTexture;
            Position = new Vector2(0, 375);
            velocity = new Vector2(1,0);
            isVisible = false;
            Health = 100;

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

            moveCommand = new MoveCommand(new Vector2(2,0));
            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 54, 89);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Position += enemy.velocity;
                enemy.animation.Update(gameTime);
                enemy._collisionRectangle.X = (int)enemy.Position.X;
                enemy.CollisionRectangle = enemy._collisionRectangle;
                if (enemy.Health == 0)
                {
                    enemy.isVisible = false;
                }
                if (enemy.Position.X > 1600)
                {
                    enemy.isVisible = false;
                }
                

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
        private void MoveHorizontal(Vector2 direction)
        {
            moveCommand.Execute(this, direction);
        }


        public void Create()
        {
            Enemy newEnemy = new Enemy(texture);
            //newEnemy.position = new Vector2(spawn.position.X, spawn.position.Y);
            //newEnemy.Position = new Vector2(0, 375); 
            //newEnemy.velocity = new Vector2(2, 0);
            newEnemy.isVisible = true;
            //newEnemy._collisionRectangle = new Rectangle((int)newEnemy.Position.X, (int)newEnemy.Position.Y, 54, 89);
            enemies.Add(newEnemy);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.None, 0);
        }

    }
}
