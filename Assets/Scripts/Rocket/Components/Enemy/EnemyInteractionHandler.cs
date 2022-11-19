using Core;
using Rocket.Components.Player;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyInteractionHandler : MonoBehaviour, IEnemyComponent
    {
        public EnemyModel EnemyModel { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            var rocketInteractable = collision.gameObject.GetComponent<IInteractable<RocketModel>>();
            rocketInteractable.Interact(EnemyModel.RocketModel);

            var enemyInteractable = collision.gameObject.GetComponent<IInteractable<EnemyModel>>();
            enemyInteractable.Interact(EnemyModel);
        }

        public void InitializeComponent(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;
        }
    }
}