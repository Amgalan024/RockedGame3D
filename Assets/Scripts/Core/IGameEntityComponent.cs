namespace Core
{
    public interface IGameEntityComponent<T>
    {
        void InitializeComponent(T component);
    }
}