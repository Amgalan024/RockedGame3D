using Core.InteractionHandle.Visitors;
using Meteor.Components;
using Rocket.Components.Enemy;
using Rocket.Components.Player;
using Rocket.Models;

namespace Rocket.Components.Projectile.InteractionVisitors
{
    public class ProjectileCollisionEnterVisitor : InteractionVisitorBase
    {
        private readonly RocketModel _rocketModel;

        public ProjectileCollisionEnterVisitor(RocketModel rocketModel)
        {
            _rocketModel = rocketModel;
        }

        public override void Visit(MeteorInteractionHandler meteorInteractionHandler)
        {
            base.Visit(meteorInteractionHandler);

            meteorInteractionHandler.MeteorModel.TakeDamage(_rocketModel.Damage);
        }

        public override void Visit(PlayerInteractionHandler playerInteractionHandler)
        {
            base.Visit(playerInteractionHandler);

            playerInteractionHandler.PlayerModel.RocketModel.TakeDamage(_rocketModel.Damage);
        }

        public override void Visit(EnemyInteractionHandler enemyInteractionHandler)
        {
            base.Visit(enemyInteractionHandler);

            enemyInteractionHandler.EnemyModel.RocketModel.TakeDamage(_rocketModel.Damage);
        }
    }
}