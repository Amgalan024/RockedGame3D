using Core.InteractionHandle.Visitors;
using Rocket.Components.Player;

namespace Items.InteractionHandlers
{
    public class ItemTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly ItemBase _itemBase;

        public ItemTriggerEnterVisitor(ItemBase itemBase)
        {
            _itemBase = itemBase;
        }

        public override void Visit(PlayerInteractionHandler playerInteractionHandler)
        {
            base.Visit(playerInteractionHandler);

            _itemBase.Buff(playerInteractionHandler.PlayerModel.RocketModel);
        }
    }
}