using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BuffItem : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    public abstract IEnumerator Buff(Rocket rocket);
    private Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0,-fallSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInteractions>())
        {
            gameObject.SetActive(false);
        }
    }
 
}
