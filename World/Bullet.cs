using HerexamenGame.Commands;
using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HerexamenGame
{
    public class Bullet : ITransform
    {
         Texture2D texture;

        
        public Vector2 direction;
        public Vector2 origin;
        public Vector2 velocity;
        public List<Bullet> bullets = new List<Bullet>();
        private Rectangle bulletSize;
        private IGameCommand moveCommand;
        public IInputReader inputReader;


        public bool isVisible;

        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public int Health { get; set; }

        private Rectangle _collisionRectangle;

        public Bullet(Texture2D newTexture)
        {
            texture = newTexture;
            moveCommand = new MoveCommand(new Vector2(20,0));
            isVisible = false;
            bulletSize = new Rectangle(65, 156, 273, 91);
            _collisionRectangle = new Rectangle((int)Position.X, 426, 10, 10);
        }

        public void Update(Hero hero)
        {
            foreach (Bullet bullet in bullets)
            {

                //MoveHorizontal(bullet.direction); ;
                if (hero.inputReader.LastKey().IsKeyUp(Keys.Left) && bullet.Position.X < 800)
                {
                    bullet.Position += bullet.velocity;

                }
                else if (hero.inputReader.LastKey().IsKeyUp(Keys.Right) && bullet.Position.X < 800)
                {
                    bullet.Position -= bullet.velocity;

                }
                if (Vector2.Distance(bullet.Position, hero.Position) > 800)
                {
                    bullet.isVisible = false;
                }
                bullet._collisionRectangle.X = (int)bullet.Position.X;
                bullet.CollisionRectangle = bullet._collisionRectangle;

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
        private void MoveHorizontal(Vector2 direction)
        {
            moveCommand.Execute(this, direction);
        }

        public void Shoot(Hero hero)
        {
            Bullet newBullet = new Bullet(texture);
            if (hero.inputReader.LastKey().IsKeyUp(Keys.Left))
            {
                newBullet.direction = new Vector2(-1, 0);
            }
            else 
            { 
                newBullet.direction = new Vector2(1, 0);
            }
            newBullet.velocity = new Vector2(20, 0);
            newBullet.Position = new Vector2(hero.Position.X, hero.Position.Y+(hero.animation.CurrentFrame.SourceRectangle.Height-30));
            newBullet.isVisible = true;

            if (bullets.Count() < 20)
            {
               bullets.Add(newBullet);
            }
        }

        public void Draw(SpriteBatch sprite)
        {            
            sprite.Draw(texture, Position, bulletSize, Color.White, 0f, origin, 0.1f, SpriteEffects.None, 0 );            
        }

    }
}
