using HerexamenGame.Content.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerexamenGame.World
{
    public class EnemySpawn
    {
        
        public Vector2 position;
        private double timeSeconds=-1;
       

        //public List<Enemy> enemies = new List<Enemy>();
        Enemy enemyToLoad;

        public EnemySpawn(Enemy enemy)
        {
            enemyToLoad = enemy;
            position = new Vector2(-800, 370);
            
        }
        public void LoadEnemies(GameTime gameTime)
        {
            
            if ((float)gameTime.ElapsedGameTime.TotalSeconds == timeSeconds +1)
            {
                enemyToLoad.Create(enemyToLoad);
                timeSeconds++;
            }
            
        }

        public void Update(GameTime gameTime)
        {
            LoadEnemies(gameTime);
            enemyToLoad.Update(gameTime);
            
        }

        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    foreach (Enemy enemy in enemies)
        //    {
        //        enemy.Draw(spriteBatch);
        //    }
        //}
    }
}
