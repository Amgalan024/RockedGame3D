using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MeteorMovement : MonoBehaviour, IGameObjectComponent<Meteor>,IMeteor
{
    public Meteor Meteor { get; set; }
    private Rigidbody mRigidbody;
    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        mRigidbody.velocity = new Vector3(0, -Meteor.Speed);
    }
    public void InitializeComponent(Meteor meteor)
    {
        Meteor = meteor;
    }
}
