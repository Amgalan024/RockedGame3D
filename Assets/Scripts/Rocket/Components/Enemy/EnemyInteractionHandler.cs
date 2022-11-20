using Core;
using Rocket.Components.Enemy.InteractionHandlers;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyInteractionHandler : MonoBehaviour, IEnemyComponent, ICollisionEnterHandler, ITriggerEnterHandler
    {
        public EnemyModel EnemyModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; set; }
        public IInteractionVisitor TriggerEnterVisitor { get; set; }

        public void InitializeComponent(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;
            CollisionEnterVisitor = new EnemyCollisionEnterVisitor(EnemyModel);
            TriggerEnterVisitor = new EnemyTriggerEnterVisitor(EnemyModel);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionEnterHandler = collision.gameObject.GetComponent<ICollisionEnterHandler>();

            collisionEnterHandler.CollisionEnterVisitor.Visit(this);
        }
    }
}