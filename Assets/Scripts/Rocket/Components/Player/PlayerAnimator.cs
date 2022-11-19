using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player
{
    public class PlayerAnimator : MonoBehaviour, IRocketComponent
    {
        public RocketModel RocketModel { set; get; }

        public void InitializeComponent(RocketModel rocketModel)
        {
            RocketModel = rocketModel;
        }
    }
}