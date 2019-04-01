using Arcanoid.Context;
using Arcanoid.GameObjects.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Arcanoid.GameObjects
{
    internal class Ball : Transformable, IGameObject
    {
        private Vector2f position = new Vector2f(0.0f, 0.0f);
        private Vector2f direction = new Vector2f(1.0f, -1.0f);
        private readonly Sprite image;

        public Ball(Sprite image, GameContext context)
        {
            this.image = image;
            position = context.Ball.Position;
            direction = new Vector2f(context.Ball.Speed, -context.Ball.Speed);
        }

        public void Invoke(GameContext context)
        {
            var diametr = context.Ball.diametr;

            if (context.Ball.BrickTouchX)
            {
                direction.X *= -1;
                context.Ball.BrickTouchX = false;
            }

            if (context.Ball.BrickTouchY)
            {
                direction.Y *= -1;
                context.Ball.BrickTouchY = false;
            }

            position.X += direction.X;
            position.Y += direction.Y;

            if (position.X + diametr > context.World.Scale.X || position.X < 0)
            {
                direction.X = direction.X * -1.0f;
            }

            if (position.Y + diametr > context.World.Scale.Y || position.Y < 0)
            {
                direction.Y = direction.Y * -1.0f;
            }

            if (position.Y + diametr > context.Board.Position.Y &&
                position.X > context.Board.Position.X &&
                position.X < context.Board.Position.X + context.Board.Scale.X)
            {
                direction.Y *= -1;
            }

            context.Ball.Position = position;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            image.Position = position;
            states.Transform *= Transform;
            target.Draw(image);
        }
    }
}
