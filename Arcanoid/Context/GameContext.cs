using Arcanoid.Context.ContextModels;

namespace Arcanoid.Context
{
    public class GameContext
    {
        public WorldModel World { get; set; }
        public BoardModel Board { get; set; }
        public BallModel Ball { get; set; }
    }
}
