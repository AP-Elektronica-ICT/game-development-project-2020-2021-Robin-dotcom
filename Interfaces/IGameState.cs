using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Interfaces
{
    public interface IGameState
    {
        public void Update();
        public void Draw(SpriteBatch sprite);
    }
}
