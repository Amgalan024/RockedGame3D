using Core.InteractionHandle.Visitors;
using Meteor.Components;
using Rocket.Components.Projectile;

namespace Rocket.Components.Player.InteractionVisitors
{
    public class PlayerCollisionEnterVisitor : InteractionVisitorBase
    {
        public override void Visit(MeteorInteractionHandler meteorInteractionHandler)
        {
            base.Visit(meteorInteractionHandler);

            meteorInteractionHandler.MeteorModel.DestroyMeteor();
        }

        public override void Visit(ProjectileInteractionHandler projectileInteractionHandler)
        {
            base.Visit(projectileInteractionHandler);

            projectileInteractionHandler.Projectile.SetActive(false);
        }
    }
}