using System.Collections.Generic;
using System.Linq;
using SoundModule.SoundData;
using UnityEngine;

namespace SoundModule.Editor
{
    public class SoundLibraryEditorHelper
    {
        private readonly string[] _libraryNotFoundMessage = {"No library found"};
        private readonly SoundLibrary _library;

        private Dictionary<string, string[]> _soundNames;
        private string[] _groupNames;
        private string[] _trackNames;

        public SoundLibraryEditorHelper(SoundLibrary library)
        {
            _library = library;

            Initialize();
        }

        public string[] GetTracks()
        {
            if (_library == null)
            {
                return _libraryNotFoundMessage;
            }

            return _trackNames;
        }

        public string[] GetSoundGroupNames()
        {
            if (_library == null || _library.Groups == null)
            {
                return _libraryNotFoundMessage;
            }

            return _groupNames;
        }

        public string GetSoundGroupIdByIndex(int groupIndex)
        {
            if (groupIndex >= _library.Groups.Count || groupIndex < 0)
            {
                return string.Empty;
            }

            return _library.Groups[groupIndex].GetGroupId();
        }

        public int GetSoundGroupIndex(string groupId)
        {
            var groups = _library.Groups.Select(gr => gr.GetGroupId()).ToList();
            return groups.IndexOf(groupId);
        }

        public SoundGroup GetSoundGroup(string groupId)
        {
            var foundGroup = _library.GetSoundGroup(groupId);

            if (foundGroup == null)
            {
                Debug.LogWarning($"Group with id {groupId} not found. Using default");
                foundGroup = _library.Groups.FirstOrDefault();
            }

            return foundGroup;
        }

        public string[] GetSoundNames(string groupId)
        {
            if (_library == null)
            {
                return _libraryNotFoundMessage;
            }

            var soundGroup = _library.GetSoundGroup(groupId);

            if (!_soundNames.ContainsKey(soundGroup.name))
            {
                return new[] {"[Group not found]"};
            }

            return _soundNames[soundGroup.name];
        }

        private void Initialize()
        {
            _soundNames = new Dictionary<string, string[]>();

            if (_library == null)
            {
                _soundNames.Add("[Missing Library]", new[] {"[Missing Library]"});
                return;
            }

            foreach (var libraryGroup in _library.Groups)
            {
                if (libraryGroup == null)
                {
                    _soundNames.Add("[Missing group]", new[] {"[Missing sound]"});
                    continue;
                }


                var soundNames = libraryGroup.SoundData.Select(data =>
                    data.AudioClip == null
                        ? "[Missing sound]"
                        : data.AudioClip.name);

                _soundNames.Add(libraryGroup.name, soundNames.ToArray());
            }

            _groupNames = _soundNames.Keys.ToArray();
            _trackNames = _library.GetAudioMixer().FindMatchingGroups(string.Empty).Select(x => x.name).ToArray();
        }
    }
}