using System;
using System.Collections.Generic;
using System.Text;
using HerexamenGame.UI;
using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HerexamenGame.Screens
{
    public class Respawn : IGameState
    {

        Button buttonRespawn;
        MouseState mouse = Mouse.GetState();        
        public Texture2D texture;
        private int screenWidth;
        private int screenHeight;
        private SpriteFont font;
        private int score;

        public Respawn(Texture2D newTexture, Button newbutton, int newscreenWidth, int newscreenHeight, SpriteFont newfont, int newscore)
        {
            texture = newTexture;
            buttonRespawn = newbutton;
            screenWidth = newscreenWidth;
            screenHeight = newscreenHeight;
            font = newfont;
            score = newscore;
        }
        public void Update()
        {
            if (buttonRespawn.isClicked)
            {
                //CurrentGameState = "MainMenu";
            }
            buttonRespawn.Update(mouse);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            _spriteBatch.DrawString(font, "You killed " + score / 4 + " zombies. Well Done!", new Vector2(300, 300), Color.Red);
            buttonRespawn.Draw(_spriteBatch);
            _spriteBatch.End();

        }
    }
}
