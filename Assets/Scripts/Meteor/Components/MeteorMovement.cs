using Meteor.Models;
using UnityEngine;

namespace Meteor.Components
{
    public class MeteorMovement : MonoBehaviour, IMeteorComponent
    {
        public MeteorModel MeteorModel { get; set; }

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidbody.velocity = new Vector3(0, -MeteorModel.Speed);
        }

        public void InitializeComponent(MeteorModel meteorModel)
        {
            MeteorModel = meteorModel;
        }
    }
}