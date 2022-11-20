using Core;
using Rocket.Models;

namespace Rocket.Components.Enemy.InteractionHandlers
{
    public class EnemyCollisionEnterVisitor : InteractionVisitorBase
    {
        private readonly EnemyModel _enemyModel;

        public EnemyCollisionEnterVisitor(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
        }

        public override void Visit(RocketProjectileInteractionHandler rocketProjectileInteractionHandler)
        {
            base.Visit(rocketProjectileInteractionHandler);

            _enemyModel.RocketModel.TakeDamage(rocketProjectileInteractionHandler.RocketModel.Damage);
        }
    }
}