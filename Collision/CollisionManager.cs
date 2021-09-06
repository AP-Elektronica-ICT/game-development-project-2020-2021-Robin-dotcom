using HerexamenGame.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.Collision
{
    public class CollisionManager
    {
        private Hero hero;
        private Enemy enemy;
        private Bullet bullet;
        public CollisionManager(Hero newHero, Enemy newEnemy, Bullet newBullet)
        {
            hero = newHero;
            enemy = newEnemy;
            bullet = newBullet;
        }
        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
            {
                return true;
            }
            return false;
        }

        public bool hit = false;
    }
}
