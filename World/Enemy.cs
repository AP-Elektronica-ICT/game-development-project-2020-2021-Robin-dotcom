using HerexamenGame.AnimationTypes;
using HerexamenGame.Commands;
using HerexamenGame.Content.Animation;
using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HerexamenGame.World
{
    public class Enemy : ITransform
    {
        public Texture2D texture;
        //public Vector2 position;
        public Vector2 velocity;
        private WalkingZombieAnimation walkingZombieAnimation;
        private DeathZombieAnimation deathZombieAnimation; 
        Random r = new Random();
        public List<Enemy> enemies = new List<Enemy>();
        private IGameCommand moveCommand;

        private bool isVisible;
        private bool death;

        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public int Health { get; set; }

        private Rectangle _collisionRectangle;

        public Enemy(Texture2D newTexture)
        {
            texture = newTexture;
            //Position = new Vector2(0, 375);
            //velocity = new Vector2(1,0);
            isVisible = false;
            Health = 100;

            deathZombieAnimation = new DeathZombieAnimation();
            walkingZombieAnimation = new WalkingZombieAnimation();
            

            moveCommand = new MoveCommand(new Vector2(1,0));
            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 54, 89);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Position += enemy.velocity;
                enemy.walkingZombieAnimation.Animation.Update(gameTime);
                enemy.deathZombieAnimation.Animation.Update(gameTime);
                enemy._collisionRectangle.X = (int)enemy.Position.X;
                enemy.CollisionRectangle = enemy._collisionRectangle;
                if (enemy.Health == 0)
                {
                    enemy.isVisible=false;                    
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
            
            newEnemy.Position = new Vector2(-400, 370);
            newEnemy.velocity = new Vector2(1, 0);
            //}
            //else
            //{
            //    newEnemy.Position = new Vector2(1600, 370);
            //    newEnemy.velocity = new Vector2(-1, 0);
            //}
            //newEnemy.Position = new Vector2(0, 375); 
            //newEnemy.Position = new Vector2(0, 375); 
            newEnemy.isVisible = true;
            newEnemy._collisionRectangle = new Rectangle((int)newEnemy.Position.X, (int)newEnemy.Position.Y, 54, 89);
            enemies.Add(newEnemy);
        }

        public void Draw(SpriteBatch sprite)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.velocity.X == -1)
                {
                    sprite.Draw(texture, enemy.Position, enemy.walkingZombieAnimation.Animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.FlipHorizontally, 0);
                }
                else if (enemy.death)
                {
                    sprite.Draw(texture, enemy.Position, enemy.deathZombieAnimation.Animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.None, 0);
                }
                else
                {
                    sprite.Draw(texture, enemy.Position, enemy.walkingZombieAnimation.Animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.None, 0);
                }
            }
            
            

            //if (mirrored)
            //{
                
            //}
            //else
            //{
            //    sprite.Draw(texture, Position, walkingZombieAnimation.Animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.None, 0);
            //}
        }

    }
}
