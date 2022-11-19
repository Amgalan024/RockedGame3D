using Core;
using Rocket.Models;

namespace Rocket
{
    public interface IRocketComponent : IGameEntityComponent<RocketModel>
    {
        RocketModel RocketModel { set; get; }
    }
}