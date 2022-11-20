namespace Core
{
    public interface ICollisionEnterHandler
    {
        IInteractionVisitor CollisionEnterVisitor { set; get; }
    }
}