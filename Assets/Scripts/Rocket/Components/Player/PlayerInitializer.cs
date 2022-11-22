using Core;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerInitializer : RocketInitializer
    {
        public PlayerModel PlayerModel { get; set; }

        public void InitializePlayer(Transform projectileContainer)
        {
            InitializeRocket(projectileContainer);

            PlayerModel = new PlayerModel(RocketModel);

            foreach (var component in GetComponentsInChildren<IGameEntityComponent<PlayerModel>>())
            {
                component.InitializeComponent(PlayerModel);
            }
        }
    }
}