using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class PlayerBuff : MonoBehaviour
{
    public abstract IEnumerator Buff(Rocket rocket);
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInteractions>())
        {
            gameObject.SetActive(false);
        }
    }
 
}
