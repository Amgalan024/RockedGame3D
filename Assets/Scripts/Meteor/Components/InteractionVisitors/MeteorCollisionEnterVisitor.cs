using Core.InteractionHandle.Visitors;
using Meteor.Models;
using Rocket.Components.Player;
using Rocket.Components.Projectile;

namespace Meteor.Components.InteractionVisitors
{
    public class MeteorCollisionEnterVisitor : InteractionVisitorBase
    {
        private readonly MeteorModel _meteorModel;

        public MeteorCollisionEnterVisitor(MeteorModel meteorModel)
        {
            _meteorModel = meteorModel;
        }

        public override void Visit(PlayerInteractionHandler playerInteractionHandler)
        {
            base.Visit(playerInteractionHandler);

            playerInteractionHandler.PlayerModel.RocketModel.TakeDamage(_meteorModel.Damage);
        }

        public override void Visit(ProjectileInteractionHandler projectileInteractionHandler)
        {
            base.Visit(projectileInteractionHandler);

            projectileInteractionHandler.Projectile.SetActive(false);
        }
    }
}