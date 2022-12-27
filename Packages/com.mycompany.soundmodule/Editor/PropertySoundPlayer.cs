using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace SoundModule.Editor
{
    internal static class PropertySoundPlayer
    {
        internal static void PlayByAssetReference(SerializedProperty assetReferenceGuid)
        {
            if (assetReferenceGuid == null || string.IsNullOrEmpty(assetReferenceGuid.stringValue)) return;

            var clip = (AudioClip) EditorGUIUtility.Load(AssetDatabase.GUIDToAssetPath(assetReferenceGuid.stringValue));
            PlayClip(clip);
        }

        internal static void PlayAudioClip(SerializedProperty audioClipProperty)
        {
            if (audioClipProperty == null) return;

            PlayClip(audioClipProperty.objectReferenceValue as AudioClip);
        }

        internal static void StopClip()
        {
            var unityEditorAssembly = typeof(AudioImporter).Assembly;
            var audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            var method = audioUtilClass.GetMethod(
                "StopAllPreviewClips",
                BindingFlags.Static | BindingFlags.Public,
                null,
                new Type[] { },
                null
            );
            if (method != null) method.Invoke(null, null);
        }

        private static void PlayClip(AudioClip clip, int startSample = 0, bool loop = false)
        {
            StopClip();
            var unityEditorAssembly = typeof(AudioImporter).Assembly;
            var audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            var method = audioUtilClass.GetMethod(
                "PlayPreviewClip",
                BindingFlags.Static | BindingFlags.Public,
                null,
                new[] {typeof(AudioClip), typeof(int), typeof(bool)},
                null
            );
            if (method != null)
                method.Invoke(
                    null,
                    new object[] {clip, startSample, loop}
                );
        }
    }
}