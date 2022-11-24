using Core.InteractionHandle.Visitors;
using Rocket.Components.Enemy;
using Rocket.Components.Player;
using UnityEngine;

namespace Borders.InteractionVisitors
{
    public class SideBorderTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly Transform _oppositeSideBorder;
        private readonly float _offset;

        public SideBorderTriggerEnterVisitor(float offset, Transform oppositeSideBorder)
        {
            _offset = offset;
            _oppositeSideBorder = oppositeSideBorder;
        }

        public override void Visit(EnemyInteractionHandler enemyInteractionHandler)
        {
            base.Visit(enemyInteractionHandler);

            enemyInteractionHandler.EnemyMovementStrategy.ChangeSideDirection();
        }

        public override void Visit(PlayerInteractionHandler playerInteractionHandler)
        {
            base.Visit(playerInteractionHandler);

            var rocketTransform = playerInteractionHandler.PlayerModel.RocketModel.RocketTransform;

            rocketTransform.position =
                new Vector2(_oppositeSideBorder.position.x + _offset, rocketTransform.position.y);
        }
    }
}