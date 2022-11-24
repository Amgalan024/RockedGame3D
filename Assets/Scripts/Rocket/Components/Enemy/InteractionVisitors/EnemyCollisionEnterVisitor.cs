using Core.InteractionHandle.Visitors;
using Rocket.Components.Projectile;

namespace Rocket.Components.Enemy.InteractionVisitors
{
    public class EnemyCollisionEnterVisitor : InteractionVisitorBase
    {
        public override void Visit(ProjectileInteractionHandler projectileInteractionHandler)
        {
            base.Visit(projectileInteractionHandler);

            projectileInteractionHandler.Projectile.SetActive(false);
        }
    }
}