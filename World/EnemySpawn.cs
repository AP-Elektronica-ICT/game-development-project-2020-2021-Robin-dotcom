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
        private double timeSeconds;
       

        public List<Enemy> enemies = new List<Enemy>();
        Enemy enemyToLoad;

        public EnemySpawn(Enemy enemy)
        {
            enemyToLoad = enemy;
            position = new Vector2(-800, 370);
            
        }
        public void LoadEnemies(GameTime gameTime)
        {
            
            if (gameTime.ElapsedGameTime.TotalSeconds > timeSeconds)
            {
                enemies.Add(new Enemy(enemyToLoad.texture));
                timeSeconds++;
            }
            
        }

        public void Update(GameTime gameTime)
        {
            LoadEnemies(gameTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }
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
