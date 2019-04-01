using Arcanoid.Context;
using Arcanoid.GameObjects.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Arcanoid.GameObjects
{
    class Brick : Transformable, IGameObject
    {
        private bool ICanBeRemoved = false;
        private Vector2f position;
        private const float Height = 30;
        private const float Weight = 30;
        private Sprite image;

        public Brick(Sprite image,int x = 0, int y = 0)
        {
            position = new Vector2f(x, y);
            this.image = image;
        }

        private bool touch(Vector2f pos)
        {
            if (pos.X > position.X &&
                pos.X < position.X + Weight &&
                pos.Y > position.Y &&
                pos.Y < position.Y + Height)
            {
                return true;
            }
            return false;
        }

        public void Invoke(GameContext context)
        {
            if (!ICanBeRemoved)
            {
                var center = context.Ball.diametr / 2;
                if (touch(new Vector2f(context.Ball.Position.X + center, context.Ball.Position.Y)) ||
                    touch(new Vector2f(context.Ball.Position.X + center, context.Ball.Position.Y + center * 2)))
                {
                    context.Ball.BrickTouchY = true;
                    ICanBeRemoved = true;
                }

                if (touch(new Vector2f(context.Ball.Position.X, context.Ball.Position.Y + center)) ||
                    touch(new Vector2f(context.Ball.Position.X + center * 2, context.Ball.Position.Y + center)))
                {
                    context.Ball.BrickTouchX = true;
                    ICanBeRemoved = true;
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (!ICanBeRemoved)
            {
                image.Position = position;
                states.Transform *= Transform;
                target.Draw(image);
            }
        }
    }
}
