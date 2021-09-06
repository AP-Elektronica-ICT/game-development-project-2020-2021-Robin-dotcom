using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Input
{
    public class KeyBoardReader : IInputReader
    {

        public KeyboardState lastKey;
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
                lastKey = Keyboard.GetState();
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
                lastKey = Keyboard.GetState();
            }
            return direction;
        }

        public KeyboardState LastKey()
        {
            return lastKey;
        }
        
    }
}
