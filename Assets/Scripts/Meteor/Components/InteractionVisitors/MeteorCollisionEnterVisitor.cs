using Core;
using Meteor.Models;
using Rocket.Components;
using Rocket.Components.Player;

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
            _meteorModel.DestroyMeteor();
        }

        public override void Visit(RocketProjectileInteractionHandler rocketProjectileInteractionHandler)
        {
            base.Visit(rocketProjectileInteractionHandler);
            _meteorModel.TakeDamage(rocketProjectileInteractionHandler.RocketModel.Damage);
        }
    }
}