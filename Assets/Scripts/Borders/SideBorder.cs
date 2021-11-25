using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SideBorder : MonoBehaviour
{
    [SerializeField] GameObject otherBorder;
    [SerializeField] private float offset;
    private BoxCollider ownBoxCollider;
    private BoxCollider otherBoxCollider;
    private void Start()
    {
        ownBoxCollider = GetComponent<BoxCollider>();
        otherBoxCollider = otherBorder.GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            if (gameObject.name == "RightBorder")
            {
                collision.transform.position = new Vector2(otherBorder.transform.position.x + offset, collision.transform.position.y);
            }
            if (gameObject.name == "LeftBorder")
            {
                collision.transform.position = new Vector2(otherBorder.transform.position.x - offset, collision.transform.position.y);
            }
        }
    }
}
