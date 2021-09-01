using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.World
{
    public class Background
    {
        public Texture2D _texture { get; set; }
        public Rectangle Size;
        public Vector2 Position = Vector2.Zero;
        public Vector2 LeftBackup = new Vector2(-800, 0);
        public Vector2 RightBackup = new Vector2(800,0);

        public int screenWidth;
        public int screenHeight;

        public float Scale = 1.0f;

        int frameMovement = 5;
        public Background(Texture2D texture, int width, int height)
        {
            _texture = texture;
            screenHeight = height;
            screenWidth = width;
        }

        public void Update(Hero hero)
        {
            if (hero.Position.X + hero.animation.CurrentFrame.SourceRectangle.Width >= screenWidth && RightBackup.X != 0)
            {
                Position.X -= frameMovement;
                RightBackup.X -= frameMovement;
                LeftBackup.X -= frameMovement;
            }
            if (hero.Position.X == 0 && LeftBackup.X != 0)
            {
                Position.X += frameMovement;
                RightBackup.X += frameMovement;
                LeftBackup.X += frameMovement;
            }
            //if (LeftBackup.X == 0)
            //{
            //    LeftBackup = Vector2.Zero;
            //}
            //if (RightBackup.X == 0)
            //{
            //    RightBackup = Vector2.Zero;
            //}
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
            spriteBatch.Draw(_texture, LeftBackup, Color.White);
            spriteBatch.Draw(_texture, RightBackup, Color.White);

        }
    }
}
