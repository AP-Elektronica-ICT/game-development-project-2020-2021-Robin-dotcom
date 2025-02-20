﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Interfaces
{
    public interface ITransform
    {
        Vector2 Position { get; set; }
        Rectangle CollisionRectangle { get; set; }
        public int Health { get; set; }
    }
}
