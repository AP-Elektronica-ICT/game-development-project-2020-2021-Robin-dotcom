using HerexamenGame.AnimationTypes;
using HerexamenGame.Commands;
using HerexamenGame.Content.Animation;
using HerexamenGame.Interfaces;
using HerexamenGame.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HerexamenGame
{
    public class Hero : ITransform
    {
        //Properties
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public int Health { get; set; }

        public WalkingHeroAnimation walkingHeroAnimation;
        public Vector2 direction;        
        public IInputReader inputReader;

        private Texture2D heroTexture;
        private Rectangle _collisionRectangle;
        private int screenWidth;
        private int spawnX = 360;
        private int spawnY = 370;
        private IGameCommand moveCommand;
        private Rectangle idleFrame;
        private KeyboardState pastKey;
        private Bullet Bullet;   
        
        public Hero(Texture2D texture, IInputReader reader, int width, Bullet bullet)
        {
            heroTexture = texture;
            Position = new Vector2(spawnX, spawnY);
            Health = 100;
            direction = new Vector2(0,0);
            walkingHeroAnimation = new WalkingHeroAnimation();
            inputReader = reader;
            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 80, 97);
            moveCommand = new MoveCommand(new Vector2(5,0));
            idleFrame = new Rectangle(22, 123, 73, 101);
            screenWidth = width;
            Bullet = bullet;
        }

        public void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && pastKey.IsKeyUp(Keys.Space))
            {
                Bullet.Shoot(this);                
            }
            pastKey = Keyboard.GetState();
            Bullet.Update(this);

            direction = inputReader.ReadInput();
            MoveHorizontal(direction);
            _collisionRectangle.X = (int)Position.X;
            CollisionRectangle = _collisionRectangle;
            //Don't exceed window
            CheckPosition();
            walkingHeroAnimation.Animation.Update(gametime);
            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            //WalkiningAnimation drawn mirrored when walking other way
            if (inputReader.ReadInput() == new Vector2(-1, 0))
            {
                spriteBatch.Draw(heroTexture, Position, walkingHeroAnimation.Animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.FlipHorizontally, 0f);
            }
            else if (inputReader.ReadInput() == new Vector2(1, 0))
            {
                spriteBatch.Draw(heroTexture, Position, walkingHeroAnimation.Animation.CurrentFrame.SourceRectangle, Color.White);

            }
            //IdleFrame drawn mirrored when looking other way
            else if (inputReader.LastKey().IsKeyUp(Keys.Left))
            {
                spriteBatch.Draw(heroTexture, Position, idleFrame, Color.White);
            }
            else if(inputReader.LastKey().IsKeyUp(Keys.Right))
            {
                spriteBatch.Draw(heroTexture, Position, idleFrame, Color.White, 0f, Vector2.One, 1, SpriteEffects.FlipHorizontally, 0f);
            }
        }

        private void CheckPosition()
        {
            if (Position.X <= 100)
            {
                Position = new Vector2(100, spawnY);
            }
            if (Position.X + walkingHeroAnimation.Animation.CurrentFrame.SourceRectangle.Width >= screenWidth - 100)
            {
                Position = new Vector2(screenWidth - walkingHeroAnimation.Animation.CurrentFrame.SourceRectangle.Width - 100, spawnY);
            }
            if (Position.Y < spawnY || Position.Y > spawnY)
            {
                Position = new Vector2(Position.X, spawnY);
            }
        }
        private void MoveHorizontal(Vector2 direction)
        {
            moveCommand.Execute(this, direction);
        }
    }
}
