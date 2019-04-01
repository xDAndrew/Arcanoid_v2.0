using SFML.System;

namespace Arcanoid.Context.ContextModels
{
    public class BoardModel
    {
        public Vector2f Position { get; set; }
        public Vector2f Scale { get; set; }
        public sbyte PlayerMove { get; set; }
        public float Speed { get; set; }
    }
}
