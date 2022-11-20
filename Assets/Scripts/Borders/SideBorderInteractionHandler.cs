using UnityEngine;

namespace Borders
{
    public class SideBorderInteractionHandler : MonoBehaviour
    {
        [SerializeField] private SideBorderInteractionHandler _oppositeSideBorder;
        [SerializeField] private float _offset;

        public float Offset => _offset;
        public SideBorderInteractionHandler OppositeSideBorder => _oppositeSideBorder;
    }
}