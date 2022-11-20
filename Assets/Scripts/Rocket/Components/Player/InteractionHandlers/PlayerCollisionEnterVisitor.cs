using Core;
using Meteor.Components;
using Rocket.Models;

namespace Rocket.Components.Player.InteractionHandlers
{
    public class PlayerCollisionEnterVisitor : InteractionVisitorBase
    {
        private readonly PlayerModel _playerModel;

        public PlayerCollisionEnterVisitor(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public override void Visit(MeteorInteractionHandler meteorInteractionHandler)
        {
            base.Visit(meteorInteractionHandler);
            _playerModel.RocketModel.TakeDamage(meteorInteractionHandler.MeteorModel.Damage);
        }

        public override void Visit(RocketProjectileInteractionHandler rocketProjectileInteractionHandler)
        {
            base.Visit(rocketProjectileInteractionHandler);
            _playerModel.RocketModel.TakeDamage(rocketProjectileInteractionHandler.RocketModel.Damage);
        }
    }
}