using Core.InteractionHandle.Visitors;
using Items;
using Rocket.Models;

namespace Rocket.Components.Player.InteractionVisitors
{
    public class PlayerTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly PlayerModel _playerModel;

        public PlayerTriggerEnterVisitor(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public override void Visit(ItemInteractionHandler itemInteractionHandler)
        {
            base.Visit(itemInteractionHandler);

            itemInteractionHandler.Item.Buff(_playerModel.RocketModel);
        }
    }
}