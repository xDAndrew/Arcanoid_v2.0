using System.Collections.Generic;
using Arcanoid.Context;
using Arcanoid.Context.ContextModels;
using Arcanoid.GameObjects;
using Arcanoid.GameObjects.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Arcanoid
{
    class Program
    {
        static void Main(string[] args)
        {
            bool closeApp = true;

            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Arcanoid");
            window.SetVerticalSyncEnabled(true);

            window.Closed += (o, e) =>
            {
                window.Close();
                closeApp = !closeApp;
            };

            var texture = new Texture(@".\Textures\breakout_sprites.png");
            var ballSprite = new Sprite(texture, new IntRect(160, 200, 16, 16));
            var boardSprite = new Sprite(texture, new IntRect(0, 240, 120, 30));
            var brickSprite = new Sprite(texture, new IntRect(0, 0, 40, 40));

            var context = new GameContext()
            {
                Ball = new BallModel()
                    {BallSprite = ballSprite, Position = new Vector2f(392, 530), diametr = 16, Speed = 3.0f},
                Board = new BoardModel()
                    { Position = new Vector2f(340, 550), Speed = 5, Scale = new Vector2f(112, 30) },
                World = new WorldModel() { Scale = new Vector2f(800, 600)}
            };

            var gameObjects = new List<IGameObject>()
            {
                new Ball(ballSprite, context),
                new Board(boardSprite, context),
            };

            var startX = 30;
            var startY = 50;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    var item = new Brick(brickSprite, startX, startY);
                    gameObjects.Add(item);
                    startX += 30;
                }
                startY += 30;
                startX = 30;
            }

            while (closeApp)
            {
                window.DispatchEvents();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    context.Board.PlayerMove = -1;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    context.Board.PlayerMove = 1;
                }

                foreach (var obj in gameObjects)
                {
                    obj.Invoke(context);
                }

                window.Clear(Color.Black);

                foreach (var obj in gameObjects)
                {
                    window.Draw(obj);
                }

                window.Display();
            }
        }
    }
}
