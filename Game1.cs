using HerexamenGame.Collision;
using HerexamenGame.Screens;
using HerexamenGame.Input;
using HerexamenGame.UI;
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

        //GameStates
        public enum GameState
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

        //Fonts
        public SpriteFont font;
        public SpriteFont titleFont;

        //Viewport
        public int screenWidth;
        public int screenHeight;

        //Variables
        public int score = 0;

        //Objects      
        public CollisionManager collisionManager;
        Background background;
        Hero hero;
        Bullet bullet;
        Enemy enemy;
        EnemySpawn spawn;        
        HealthBar healthBar;
        Button buttonPlay;
        Button buttonRespawn;

        //Tried to refactor gamestates
        //MainMenu mainMenu;
        //Respawn respawnMenu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("D:/AP/Semester3/GameDev/github/game-development-project-2020-2021-Robin-dotcom/Content/bin/Windows/font");
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
            
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {

            buttonPlay = new Button(textureButtonPlay, _graphics.GraphicsDevice);
            buttonPlay.setPosition(new Vector2((screenWidth / 2), (screenHeight / 2)));
            buttonRespawn = new Button(textureButtonRespawn, _graphics.GraphicsDevice);
            buttonRespawn.setPosition(new Vector2((screenWidth / 2), (screenHeight / 3)));
            background = new Background(textureBackground, screenWidth, screenHeight);
            bullet = new Bullet(textureBullet);
            hero = new Hero(textureSoldier1, new KeyBoardReader(), screenWidth, bullet);
            enemy = new Enemy(textureZombie1);
            spawn = new EnemySpawn(enemy);
            healthBar = new HealthBar(textureHealthBar);
            collisionManager = new CollisionManager(hero, enemy, bullet);
            ////Tried to refactor gamestates
            //mainMenu = new MainMenu(textureMainMenuBackground, buttonPlay, screenWidth, screenHeight);
            //respawnMenu = new Respawn(textureDeadBackground, buttonPlay, screenWidth, screenHeight, font, score);

        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
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
                    //Didn't manage to refactor two foreach loops, errors keep comming when declaring objects 
                    //in wrong order in InitialzeGameObject() method
                    foreach (Enemy enemy in enemy.enemies)
                    {
                        if (collisionManager.CheckCollision(hero.CollisionRectangle, enemy.CollisionRectangle))
                        {
                            if (enemy.velocity.X == -1)
                            {
                                enemy.Position = new Vector2((int)hero.Position.X + hero.CollisionRectangle.Width / 2, (int)hero.Position.Y);
                            }
                            else
                            {      
                                enemy.Position = new Vector2 ((int)hero.Position.X - hero.CollisionRectangle.Width/2, (int)hero.Position.Y);
                            }
                            hero.Health -= 1;
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
                            enemy.enemies[0].Health -= 25;
                            score++;
                            bullet.isVisible = false;
                            Debug.WriteLine("test");
                        }                        
                    }
                    healthBar.Update(hero);
                    if (hero.Health < 0)
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

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(textureMainMenuBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White );
                    _spriteBatch.DrawString(font, "Zombie Shooter", new Vector2(100, 100), Color.Red, 0, Vector2.Zero, 5f, SpriteEffects.None, 0);  ;
                    buttonPlay.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
                case GameState.Paused:
                    break;
                case GameState.Respawn:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(textureDeadBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    _spriteBatch.DrawString(font, "You killed " + score/4 + " zombies. Well Done!", new Vector2(300, 300), Color.Red);
                    buttonRespawn.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
                case GameState.Playing:
                    _spriteBatch.Begin();
                    background.Draw(_spriteBatch);
                    bullet.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);                    
                    hero.Draw(_spriteBatch);
                    healthBar.Draw(_spriteBatch);
                    _spriteBatch.DrawString(font, "Kills: " + score/4, new Vector2(700, 10), Color.Red);
                    _spriteBatch.End();
                    break;
                default:
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
