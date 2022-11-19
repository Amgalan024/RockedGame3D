using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers.Menu
{
    public class MainMenuInitializer : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _startButton.onClick.AddListener(delegate { SceneManager.LoadSceneAsync(1); });
            _settingsButton.onClick.AddListener(delegate { SceneManager.LoadScene(1); });
            _exitButton.onClick.AddListener(delegate { Application.Quit(); });
        }
    }
}