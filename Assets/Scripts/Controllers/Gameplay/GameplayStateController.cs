using Cysharp.Threading.Tasks;
using Rocket.Models;
using UnityEngine;
using Utils;

namespace Controllers.Gameplay
{
    public class GameplayStateController : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;

        private void Awake()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized += OnPlayerModelInitialized;
        }

        private void OnPlayerModelInitialized(PlayerModel playerModel)
        {
            playerModel.RocketModel.OnRocketDestroyed += OnPlayerDied;
        }

        private void OnPlayerDied(bool _)
        {
            _sceneLoader.LoadSceneAsync(_sceneLoader.ScenesData.MainMenu).Forget();
        }
    }
}