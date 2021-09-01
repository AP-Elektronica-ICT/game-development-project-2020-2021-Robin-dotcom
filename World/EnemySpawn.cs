using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.World
{
    public class EnemySpawn
    {
        
        public Vector2 position;
        private double timeSeconds;
        public Random random = new Random();


        //public List<Enemy> enemies = new List<Enemy>();
        private Enemy enemyToLoad;

        public EnemySpawn(Enemy enemy)
        {
            enemyToLoad = enemy;
            position = new Vector2(-800, 370);
            
        }
        public void LoadEnemies(GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalSeconds%1 < 0.01)
          
            {
                enemyToLoad.Create();
                timeSeconds++;
            }
            
        }

        public void Update(GameTime gameTime)
        {
            int r = random.Next(100);
            if (r <= 10)
            {
                LoadEnemies(gameTime);
            }
            enemyToLoad.Update(gameTime);            
        }

        
    }
}
