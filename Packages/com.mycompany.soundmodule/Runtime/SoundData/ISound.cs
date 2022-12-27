namespace SoundModule.SoundData
{
    public interface ISound
    {
        SoundIdentifier Identifier { get; }
        float Volume { get; }
        string Track { get; }
        bool Loop { get; }
    }
}