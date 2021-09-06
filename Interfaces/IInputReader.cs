using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Interfaces
{
    public interface IInputReader
    {
     
        Vector2 ReadInput();

        KeyboardState LastKey();
    }
}
