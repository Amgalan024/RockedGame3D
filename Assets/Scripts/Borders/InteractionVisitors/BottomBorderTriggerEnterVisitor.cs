using Core.InteractionHandle.Visitors;
using Meteor.Components;
using Rocket.Components.Enemy;

namespace Borders.InteractionVisitors
{
    public class BottomBorderTriggerEnterVisitor : InteractionVisitorBase
    {
        public override void Visit(EnemyInteractionHandler enemyInteractionHandler)
        {
            base.Visit(enemyInteractionHandler);
            enemyInteractionHandler.EnemyModel.RocketModel.DestroyRocket();
        }

        public override void Visit(MeteorInteractionHandler meteorInteractionHandler)
        {
            base.Visit(meteorInteractionHandler);
            meteorInteractionHandler.MeteorModel.DestroyMeteor();
        }
    }
}