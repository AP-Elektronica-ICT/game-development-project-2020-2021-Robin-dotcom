using HerexamenGame.Collision;
using HerexamenGame.Input;
using HerexamenGame.Visuals;
using HerexamenGame.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HerexamenGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum GameState
        {
            MainMenu,
            Paused,
            Playing,
            Respawn,
        }
        GameState CurrentGameState = GameState.MainMenu;
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
        public Texture2D textureMainMenuBackground;
        public Texture2D textureButtonPlay;
        public Texture2D textureDeadBackground;
        public Texture2D textureButtonRespawn;
        //public Texture2D textureButtonResume;
        //public Texture2D textureButtonQuit;
        //public Texture2D texturePausedBackground;

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
        Button buttonPlay;
        Button buttonRespawn;
        //Button buttonResume;
        //Button buttonQuit;
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
            textureButtonPlay = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/playbutton");
            textureMainMenuBackground = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/MainMenuBackGround");
            textureDeadBackground = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/DiedScreen");
            textureButtonRespawn = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/RestartButton");
            //textureButtonQuit = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/RestartButton");
            //textureButtonResume = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/RestartButton");
            //texturePausedBackground = Content.Load<Texture2D>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/RestartButton");

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            //Size = new Rectangle(0,0, (int)(textureBackground.Width * Scale)
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            //var keuze = Menu.GetMenu();

            buttonPlay = new Button(textureButtonPlay, _graphics.GraphicsDevice);
            buttonPlay.setPosition(new Vector2((screenWidth / 2), (screenHeight / 3)));
            buttonRespawn = new Button(textureButtonRespawn, _graphics.GraphicsDevice);
            buttonRespawn.setPosition(new Vector2((screenWidth / 2), (screenHeight / 3)));
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
            MouseState mouse = Mouse.GetState();

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (buttonPlay.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                        
                    }
                    buttonPlay.Update(mouse);
                    break;
                case GameState.Paused:
                    break;
                case GameState.Respawn:
                    if (buttonRespawn.isClicked == true)
                    {
                        CurrentGameState = GameState.MainMenu;
                    }
                    break;
                case GameState.Playing:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        CurrentGameState = GameState.Paused;
                    }
                    background.Update(hero);

                    hero.Update(gameTime);
                    spawn.Update(gameTime);
                    foreach (Enemy enemy in enemy.enemies)
                    {
                        if (collisionManager.CheckCollision(hero.CollisionRectangle, enemy.CollisionRectangle))
                        {
                            enemy.Position = new Vector2 ((int)hero.Position.X - hero.CollisionRectangle.Width/2, (int)hero.Position.Y);
                            hero.Health -= 5;
                            collisionManager.hit = true;
                        }
                        if (collisionManager.hit)
                        {
                            enemy.Position = new Vector2(enemy.Position.X - 10, enemy.Position.Y);
                            collisionManager.hit = false;

                        }

                    }
                    foreach (Bullet bullet in bullet.bullets)
                    {
                        if (enemy.enemies.Count() > 0 && collisionManager.CheckCollision(bullet.CollisionRectangle, enemy.enemies.First().CollisionRectangle))
                        {
                            enemy.enemies[0].Health = 0;
                            bullet.bullets.Remove(bullet);
                            Debug.WriteLine("test");
                        }
                        if (collisionManager.CheckCollision(bullet.CollisionRectangle, hero.CollisionRectangle))
                        {
                            Debug.WriteLine("Hero hit");
                        }
                        //Debug.WriteLine(bullet.Position);
                    }

                    healthBar.Update(hero);
                    if (hero.Health == 0)
                    {
                        CurrentGameState = GameState.Respawn;
                    }

                    break;
                default:
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(textureMainMenuBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White );
                    buttonPlay.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
                case GameState.Paused:
                    break;
                case GameState.Respawn:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(textureDeadBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    buttonRespawn.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
                case GameState.Playing:
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
                    break;
                default:
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
