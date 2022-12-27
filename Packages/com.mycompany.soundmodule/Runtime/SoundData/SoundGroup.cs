using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoundModule.SoundData
{
    [CreateAssetMenu(fileName = "SoundGroup", menuName = "Sound / SoundGroup")]
    public class SoundGroup : ScriptableObject
    {
        [SerializeField] private List<SoundData> _soundData;

        [SerializeField] private string _groupId;

        public List<SoundData> SoundData => _soundData;

        private void Awake()
        {
            _groupId = Guid.NewGuid().ToString();
        }

        public string GetGroupId()
        {
            return _groupId;
        }

        public SoundData GetSound(string soundId)
        {
            SoundData soundData = null;

            foreach (var soundMapItem in _soundData)
            {
                if (!soundMapItem.SoundId.Equals(soundId)) continue;

                soundData = soundMapItem;
                break;
            }

            return soundData;
        }


#if UNITY_EDITOR
        public int GetSoundIndexById(string soundId)
        {
            var soundIndex = 0;

            for (int i = 0; i < _soundData.Count; i++)
            {
                if (!_soundData[i].SoundId.Equals(soundId)) continue;

                soundIndex = i;
                break;
            }

            return soundIndex;
        }

        public string GetSoundIdByIndex(int index)
        {
            return _soundData[index].SoundId;
        }

        private void RemoveSoundById(string soundId)
        {
            var soundToRemove = _soundData.Find(x => x.SoundId.Equals(soundId));
            if (soundToRemove != null)
            {
                _soundData.Remove(soundToRemove);
            }
        }

        public void AddToSoundData(string soundId, AudioClip clip)
        {
            var soundData = new SoundData(soundId, _groupId, clip);

            _soundData.Add(soundData);
        }
#endif
    }
}