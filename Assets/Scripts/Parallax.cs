using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float parallaxEffect;
    private float lenght;
    private float startPos;

    private void Start()
    {
        startPos = transform.position.y;
        lenght = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        float temp = camera.transform.position.y * (1 - parallaxEffect);
        float distance = camera.transform.position.y * parallaxEffect;
        transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);
        if (temp >= startPos + lenght)
        {
            startPos += lenght * 2;
        }
        else if (temp <= startPos - lenght)
        {
            startPos -= lenght * 2;
        }
    }
}
