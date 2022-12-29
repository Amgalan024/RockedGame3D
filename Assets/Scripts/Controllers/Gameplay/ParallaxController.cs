using Rocket.Models;
using UnityEngine;
using Utils;

namespace Controllers.Gameplay
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Parallax[] _parallaxes;
        [SerializeField] private GameplayEntryPoint _gameplayEntryPoint;

        private void Awake()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized += OnPlayerModelInitialized;
        }

        private void OnDestroy()
        {
            _gameplayEntryPoint.OnPlayerModelInitialized -= OnPlayerModelInitialized;
        }

        private void OnPlayerModelInitialized(PlayerModel playerModel)
        {
            SetParallaxesActive(true);
            playerModel.RocketModel.OnRocketDestroyed += OnPlayerDied;
        }

        private void OnPlayerDied(bool obj)
        {
            SetParallaxesActive(false);
        }

        private void SetParallaxesActive(bool isActive)
        {
            foreach (var parallax in _parallaxes)
            {
                parallax.enabled = isActive;
            }
        }
    }
}