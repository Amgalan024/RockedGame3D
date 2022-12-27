using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SoundModule.SoundData
{
    [CreateAssetMenu(fileName = "SoundLibrary", menuName = "Sound/SoundLibrary")]
    public class SoundLibrary : ScriptableObject
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private List<SoundGroup> _groups;

        public List<SoundGroup> Groups => _groups;

        public SoundGroup GetSoundGroup(string groupId)
        {
            SoundGroup foundGroup = null;

            for (int i = 0; i < _groups.Count; i++)
            {
                if (_groups[i].GetGroupId().Equals(groupId))
                {
                    foundGroup = _groups[i];
                    break;
                }
            }

            return foundGroup;
        }

        public AudioMixer GetAudioMixer()
        {
            return _audioMixer;
        }
    }
}