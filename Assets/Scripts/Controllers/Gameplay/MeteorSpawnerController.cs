using Meteor;
using Spawners;
using UnityEngine;

namespace Controllers.Gameplay
{
    public class MeteorSpawnerController : MonoBehaviour
    {
        [SerializeField] private MeteorSpawner[] _meteorSpawners;

        private void Awake()
        {
            foreach (var meteorSpawner in _meteorSpawners)
            {
                meteorSpawner.OnSpawned += OnMeteorSpawned;
            }
        }

        private void OnMeteorSpawned(MeteorInitializer meteorInitializer)
        {
            meteorInitializer.InitializeMeteor();
        }
    }
}