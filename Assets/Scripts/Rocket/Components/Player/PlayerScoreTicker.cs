using System;
using Cysharp.Threading.Tasks;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerScoreTicker : MonoBehaviour, IPlayerComponent
    {
        public PlayerModel PlayerModel { get; set; }
        public int ScoreTick { set; get; }

        public void InitializeComponent(PlayerModel component)
        {
            PlayerModel = component;
        }

        private async UniTask StartScoreTickAsync()
        {
            while (PlayerModel.RocketModel.HealthPoint > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                PlayerModel.AddScorePoints(ScoreTick);
            }
        }
    }
}