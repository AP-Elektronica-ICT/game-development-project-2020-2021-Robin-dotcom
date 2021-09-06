using System;
using System.Collections.Generic;
using System.Text;
using HerexamenGame.Interfaces;
using HerexamenGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HerexamenGame.GameStates
{
    
    public class MainMenu : IGameState
    {
        //enum GameStates
        //{
        //    MainMenu,
        //    Paused,
        //    Playing,
        //    Respawn,
        //}
        Button buttonPlay;
        MouseState mouse = Mouse.GetState();        
        public Texture2D texture;
        private int screenWidth;
        private int screenHeight;

        public MainMenu(Texture2D newTexture, Button newbutton, int newscreenWidth, int newscreenHeight)
        {
            texture = newTexture;
            buttonPlay = newbutton;
            screenWidth = newscreenWidth;
            screenHeight = newscreenHeight;
        }
        public void Update()
        {
            if (buttonPlay.isClicked)
            {
                //return GameStates.Playing;
            }
            
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(texture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            buttonPlay.Draw(sprite);
            sprite.End();
        }

        
    }
}
