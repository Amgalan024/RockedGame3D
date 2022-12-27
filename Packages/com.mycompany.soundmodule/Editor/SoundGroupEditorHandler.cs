using System;
using System.IO;
using System.Linq;
using SoundModule.SoundData;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Assertions;

namespace SoundModule.Editor
{
    public class SoundGroupEditorHandler
    {
        private readonly string[] _allowedExtensions = {".mp3", ".wav", ".ogg"};

        private readonly SerializedObject _serializedObject;

        private readonly SoundGroup _target;

        private ReorderableList _reorderableList;

        private SerializedProperty _groupId;
        private SerializedProperty _soundData;

        private bool _isValidated;

        public SoundGroupEditorHandler(SoundGroup target, SerializedObject serializedObject)
        {
            _target = target;
            _serializedObject = serializedObject;
            _soundData = serializedObject.FindProperty(nameof(_soundData));
            _groupId = serializedObject.FindProperty(nameof(_groupId));

            if (string.IsNullOrEmpty(_groupId.stringValue))
            {
                _groupId.stringValue = Guid.NewGuid().ToString();
                _serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(_target);
            }

            if (!_isValidated)
            {
                _isValidated = ValidateGroupId(_groupId.stringValue);
            }

            InitializeReorderableList();
        }

        public void UpdateInspectorGui()
        {
            DropAreaGUI(AddDroppedSounds);
            InitializeReorderableList();
            _reorderableList.DoLayoutList();
        }

        private void InitializeReorderableList()
        {
            _reorderableList = new ReorderableList(_serializedObject, _soundData, false, true, true, false)
            {
                drawElementCallback = DrawListItems,
                drawHeaderCallback = DrawHeader
            };
        }

        private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (index >= _reorderableList.serializedProperty.arraySize)
            {
                Debug.LogWarning("Index out of range");
                return;
            }

            var element = _reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            var soundProperty = element.FindPropertyRelative("_audioClip");
            DrawButtons(soundProperty, rect);

            var currentWidth = EditorGUIUtility.currentViewWidth;

            EditorGUI.PropertyField(
                new Rect(rect.x + currentWidth * 0.1f, rect.y, EditorGUIUtility.currentViewWidth * 0.8f,
                    EditorGUIUtility.singleLineHeight),
                soundProperty
            );

            var height = rect.height;

            if (GUI.Button(new Rect(rect.x + currentWidth * 0.9f, rect.y, height, height), "X"))
            {
                RemoveSound(index);
            }
        }

        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Sound Groups");
        }

        private void DropAreaGUI(Action<UnityEngine.Object[], string[]> onDropped)
        {
            var evt = Event.current;
            var dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));

            GUI.Box(dropArea, "Drop sounds here");

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(evt.mousePosition))
                    {
                        return;
                    }

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (var path in DragAndDrop.paths)
                        {
                            Assert.IsFalse(!_allowedExtensions.Contains(Path.GetExtension(path)),
                                "One of the dropped files is not an audio file");
                        }

                        onDropped?.Invoke(DragAndDrop.objectReferences, DragAndDrop.paths);
                    }

                    break;
            }
        }

        private void DrawButtons(SerializedProperty soundProperty, Rect rect)
        {
            var height = rect.height;

            if (GUI.Button(new Rect(rect.x + EditorGUIUtility.standardVerticalSpacing, rect.y, height, height),
                    "\u25B6"))
            {
                var assetGuid = soundProperty.FindPropertyRelative("m_AssetGUID");

                if (assetGuid == null || string.IsNullOrEmpty(assetGuid.stringValue))
                {
                    PropertySoundPlayer.PlayAudioClip(soundProperty);
                }
                else
                {
                    PropertySoundPlayer.PlayByAssetReference(assetGuid);
                }
            }

            if (GUI.Button(new Rect(rect.x + height, rect.y, height, height), "\u2716"))
            {
                PropertySoundPlayer.StopClip();
            }
        }

        private void AddDroppedSounds(object[] sounds, string[] paths)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                var audioClip = AudioClipByPath(paths[i]);

                var soundId = Guid.NewGuid().ToString();

                _target.AddToSoundData(soundId, audioClip);
            }

            EditorUtility.SetDirty(_target);
        }

        private void RemoveSound(int index)
        {
            _soundData.DeleteArrayElementAtIndex(index);

            InitializeReorderableList();

            EditorUtility.SetDirty(_target);
            _serializedObject.ApplyModifiedProperties();
        }

        private AudioClip AudioClipByPath(string path)
        {
            return (AudioClip) AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
        }

        private bool ValidateGroupId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var groups = Resources.FindObjectsOfTypeAll<SoundGroup>();

            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] == _target || string.IsNullOrEmpty(groups[i].GetGroupId())) continue;

                if (groups[i].GetGroupId().Equals(id))
                {
                    return false;
                }
            }

            return true;
        }
    }
}