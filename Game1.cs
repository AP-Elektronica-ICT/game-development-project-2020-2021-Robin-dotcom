using HerexamenGame.Collision;
using HerexamenGame.Input;
using HerexamenGame.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace HerexamenGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Textures
        public Texture2D textureBackground;
        public Texture2D textureSoldier1;
        public Texture2D textureSoldier2;
        public Texture2D textureSoldier3;
        public Texture2D textureSoldier4;
        public Texture2D textureSoldier5;
        public Texture2D textureBullet;
        public Texture2D textureZombie1;
        public Texture2D textureHealthBar;

        //Viewport
        public int screenWidth;
        public int screenHeight;

        //Objects
        Background background;
        Hero hero;
        Bullet bullet;
        Enemy enemy;
        EnemySpawn spawn;
        CollisionManager collisionManager;
        HealthBar healthBar;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textureBackground = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/forestbackground");
            textureSoldier1 = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/soldier1");
            textureSoldier2 = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/soldier2");
            textureSoldier3 = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/soldier3");
            textureSoldier4 = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/soldier4");
            textureSoldier5 = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/soldier5");
            textureBullet = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/HerexamenGame/Content/bin/Windows/bullet");
            textureZombie1 = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/zombie1");
            textureHealthBar = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/healthBar2");

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            //Size = new Rectangle(0,0, (int)(textureBackground.Width * Scale)
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            //var keuze = Menu.GetMenu();

            background = new Background(textureBackground, screenWidth, screenHeight);
            bullet = new Bullet(textureBullet);
            hero = new Hero(textureSoldier1, new KeyBoardReader(), screenWidth, bullet);
            enemy = new Enemy(textureZombie1);
            spawn = new EnemySpawn(enemy);
            healthBar = new HealthBar(textureHealthBar);
            //startUpMenu = new StartUpMenu(textureButton, new Vector2((GraphicsDevice.Viewport.Width / 2) - 50, 200));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            background.Update(hero);
            
            hero.Update(gameTime);
            spawn.Update(gameTime);
            foreach (Enemy enemy in enemy.enemies)
            {
                if (collisionManager.CheckCollision(hero.CollisionRectangle, enemy.CollisionRectangle))
                {
                    hero.Health -= 5;
                }
            }

            healthBar.Update(hero);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            background.Draw(_spriteBatch);
            foreach (Bullet bullet in bullet.bullets)
            {
                bullet.Draw(_spriteBatch);
            }
            foreach (Enemy enemy in enemy.enemies)
            {
                enemy.Draw(_spriteBatch);
            }
            hero.Draw(_spriteBatch);
            healthBar.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
