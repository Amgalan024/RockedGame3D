using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SOData
{
    [CreateAssetMenu(fileName = nameof(ScenesData), menuName = "SOData/" + nameof(ScenesData))]
    public class ScenesData : ScriptableObject
    {
        [SerializeField] private AssetReference _mainMenu;
        [SerializeField] private AssetReference _gameplay;
        [SerializeField] private AssetReference _settings;

        public AssetReference MainMenu => _mainMenu;
        public AssetReference Gameplay => _gameplay;
        public AssetReference Settings => _settings;
    }
}