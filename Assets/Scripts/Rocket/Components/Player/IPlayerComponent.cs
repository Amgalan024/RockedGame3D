using Core;
using Rocket.Models;

namespace Rocket.Components.Player
{
    public interface IPlayerComponent : IGameEntityComponent<PlayerModel>
    {
        PlayerModel PlayerModel { get; set; }
    }
}