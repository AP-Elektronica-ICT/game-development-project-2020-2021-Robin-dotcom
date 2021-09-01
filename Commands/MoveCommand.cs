using HerexamenGame.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Commands
{
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;

        public MoveCommand()
        {
            speed = new Vector2(5, 5);
        }

        public void Execute(ITransform transform, Vector2 direction)
        {
            if (transform.Position.X >= 0 && transform.Position.X <= 800)
            {
                direction *= speed;
                transform.Position += direction;

            }
            
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
