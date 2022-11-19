using Core;
using Meteor.Models;
using Rocket.Components.Player;
using Rocket.Models;
using UnityEngine;

namespace Borders
{
    public class BottomBorder : MonoBehaviour, IInteractable<EnemyModel>, IInteractable<MeteorModel>
    {
        public void Interact(EnemyModel enemyModel)
        {
            enemyModel.RocketModel.DestroyRocket();
        }

        public void Interact(MeteorModel meteorModel)
        {
            meteorModel.DestroyMeteor();
        }
    }
}