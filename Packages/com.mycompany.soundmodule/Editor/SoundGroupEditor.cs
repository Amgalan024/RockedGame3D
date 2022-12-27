using SoundModule.SoundData;
using UnityEditor;

namespace SoundModule.Editor
{
    [CustomEditor(typeof(SoundGroup))]
    public class SoundGroupEditor : UnityEditor.Editor
    {
        private SoundGroup _soundGroup;
        private SoundGroupEditorHandler _handler;

        private void OnEnable()
        {
            _soundGroup = (SoundGroup) target;
            _handler = new SoundGroupEditorHandler(_soundGroup, serializedObject);
        }

        public override void OnInspectorGUI()
        {
            _handler.UpdateInspectorGui();
        }
    }
}