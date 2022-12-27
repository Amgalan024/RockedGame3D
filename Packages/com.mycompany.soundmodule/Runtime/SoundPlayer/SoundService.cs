using SoundModule.SoundData;

namespace SoundModule.SoundPLayer
{
    public class SoundService
    {
        private readonly SoundProvider _soundProvider;

        public SoundService(SoundProvider soundProvider)
        {
            _soundProvider = soundProvider;
        }

        public void PlayOneShot(ISound sound)
        {
            var clip = _soundProvider.GetClip(sound);
        }
    }
}