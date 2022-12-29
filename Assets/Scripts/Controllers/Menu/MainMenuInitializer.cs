using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Controllers.Menu
{
    public class MainMenuInitializer : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _startButton.onClick.AddListener(() =>
                _sceneLoader.LoadSceneAsync(_sceneLoader.ScenesData.Gameplay).Forget());
//todo:Сделать окно настроек включением и выключением отдельного канваса а не сценой
            _settingsButton.onClick.AddListener(() =>
                _sceneLoader.LoadSceneAsync(_sceneLoader.ScenesData.Settings).Forget());

            _exitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}