using Borders;
using Core.InteractionHandle.Visitors;
using Meteor.Models;

namespace Meteor.Components.InteractionVisitors
{
    public class MeteorTriggerEnterVisitor : InteractionVisitorBase
    {
        private readonly MeteorModel _meteorModel;

        public MeteorTriggerEnterVisitor(MeteorModel meteorModel)
        {
            _meteorModel = meteorModel;
        }

        public override void Visit(BottomBorderInteractionHandler bottomBorderInteractionHandler)
        {
            base.Visit(bottomBorderInteractionHandler);
            _meteorModel.DestroyMeteor();
        }
    }
}