namespace Core.InteractionHandle.Visitors
{
    public interface ICollisionEnterVisitor
    {
        IInteractionVisitor CollisionEnterVisitor { get; }
    }
}