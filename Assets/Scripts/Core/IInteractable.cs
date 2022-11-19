namespace Core
{
    public interface IInteractable<T>
    {
        void Interact(T meteorModel);
    }
}