using Core;
using Rocket.Models;

namespace Rocket.Components.Player
{
    public class PlayerInitializer : RocketInitializer
    {
        public PlayerModel PlayerModel { get; set; }

        public void InitializePlayer()
        {
            InitializeRocket();

            PlayerModel = new PlayerModel(RocketModel);

            foreach (var component in GetComponentsInChildren<IGameEntityComponent<PlayerModel>>())
            {
                component.InitializeComponent(PlayerModel);
            }
        }
    }
}