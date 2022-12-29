using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _progress;

        public void SetProgress(float value)
        {
            _progress.value = value;
        }
    }
}