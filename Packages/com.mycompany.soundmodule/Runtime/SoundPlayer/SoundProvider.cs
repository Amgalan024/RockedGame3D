using SoundModule.SoundData;
using UnityEngine;

namespace SoundModule.SoundPLayer
{
    public class SoundProvider
    {
        private readonly SoundLibrary _soundLibrary;

        public SoundProvider(SoundLibrary soundLibrary)
        {
            _soundLibrary = soundLibrary;
        }

        public AudioClip GetClip(ISound soundItem)
        {
            var soundGroup = _soundLibrary.GetSoundGroup(soundItem.Identifier.GetGroupId());
            var clip = soundGroup.GetSound(soundItem.Identifier.GetSoundId());

            return clip.AudioClip;
        }
    }
}