using Core.InteractionHandle.Visitors;
using Rocket.Components.Enemy.InteractionVisitors;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Enemy
{
    public class EnemyInteractionHandler : MonoBehaviour, IEnemyComponent, ICollisionEnterVisitor
    {
        public EnemyModel EnemyModel { get; set; }
        public IInteractionVisitor CollisionEnterVisitor { get; private set; }
        public EnemyMovementStrategy EnemyMovementStrategy { get; private set; }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionEnterHandler = collision.gameObject.GetComponent<ICollisionEnterVisitor>();

            collisionEnterHandler?.CollisionEnterVisitor.Visit(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var triggerEnterHandler = other.gameObject.GetComponent<ITriggerEnterVisitor>();

            triggerEnterHandler?.TriggerEnterVisitor.Visit(this);
        }

        public void InitializeComponent(EnemyModel enemyModel)
        {
            EnemyModel = enemyModel;

            CollisionEnterVisitor = new EnemyCollisionEnterVisitor();

            EnemyMovementStrategy = GetComponent<EnemyMovementStrategy>();
        }
    }
}