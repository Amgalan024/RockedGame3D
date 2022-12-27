using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Rocket.Components
{
    public class RocketExplosion : MonoBehaviour
    {
        [SerializeField] private RocketExplosionPart[] _rocketParts;
        [SerializeField] private Transform _center;
        [SerializeField] private float _explosionDuration;
        [SerializeField] private ParticleSystem _explosionEffect;

        public async UniTask ExplodeAnimationAsync()
        {
            _explosionEffect.Play();

            var animationSequence = DOTween.Sequence();

            foreach (var rocketPart in _rocketParts)
            {
                var initialPosition = rocketPart.transform.position;

                var moveToPoint = rocketPart.GetMoveToPoint();


                var tween = rocketPart.transform.DOMove(moveToPoint, _explosionDuration)
                    .OnComplete(() => { rocketPart.transform.position = initialPosition; });

                animationSequence.Join(tween);
            }

            await animationSequence.AsyncWaitForCompletion();
        }
    }
}