namespace Core
{
    public interface ITriggerEnterHandler
    {
        IInteractionVisitor TriggerEnterVisitor { set; get; }
    }
}