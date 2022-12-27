using System;
using System.Linq;
using SoundModule.SoundData;
using UnityEditor;
using UnityEngine;

namespace SoundModule.Editor
{
    [CustomPropertyDrawer(typeof(SoundItem))]
    public class SoundItemPropertyDrawer : PropertyDrawer
    {
        private const string SearchText = "Search...";

        private SoundLibraryEditorHelper _libraryHelper;

        private SerializedProperty _library;
        private SerializedProperty _groupId;
        private SerializedProperty _soundId;

        private SerializedProperty _track;
        private SerializedProperty _volume;
        private SerializedProperty _loop;

        private SoundGroup _currentSoundGroup;

        private string _searchText;
        private string[] Tracks => _libraryHelper.GetTracks();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InitializeProperties(property);

            _library = property.FindPropertyRelative(nameof(_library));

            EditorGUI.BeginChangeCheck();
            var labelGUIStyle = new GUIStyle
            {
                normal =
                {
                    textColor = Color.red
                }
            };
            EditorGUI.PrefixLabel(position, label, labelGUIStyle);
     
           EditorGUI.ObjectField(new Rect(18,position.y + 24,position.width,20), _library, typeof(SoundLibrary));

            if (_libraryHelper == null && _library.objectReferenceValue != null)
            {
                _libraryHelper = new SoundLibraryEditorHelper(_library.objectReferenceValue as SoundLibrary);
            }

            if (EditorGUI.EndChangeCheck())
            {
                _libraryHelper = new SoundLibraryEditorHelper(_library.objectReferenceValue as SoundLibrary);
                _groupId.stringValue = string.Empty;
                _soundId.stringValue = string.Empty;
            }

            if (_library.objectReferenceValue == null)
            {
                //EditorGUILayout.HelpBox("Missing library", MessageType.Error);
                return;
            }

            DrawSoundIdentifier(position);
            DrawTrackSelector(position);
            _volume.floatValue = EditorGUI.Slider(new Rect(18,position.y + 24 * 6,position.width,20),"Volume: ", _volume.floatValue, 0f, 1.0f);
            _loop.boolValue = EditorGUI.Toggle(new Rect(18,position.y + 24 * 7,position.width,20),"Loop: ", _loop.boolValue);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.FindPropertyRelative(nameof(_library)).objectReferenceValue == null)
            {
                return 50;
            }
            else
            {
                return 200;
            }
        }

        private void InitializeProperties(SerializedProperty property)
        {
            var soundIdentifierProperty = property.FindPropertyRelative("_identifier");

            _groupId = soundIdentifierProperty.FindPropertyRelative(nameof(_groupId));
            _soundId = soundIdentifierProperty.FindPropertyRelative(nameof(_soundId));
            _track = property.FindPropertyRelative(nameof(_track));
            _volume = property.FindPropertyRelative(nameof(_volume));
            _loop = property.FindPropertyRelative(nameof(_loop));
        }

        private void DrawSoundIdentifier(Rect position)
        {
            var selectedGroupIndex = string.IsNullOrEmpty(_groupId.stringValue)
                ? 0
                : _libraryHelper.GetSoundGroupIndex(_groupId.stringValue);

            var groupId = _libraryHelper.GetSoundGroupIdByIndex(selectedGroupIndex);

            _currentSoundGroup = _libraryHelper.GetSoundGroup(groupId);

            var selectedSoundIndex = string.IsNullOrEmpty(_soundId.stringValue)
                ? 0
                : _currentSoundGroup.GetSoundIndexById(_soundId.stringValue);

            var prevGroup = selectedGroupIndex;

            selectedGroupIndex =
                EditorGUI.Popup(new Rect(18,position.y + 24 * 2,position.width,20),"Group: ", selectedGroupIndex,
                    _libraryHelper.GetSoundGroupNames().Select(SplitByUnderscore).ToArray());

            if (prevGroup != selectedGroupIndex)
            {
                selectedSoundIndex = 0;
            }

            groupId = _libraryHelper.GetSoundGroupIdByIndex(selectedGroupIndex);
            _groupId.stringValue = groupId;
            _currentSoundGroup = _libraryHelper.GetSoundGroup(groupId);

            var soundNames = _libraryHelper.GetSoundNames(groupId).Select(SplitByUnderscore).ToArray();

            selectedSoundIndex = UseSearch(soundNames, selectedSoundIndex, position);

            _soundId.stringValue = _currentSoundGroup.GetSoundIdByIndex(selectedSoundIndex);
        }

        private int UseSearch(string[] soundNames, int selectedSoundIndex, Rect position)
        {
            var style = new GUIStyle(EditorStyles.textField)
            {
                border = new RectOffset(4, 4, 4, 4),
                fontSize = 12,
                normal =
                {
                    textColor = new Color(0.61f, 0.61f, 0.61f)
                }
            };

            _searchText =
                EditorGUI.TextField(new Rect(18,position.y + 24 * 3,position.width,20),_searchText ?? SearchText, style);

            var filtered = _searchText == null || _searchText == SearchText
                ? soundNames
                : soundNames.Distinct()
                    .Where(a => a.ToLower().Replace('/', '\0').Contains(_searchText.ToLower()))
                    .ToArray();

            var previous = selectedSoundIndex >= filtered.Length
                ? 0
                : Array.FindIndex(filtered, x => x == soundNames[selectedSoundIndex]);

            var filteredIndex = previous == -1 ? 0 : EditorGUI.Popup(new Rect(18,position.y + 24 * 4,position.width,20),"Sound: ", previous, filtered);

            selectedSoundIndex = filteredIndex >= filtered.Length
                ? selectedSoundIndex
                : Array.FindIndex(soundNames, x => x == filtered[filteredIndex]);

            return selectedSoundIndex;
        }

        private string SplitByUnderscore(string input)
        {
            return input.Replace('_', '/').Trim('/');
        }

        private void DrawTrackSelector(Rect position)
        {
            int selectedIndex = -1;

            if (string.IsNullOrEmpty(_track.stringValue))
            {
                selectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < Tracks.Length; i++)
                {
                    if (!Tracks[i].Equals(_track.stringValue)) continue;

                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex < 0)
            {
                selectedIndex = 0;
            }

            selectedIndex = EditorGUI.Popup(new Rect(18,position.y + 24 * 5,position.width,20),"Track", selectedIndex, Tracks);

            if (selectedIndex >= 0 && selectedIndex < Tracks.Length)
            {
                _track.stringValue = Tracks[selectedIndex];
            }
        }
    }
}