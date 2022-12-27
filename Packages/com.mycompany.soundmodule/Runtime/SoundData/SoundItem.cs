using System;
using UnityEngine;

namespace SoundModule.SoundData
{
    [Serializable]
    public class SoundItem : ISound
    {
        [SerializeField] private SoundIdentifier _identifier;

        [SerializeField] private string _track;

        [SerializeField, Range(0f, 1.0f)] private float _volume = 1.0f;

        [SerializeField] private bool _loop;

#if UNITY_EDITOR
        [SerializeField] private SoundLibrary _library;

        public SoundItem(string track, float volume, SoundLibrary library)
        {
            _track = track;
            _volume = volume;
            _library = library;
        }
#endif

        public SoundIdentifier Identifier => _identifier;
        
        public float Volume => _volume;
        
        public string Track => _track;
        
        public bool Loop => _loop;
    }
}