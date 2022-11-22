using Core.InteractionHandle.Visitors;
using Rocket.Components.Projectile;
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

        public override void Visit(ProjectileInteractionHandler projectileInteractionHandler)
        {
            base.Visit(projectileInteractionHandler);

            _enemyModel.RocketModel.TakeDamage(projectileInteractionHandler.RocketModel.Damage);
        }
    }
}