using HerexamenGame.Commands;
using HerexamenGame.Content.Animation;
using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame
{
    public class Hero : ITransform
    {
        public Vector2 Position { get; set; }
        private Texture2D heroTexture;
        public Animation animation;
        private int screenWidth;
        private int spawnX = 360;
        private int spawnY = 370;
        private Bullet Bullet;

        public IInputReader inputReader;
        private IGameCommand moveCommand;
        private Rectangle idleFrame;

        public Hero(Texture2D texture, IInputReader reader, int width, Bullet bullet)
        {
            heroTexture = texture;
            Position = new Vector2(spawnX, spawnY);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(18, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(128, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(239, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(350, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(456, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(562, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(669, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(777, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(886, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(998, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1100, 483, 79, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1213, 483, 79, 96)));

            inputReader = reader;
            moveCommand = new MoveCommand();
            idleFrame = new Rectangle(22, 123, 73, 101);
            screenWidth = width;
            Bullet = bullet;
        }

        public void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Bullet.Shoot(this);
                Bullet.Update(this);

            }



            var direction = inputReader.ReadInput();

            MoveHorizontal(direction);

            if (Position.X <= 0)
            {
                Position = new Vector2(0, spawnY); 
            }
            if (Position.X + animation.CurrentFrame.SourceRectangle.Width >= screenWidth)
            {
                Position = new Vector2(screenWidth - animation.CurrentFrame.SourceRectangle.Width, spawnY);
            }
            if (Position.Y < spawnY || Position.Y > spawnY)
            {
                Position = new Vector2(Position.X, spawnY);
            }
            
            animation.Update(gametime);
        }

        private void MoveHorizontal(Vector2 direction)
        {
            moveCommand.Execute(this, direction);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (inputReader.ReadInput() == new Vector2(-1, 0))
            {
                spriteBatch.Draw(heroTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.One, 1, SpriteEffects.FlipHorizontally, 0f);
            }
            else if (inputReader.ReadInput() == new Vector2(1, 0))
            {
                spriteBatch.Draw(heroTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White);

            }
            else if (inputReader.LastKey().IsKeyUp(Keys.Left))
            {
                spriteBatch.Draw(heroTexture, Position, idleFrame, Color.White);
            }
            else if(inputReader.LastKey().IsKeyUp(Keys.Right))
            {
                spriteBatch.Draw(heroTexture, Position, idleFrame, Color.White, 0f, Vector2.One, 1, SpriteEffects.FlipHorizontally, 0f);
            }
        }
    }
}
