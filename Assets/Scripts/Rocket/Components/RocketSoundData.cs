using SoundModule.SoundData;
using UnityEngine;

namespace Rocket.Components
{
    [CreateAssetMenu(fileName = "RocketSoundData", menuName = "GameData/Sound/RocketSounds")]
    public class RocketSoundData : ScriptableObject
    {
        [SerializeField] private SoundItem _temp;
        [SerializeField] private SoundItem _temp1;

    }
}