using System.Numerics;
using SFML.Graphics;
using SFML.System;

namespace Arcanoid.Context.ContextModels
{
    public class BallModel
    {   
        public Vector2f Position { get; set; }
        public float diametr { get; set; }
        public bool BrickTouchX { get; set; }
        public bool BrickTouchY { get; set; }
        public Sprite BallSprite { get; set; }
        public float Speed { get; set; } = 1.0f;
    }
}
