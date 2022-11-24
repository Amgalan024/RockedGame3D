using Core.InteractionHandle.Visitors;
using Rocket.Components.Enemy;
using Rocket.Components.Player;
using UnityEngine;

namespace Borders.InteractionVisitors
{
    public class SideBorderTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly SideBorderInteractionHandler _sideBorderInteractionHandler;

        public SideBorderTriggerEnterVisitor(SideBorderInteractionHandler sideBorderInteractionHandler)
        {
            _sideBorderInteractionHandler = sideBorderInteractionHandler;
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
            var otherSideBorderTransform = _sideBorderInteractionHandler.OppositeSideBorder.transform;

            rocketTransform.position =
                new Vector2(otherSideBorderTransform.position.x + _sideBorderInteractionHandler.Offset,
                    rocketTransform.position.y);
        }
    }
}