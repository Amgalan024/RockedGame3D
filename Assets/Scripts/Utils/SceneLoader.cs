using Cysharp.Threading.Tasks;
using SOData;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Utils
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private ScenesData _scenesData;

        public ScenesData ScenesData => _scenesData;

        //todo:Добавить лоадинг скрин

        public async UniTask LoadSceneAsync(AssetReference scene)
        {
            await Addressables.LoadSceneAsync(scene);
        }
    }
}