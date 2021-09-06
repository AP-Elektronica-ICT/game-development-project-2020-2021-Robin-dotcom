using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HerexamenGame.World
{
    public class EnemySpawn
    {
        public Random random = new Random();
        private int difficulty = 10;
        private int enemiesloaded = 0;

        //public List<Enemy> enemies = new List<Enemy>();
        private Enemy enemyToLoad;

        public EnemySpawn(Enemy enemy)
        {
            enemyToLoad = enemy;                        
        }
        public void LoadEnemies(GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalSeconds%1 < 0.1)          
            {
                enemyToLoad.Create();
                enemiesloaded++;
                if (enemiesloaded%10==0)
                {
                    difficulty += 5;
                }
            }            
        }

        public void Update(GameTime gameTime)
        {
            int r = random.Next(100);
            if (r <= difficulty)
            {
                LoadEnemies(gameTime);
            }
            
            enemyToLoad.Update(gameTime);            
        }

        
    }
}
