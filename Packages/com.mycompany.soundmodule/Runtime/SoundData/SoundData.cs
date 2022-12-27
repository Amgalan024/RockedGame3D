using System;
using UnityEngine;

namespace SoundModule.SoundData
{
    [Serializable]
    public class SoundData
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private string _soundId;
        [SerializeField] private string _groupId;

        public SoundData(string soundId, string groupId, AudioClip audioClip)
        {
            _soundId = soundId;
            _groupId = groupId;
            _audioClip = audioClip;
        }

        public AudioClip AudioClip => _audioClip;
        public string SoundId => _soundId;
        public string GroupId => _groupId;
    }
}