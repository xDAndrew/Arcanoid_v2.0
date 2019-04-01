using Arcanoid.Context;
using Arcanoid.GameObjects.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Arcanoid.GameObjects
{
    class Board : Transformable, IGameObject
    {
        private Vector2f position;
        private readonly Sprite image;

        public Board(Sprite image, GameContext contex)
        {
            position = contex.Board.Position;
            this.image = image;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            image.Position = position;
            states.Transform = Transform;
            target.Draw(image);
        }

        public void Invoke(GameContext context)
        {
            if (context.Board.PlayerMove != 0)
            {
                if (context.Board.PlayerMove == 1)
                {
                    if (position.X + context.Board.Scale.X + context.Board.Speed < context.World.Scale.X)
                    {
                        position.X += context.Board.Speed;
                    }
                }
                else
                {
                    if (position.X > 0)
                    {
                        position.X -= context.Board.Speed;
                    }
                }

                context.Board.Position = position;
                context.Board.PlayerMove = 0;
            }
        }
    }
}
