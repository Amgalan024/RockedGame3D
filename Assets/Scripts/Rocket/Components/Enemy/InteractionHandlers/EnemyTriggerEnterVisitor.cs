using Borders;
using Core.InteractionHandle.Visitors;
using Rocket.Models;

namespace Rocket.Components.Enemy.InteractionHandlers
{
    public class EnemyTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly EnemyModel _enemyModel;

        public EnemyTriggerEnterVisitor(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
        }

        public override void Visit(BottomBorderInteractionHandler bottomBorderInteractionHandler)
        {
            base.Visit(bottomBorderInteractionHandler);
            _enemyModel.RocketModel.DestroyRocket();
        }
    }
}