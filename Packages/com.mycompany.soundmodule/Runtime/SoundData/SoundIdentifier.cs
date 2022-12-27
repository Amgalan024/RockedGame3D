using System;
using UnityEngine;

namespace SoundModule.SoundData
{
    [Serializable]
    public class SoundIdentifier
    {
        [SerializeField, HideInInspector] private string _groupId;

        [SerializeField, HideInInspector] private string _soundId;

        public string GetGroupId()
        {
            return _groupId;
        }

        public string GetSoundId()
        {
            return _soundId;
        }

#if UNITY_EDITOR
        public SoundIdentifier(string groupId, string soundId)
        {
            _groupId = groupId;
            _soundId = soundId;
        }
#endif
    }
}