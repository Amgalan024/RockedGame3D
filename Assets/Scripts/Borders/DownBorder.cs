using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DownBorder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyMovement>())
        {
            other.GetComponent<EnemyMovement>().Rocket.DestroyRocket();
        }
        if (other.GetComponent<MeteorMovement>())
        {
            other.GetComponent<MeteorMovement>().Meteor.DestroyMeteor();
        }
    }
}
