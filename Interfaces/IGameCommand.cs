using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Interfaces
{
    public interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction);

        void Undo();

    }
}
