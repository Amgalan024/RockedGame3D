using Borders;
using Core.InteractionHandle.Visitors;
using Rocket.Models;
using UnityEngine;

namespace Rocket.Components.Player.InteractionHandlers
{
    public class PlayerTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly PlayerModel _playerModel;

        public PlayerTriggerEnterVisitor(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public override void Visit(SideBorderInteractionHandler sideBorderInteractionHandler)
        {
            base.Visit(sideBorderInteractionHandler);

            var rocketTransform = _playerModel.RocketModel.RocketTransform;
            var otherSideBorderTransform = sideBorderInteractionHandler.OppositeSideBorder.transform;

            rocketTransform.position = new Vector2(
                otherSideBorderTransform.position.x + sideBorderInteractionHandler.Offset,
                rocketTransform.position.y);
        }
    }
}