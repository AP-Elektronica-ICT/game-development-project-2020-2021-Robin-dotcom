using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Commands
{
    class ShootCommand : IGameCommand
    {
        public Vector2 speed;
        public ShootCommand()
        {
            speed = new Vector2(10, 0);
        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
