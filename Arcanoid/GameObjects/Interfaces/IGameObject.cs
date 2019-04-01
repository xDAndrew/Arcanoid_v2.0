using Arcanoid.Context;
using SFML.Graphics;

namespace Arcanoid.GameObjects.Interfaces
{
    public interface IGameObject : Drawable
    {
        void Invoke(GameContext context);
    }
}